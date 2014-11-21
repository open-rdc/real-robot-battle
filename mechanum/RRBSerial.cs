using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace real_robot_battle
{
    /// <summary>
    /// RRBサーボモータを制御するクラス
    /// </summary>
    public class RRBSerial
    {
        const string defaultPortName = "COM1";     // デフォルトのポート名
        SerialPort serial = null;           // シリアルポート
        const int BAUDRATE = 19200;         // RRBサーボとの通信レート(bps)
        const float ratio = 25.0f * 72.0f / 22.0f;
        byte[] recvData = new byte[100];
        int recvNum = 0;

        /// <summary>
        /// コマンドのメモリーマップ
        /// </summary>
        public enum COM
        {
            VER = 0,	    // EEPROMのバージョン(とりあえず1が書き込まれていない場合は未設定とする）
            ID,             // ID (0-254, 255:broadcast)
            DEADBAND_CW,    // 位置制御時のデッドバンド（*0.1deg, 時計回り）
            DEADBAND_CCW,   // 位置制御時のデッドバンド（*0.1deg, 反時計回り）
            VCONT_KP,       // 比例フィードバックゲイン
            VCONT_KI,       // 積分フィードバックゲイン
            MAX_TORQUE_CW,  // 最大トルク
            MAX_TORQUE_CCW, // 最大トルク
            PUNCH_CW,       // パンチ (0-1000)
            PUNCH_CCW,      // パンチ (0-1000)
            MAX_SPEED_CW,   // 最大速度 (0-1000)
            MAX_SPEED_CCW,  // 最大速度 (0-1000)
            MAX_ANGLE_CW,   // 可動領域 (0-1000)
            MAX_ANGLE_CCW,  // 可動領域 (0-1000)
            MAX_ACC_CW,     // 最大速度 (0-1000)
            MAX_ACC_CCW,    // 最大速度 (0-1000)
            OFFSET_ANGLE,   // 初期角度 (0-1000)
            PCONT_KP,       // 比例フィードバックゲイン
            PCONT_KI,       // 積分フィードバックゲイン
            PCONT_KD,       // 微分フィードバックゲイン
            ANGLE       = 0x80,     // 角度の指令 (*8.57deg)　　【角度制御】
            PERIOD      = 0x81,	    // 周期の指令 (msec)
            SPEED       = 0x82,	    // 速度の指令 (*8.57deg/s)　【角速度制御】
            PWM         = 0x83,		// PWMの指令 (-1000~1000)
            EEPWRITE    = 0x90,     // EEPROMへの書き込み設定
            READ_ANGLE  = 0xa0,		// angleの取得
            READ_STATUS = 0xa1,		// 全パラメータの取得
            INIT        = 0xf0,     // 初期化（全て初期パラメータに変更）
        };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RRBSerial()
        {
            serial = new SerialPort();
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~RRBSerial()
        {
            this.Close();
        }

        /// <summary>
        /// ポートのオープン
        /// </summary>
        /// <param name="portName">ポート名</param>
        public void Open(string portName)
        {
            serial.PortName = portName;
            serial.BaudRate = BAUDRATE;
            serial.DataReceived += new SerialDataReceivedEventHandler(dataReceivedHandler);
            try
            {
                serial.Open();
            }
            catch
            {
                MessageBox.Show("佐川サーボモータのCOM1を開くことができません．");
            }
        }

        /// <summary>
        /// ポートのオープン
        /// </summary>
        public void Open()
        {
            Open(defaultPortName);
        }

        /// <summary>
        /// ポートのクローズ
        /// </summary>
        public void Close()
        {
            serial.Close();
        }

        /// <summary>
        /// データを送信する
        /// </summary>
        /// <param name="data">送信するバイナリデータ</param>
        /// <param name="num">データの数</param>
        /// <returns>結果(0:正常，-1:異常終了)</returns>
        private int sendData(byte[] data, int num)
        {
            if (!serial.IsOpen) return -1;
            serial.Write(data, 0, num);
            return 0;
        }

        /// <summary>
        /// データを受信した時のハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serial = (SerialPort)sender;
            byte[] msg = new byte[serial.BytesToRead];
            serial.Read(msg, 0, serial.BytesToRead);

            for (int i = 0; i < msg.Length; i++)
            {
                recvData[recvNum] = msg[i];
                if (recvNum < 99) recvNum++;
            }
        }
        
        /// <summary>
        /// 速度制御のゲイン
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="kp">比例ゲイン</param>
        /// <param name="ki">積分ゲイン</param>
        public void sendVCont(byte id, short kp, short ki)
        {
            sendCommand(id, COM.VCONT_KP, kp);
            sendCommand(id, COM.VCONT_KI, ki);
        }

        /// <summary>
        /// 最大トルク
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="maxTorque">最大トルク(0-1000)</param>
        public void sendMaxTorque(byte id, short maxTorque)
        {
            sendCommand(id, COM.MAX_TORQUE_CW , maxTorque);
            sendCommand(id, COM.MAX_TORQUE_CCW, maxTorque);
        }

        /// <summary>
        /// 最大速度の設定
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="maxSpeed">最大速度(pulse/s)</param>
        public void sendMaxSpeed(byte id, short maxSpeed)
        {
            sendCommand(id, COM.MAX_SPEED_CW , maxSpeed);
            sendCommand(id, COM.MAX_SPEED_CCW, maxSpeed);
        }

        /// <summary>
        /// 可動域の設定
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="minAngle">最小角度(pulse)</param>
        /// <param name="maxAngle">最大角度(pulse)</param>
        public void sendMotionRange(byte id, short minAngle, short maxAngle)
        {
            sendCommand(id, COM.MAX_ANGLE_CW , maxAngle);
            sendCommand(id, COM.MAX_ANGLE_CCW, minAngle);
        }

        /// <summary>
        /// 初期位置
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="offsetAngle">オフセット角度(pulse)</param>
        public void sendMotionRange(byte id, short offsetAngle)
        {
            sendCommand(id, COM.OFFSET_ANGLE, offsetAngle);
        }

        /// <summary>
        /// 位置制御のゲイン
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="kp">比例ゲイン</param>
        /// <param name="ki">積分ゲイン</param>
        /// <param name="kd">微分ゲイン</param>
        public void sendPCont(byte id, short kp, short ki, short kd)
        {
            sendCommand(id, COM.PCONT_KP, kp);
            sendCommand(id, COM.PCONT_KI, ki);
            sendCommand(id, COM.PCONT_KD, kd);
        }

        /// <summary>
        /// 周期の指令
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="angle">周期(msec)</param>
        public void sendPeriod(byte id, short period)
        {
            sendCommand(id, COM.PERIOD, period);
        }

        /// <summary>
        /// 角度の指令
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="angle">サーモータの角度(pulse)</param>
        /// １回転72pulseのモータ
        public void sendAngle(byte id, short angle)
        {
            sendCommand(id, COM.ANGLE, angle);
        }

        /// <summary>
        /// 速度の指令
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="speed">サーモータの速度(pulse/s)</param>
        /// １回転72pulseのモータ
        public void sendSpeed(byte id, short speed)
        {
            sendCommand(id, COM.SPEED, speed);
        }

        /// <summary>
        /// PWMのデューティ比の指令
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="speed">サーモータのデューティ比(-1000～1000)</param>
        /// １回転72pulseのモータ
        public void sendPWM(byte id, short PWM)
        {
            sendCommand(id, COM.PWM, PWM);
        }

        /// <summary>
        /// 角度の指令
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="deg">サーモータの角度(degree)</param>
        public void sendAngleDeg(byte id, float deg)
        {
            short angle = (short)(deg * ratio);
            sendAngle(id, angle);
        }

        /// <summary>
        /// 速度の指令
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="deg">サーモータの速度(degree/s)</param>
        public void sendSpeedDeg(byte id, float deg)
        {
            short speed = (short)(deg * ratio);
            sendSpeed(id, speed);
        }

        /// <summary>
        /// 角度の取得
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <returns>サーモータの角度(pulse)</returns>
        /// 100ms待って角度を取得できない場合はタイムアウト
        public int recvAngle(byte id)
        {
            int res = -1;

            recvNum = 0;
            sendCommand(id, COM.READ_ANGLE, 0);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(10);
                if (recvNum == 2)
                {
                    res = ((int)recvData[1] << 8) + recvData[0];
                }
            }
            return res;
        }

        /// <summary>
        /// 角度の取得
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <returns>サーモータの角度(deg), -1:エラー</returns>
        /// 100ms待って角度を取得できない場合はタイムアウト
        public float recvAngleDeg(byte id)
        {
             return recvAngle(id);
        }

        /// <summary>
        /// コマンドの送信
        /// </summary>
        /// <param name="id">サーボモータのID</param>
        /// <param name="command">コマンド</param>
        /// <param name="data">データ</param>
        public void sendCommand(byte id, COM command, short data)
        {
            byte[] buf = new byte[7];
            buf[0] = 0xfa;
            buf[1] = 0xaf;
            buf[2] = id;
            buf[3] = (byte)command;
            buf[4] = (byte)(data >> 8);
            buf[5] = (byte)(data & 0xff);
            buf[6] = (byte)(buf[2] ^ buf[3] ^ buf[4] ^ buf[5]);
            sendData(buf, 7);
        }
    }
}
