using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace real_robot_battle
{
    /// <summary>
    /// それぞれのモータのID
    /// </summary> 
    public enum ID
    {        
        WAIST = 5,
        LEFT_SHOULDER_PITCH,
        LEFT_SHOULDER_ROLL,
        LEFT_ELBOW_PITCH,
        RIGHT_SHOULDER_PITCH,
        RIGHT_SHOULDER_ROLL,
        RIGHT_ELBOW_PITCH,
        LIFT_LEFT,
        LIFT_RIGHT,
    };

    /// <summary>
    /// 上半身を制御するクラス
    /// </summary>
    public class MotionControl
    {
        const double degToPulse = 9.545;

        private Thread thread = null;                       // モーションを再生するスレッド
        RRBSerial serial;                                   // シリアル通信のクラス
        int[] offsetAngle = new int[7];                     // オフセット角度（ホイールセンサ基準）
        const string offsetFilename = "..\\..\\offset_angle.txt";   // オフセット角度のファイル名
        List<int[]> motionData = new List<int[]>();         // モーションデータ
        const int motionDataNum = 9;
        int[] nowAngle = new int[7];

        bool isTestMode = true;
        const int testModeTorque = 100;
        const int fightModeTorque = 1000;
        const int testModePeriod = 10000;
        bool isTerminate = false;

        bool isMotionPlay = false;

        private Thread angleThread = null;                  // 角度を計算するスレッド
        bool isAngleThreadTerminate = false;
        int[] deltaAngle = new int[7];
        int[] moveingPeriod = new int[7];

        int[] sentAngleDeg = new int[7];
        int[,] limitAngle = new int[7, 2] { { -90, 90 }, { -90, 90 }, { 0, 120 }, { -90, 0 }, { -90, 90 }, { 0, 120 }, { -90, 0 } };

        bool[] isServoOn = new bool[7];

        ///<summary>
        ///コンストラクタ
        ///</summary>
        public MotionControl()
        {
            Initialize();
            angleThread = new Thread(new ThreadStart(AngleThreadProc));
            angleThread.Start();
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~MotionControl()
        {
        }

        /// <summary>
        /// RRBSerialクラスのインスタンスの登録
        /// </summary>
        /// <param name="serial">RRBSerialクラスのインスタンス</param>
        public void setSerialPort(RRBSerial serial)
        {
            this.serial = serial;
        }

        /// <summary>
        /// クローズ（このクラスを終了する時に呼び出す）
        /// </summary>
        public void Close()
        {
            isAngleThreadTerminate = true;
        }
        
        /// <summary>
        /// オフセット角度の読み込み
        /// </summary>
        public void readOffsetAngle()
        {
            try
            {
                FileStream fs = new FileStream(offsetFilename, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
                {
                    offsetAngle[i - (int)ID.WAIST] = int.Parse(sr.ReadLine());
                }
                sr.Close();
                fs.Close();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                //FileNotFoundExceptionをキャッチした時
                System.Console.WriteLine("ファイルが見つかりませんでした。");
                System.Console.WriteLine(ex.Message);
                
            }
        }

        /// <summary>
        /// オフセット角度の書き込み
        /// </summary>
        public void writeOffsetAngle()
        {
            try
            {
                FileStream fs = new FileStream(offsetFilename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
                {
                    sw.WriteLine(offsetAngle[i - (int)ID.WAIST].ToString());
                }
                sw.Close();
                fs.Close();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                //FileNotFoundExceptionをキャッチした時
                System.Console.WriteLine("ファイルが見つかりませんでした。");
                System.Console.WriteLine(ex.Message);

            }
        }

        /// <summary>
        /// モーションデータの読み込み
        /// </summary>
        public void readMotionData(string filename)
        {
            string line = "";
            string[] stArray;
            
            // モーションデータがすでにある場合は削除
            if (motionData.Count != 0)
            {
                motionData.Clear();
            }
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                while ((line = sr.ReadLine()) != null)
                {
                    stArray = line.Split(',');
                    if (stArray.Count() == motionDataNum)
                    {
                        int[] data = new int[motionDataNum];
                        for (int i = 0; i < motionDataNum; i++)
                        {
                            data[i] = int.Parse(stArray[i]);
                        }
                        motionData.Add(data);
                    }
                }
                sr.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("モーションファイル [" + filename + "] がありません．");
            }
        }

        /// <summary>
        /// モーションデータの書き込み
        /// </summary>
        public void writeMotionData(string filename)
        {
            string stWrite;

            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < motionData.Count(); i++)
            {
                stWrite = "";
                for (int j = 0; j < motionDataNum; j++)
                {
                    stWrite += ((int[])motionData[i])[j].ToString();
                    if (j != motionDataNum - 1) stWrite += ", ";
                }
                sw.WriteLine(stWrite);
                System.Diagnostics.Debug.WriteLine(stWrite);
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// モーションデータの取得
        /// </summary>
        /// <param name="no">モーションの番号</param>
        /// <returns>モーションのデータ(int[])</returns>
        public int[] getMotionData(int no)
        {
            if (no < motionData.Count())
            {
                return motionData[no];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// モーションのデータ数
        /// </summary>
        /// <returns>データ数</returns>
        public int getMotionCount()
        {
            return motionData.Count();
        }

        /// <summary>
        /// モーションデータの追加
        /// </summary>
        /// <param name="data">モーションデータ(int[])</param>
        public void addMotionData(int[] data)
        {
            if (data.Count() == motionDataNum)
            {
                motionData.Add(data);
            }
        }

        /// <summary>
        /// モーションデータの削除
        /// </summary>
        /// <param name="no">モーション番号</param>
        public void deleteMotionData(int no)
        {
            if (no < motionData.Count())
            {
                motionData.RemoveAt(no);
            }
        }

        /// <summary>
        /// モーションデータの削除
        /// </summary>
        public void clearMotionData()
        {
            motionData.Clear();
        }
        
        /// <summary>
        /// モーションデータの挿入
        /// </summary>
        /// <param name="no">モーションのデータ番号</param>
        /// <param name="data">モーションデータ(int[])</param>
        public void insertMotionData(int no, int[] data)
        {
            if (no < motionData.Count())
            {
                motionData.Insert(no, data);
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            isAngleThreadTerminate = false;
            isMotionPlay = false;
            for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
            {
                isServoOn[i - (int)ID.WAIST] = false;
            }
        }

        /// <summary>
        /// モーションの再生を行う
        /// </summary>
        /// <param name="filename">モーションデータのファイル名</param>
        public void playMotion(string filename)
        {
            readMotionData(filename);
            playMotion();
        }

        /// <summary>
        /// モーションの再生を行う
        /// </summary>
        public void playMotion()
        {
            if ((thread == null)||(!thread.IsAlive))
            {
                isTerminate = false;
                thread = new Thread(new ThreadStart(ThreadProc));
                thread.Start();
            }
        }

        /// <summary>
        /// サーボON
        /// </summary>
        /// <param name="is_on">サーボをONにする</param>
        public void servoOn(bool is_on)
        {
            for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
            {
                servoOn(i, is_on);
            }
        }

        /// <summary>
        /// 角度の計測
        /// </summary>
        /// <param name="no">モータの番号</param>
        public void readAngle(int no)
        {
            nowAngle[no - (int)ID.WAIST] = serial.recvAngle((byte)no);
        }

        /// <summary>
        /// 角度の取得
        /// </summary>
        /// <param name="no">モータの番号</param>
        /// <returns>角度(ボールセンサ基準)</returns>
        public int getAngle(int no)
        {
            return nowAngle[no - (int)ID.WAIST];
        }

        public int getAngleDeg(int no)
        {
            double angle = nowAngle[no - (int)ID.WAIST] - offsetAngle[no - (int)ID.WAIST];
            return (int)(angle / degToPulse);
        }

        /// <summary>
        /// サーボON/OFF
        /// </summary>
        /// <param name="no">サーボの番号(5-11)</param>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void servoOn(int no, bool is_on)
        {
            if (is_on)
            {
                readAngle(no);
                int angle = getAngle(no);
                serial.sendAngle((byte)no, (short)angle);
                isServoOn[no - (int)ID.WAIST] = true;
            }
            else
            {
                serial.sendPWM((byte)no, 0);
                isServoOn[no - (int)ID.WAIST] = false;
            }
        }

        /// <summary>
        /// テストモードを設定する
        /// </summary>
        /// <param name="is_test_mode">true:テストモード，false:テストモード解除</param>
        public void setTestMode(bool isTestMode)
        {
            this.isTestMode = isTestMode;

            if (isTestMode)
            {
                for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
                {
                    serial.sendMaxTorque((byte)i, testModeTorque);
                    serial.sendPeriod((byte)i, testModePeriod);
                }
            }
            else
            {
                for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
                {
                    serial.sendMaxTorque((byte)i, fightModeTorque);
                }
            }
        }

        /// <summary>
        /// オフセット角度の取得
        /// </summary>
        /// <param name="id">モータのID</param>
        /// <returns>オフセット角度(ホールセンサ基準)</returns>
        public int getOffsetAngle(int id)
        {
            return offsetAngle[id - (int)ID.WAIST];
        }

        /// <summary>
        /// オフセット角度の設定
        /// </summary>
        /// <param name="id">モータのID</param>
        /// <param name="value">オフセット角度の値(ホールセンサ基準)</param>
        public void setOffsetAngle(int id, int value)
        {
            offsetAngle[id - (int)ID.WAIST] = value;
        }

        /// <summary>
        /// モータの停止
        /// </summary>
        /// <param name="no">停止するモータの番号</param>
        public void stop(int no)
        {
            serial.sendSpeed((byte)no, 0);
            isServoOn[no - (int)ID.WAIST] = false;
        }

        /// <summary>
        /// 全てのモータを停止
        /// </summary>
        public void stop()
        {
            isTerminate = true;
            for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
            {
                stop(i);
            }
        }

        /// <summary>
        /// 角度の指令値を送る．
        /// </summary>
        /// <param name="id">モータのID</param>
        /// <param name="angle">角度（ホールセンサを基準，オフセット値は考慮しない）</param>
        public void sendAngle(byte id, short angle)
        {
            if (isServoOn[id - (int)ID.WAIST])
            {
                serial.sendAngle(id, angle);
            }
        }

        /// <summary>
        /// 角度をdegreeで指定して制御する
        /// </summary>
        /// <param name="id">モータのID</param>
        /// <param name="angle">角度(deg)</param>
        public void sendAngleDeg(int id, int angle)
        {
            if ((isServoOn[id-(int)ID.WAIST])&&(angle != sentAngleDeg[id - (int)ID.WAIST]))
            {
                angle = Math.Min(Math.Max(angle, limitAngle[id - (int)ID.WAIST, 0]), limitAngle[id - (int)ID.WAIST, 1]);
                int ang = (int)(angle * degToPulse + offsetAngle[id - (int)ID.WAIST]);
                serial.sendAngle((byte)id, (short)ang);
                sentAngleDeg[id - (int)ID.WAIST] = angle;
            }
        }

        /// <summary>
        /// 角度をdegreeで指定して，period(ms)で制御する．
        /// </summary>
        /// <param name="id">モータのID</param>
        /// <param name="angle">角度(deg)</param>
        /// <param name="period">時間(ms)</param>
        public void sendAngleDeg(int id, int angle, int period)
        {
            if (angle != sentAngleDeg[id - (int)ID.WAIST])
            {
                serial.sendPeriod((byte)id, (short)period);
                sendAngleDeg(id, angle);
            }
        }

        /// <summary>
        /// 時間の指令値を送る．
        /// </summary>
        /// <param name="id">モータのID</param>
        /// <param name="angle">時間(msec)</param>
        public void sendPeriod(byte id, short period)
        {
            serial.sendPeriod(id, period);
        }

        /// <summary>
        /// 現在のモーションデータのある番号を再生
        /// </summary>
        /// <param name="no">モーションデータの番号</param>
        public void playMotionData(int no)
        {
            if (no < motionData.Count())
            {
                for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
                {
                    if (isServoOn[i - (int)ID.WAIST])
                    {
                        serial.sendAngle((byte)i, (short)(((int[])motionData[no])[i - (int)ID.WAIST + 2] + offsetAngle[i - (int)ID.WAIST]));
                    }
                }
            }
        }

        /// <summary>
        /// モーションを再生しているかどうかを戻す
        /// </summary>
        /// <returns>true:モーションを再生している, false:再生していない</returns>
        public bool IsMotionPlay()
        {
            return isMotionPlay;
        }

        public void Lift(int speed)
        {
            serial.sendSpeed((byte)ID.LIFT_LEFT , (short)speed);
            serial.sendSpeed((byte)ID.LIFT_RIGHT, (short)speed);
        }

        /// <summary>
        /// モーション再生用スレッド
        /// </summary>
        private void ThreadProc()
        {
            isMotionPlay = true;
            for (int i = 0; i < motionData.Count(); i++)
            {
                int period = testModePeriod;
                if (!isTestMode)
                {
                    period = ((int[])motionData[i])[1];
                    for (int j = (int)ID.WAIST; j <= (int)ID.RIGHT_ELBOW_PITCH; j++)
                    {
                        sendPeriod((byte)j, (short)period);
                    }
                }
                for (int j = (int)ID.WAIST; j <= (int)ID.RIGHT_ELBOW_PITCH; j++)
                {
                    sendAngle((byte)j, (short)(((int[])motionData[i])[j - (int)ID.WAIST + 2] + offsetAngle[j - (int)ID.WAIST]));
                }
                for (int j = (int)ID.WAIST; j <= (int)ID.RIGHT_ELBOW_PITCH; j++)
                {
                    setAngle(j, (int)(((int[])motionData[i])[j - (int)ID.WAIST + 2] + offsetAngle[j - (int)ID.WAIST]),period);
                }
                Thread.Sleep(period);
                if (isTerminate) return;
            }
            isMotionPlay = false;
        }

        /// <summary>
        /// 角度を計算するスレッド
        /// </summary>
        private void AngleThreadProc()
        {
            while (!isAngleThreadTerminate)
            {
                for(int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i ++)
                {
                    if (moveingPeriod[i - (int)ID.WAIST] > 0)
                    {
                        nowAngle[i - (int)ID.WAIST] += deltaAngle[i - (int)ID.WAIST];
                        moveingPeriod[i - (int)ID.WAIST] -= 100;
                    }
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 現在の角度を得るために，目標角度を設定する
        /// </summary>
        /// <param name="distAngle">目標角度の組み合わせ(ホールセンサベース)</param>
        /// <param name="period">時間(ms)</param>
        private void setAngle(int id, int distAngle, int period)
        {
            this.moveingPeriod[id - (int)ID.WAIST] = period;
            int n = (period + 99) / 100;
            if (n <= 0) n = 1;
            deltaAngle[id - (int)ID.WAIST] = (distAngle - nowAngle[id - (int)ID.WAIST]) / n;
            // 100ms毎に加算する数
        }
    }
}
