/*!
 * @class メカナムを制御するクラス
 * 【注意】１秒間以上データが送られてこない時には強制停止する．
 */

// ToDo: 接続チェックのプログラムを入れる

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace real_robot_battle
{
    public class Mechanum
    {
        private float x;        //! x方向の位置 (m)
        private float y;        //! y方向の位置 (m)
        private float the;      //! 回転方向の角度 (rad)
        private float dx;       //! x方向の速度 (m/s)
        private float dy;       //! y方向の速度 (m/s)
        private float dthe;     //! 回転方向の角速度 (rad/s)
        private float ddx;      //! x方向の加速度 (m/s^2)
        private float ddy;      //! y方向の加速度 (m/s^2)
        private float ddthe;    //! 回転方向の角加速度 (rad/s^2)
        private float wheelSpeedFrontRight; //! 右前のホイールの回転数 (rad/s)
        private float wheelSpeedFrontLeft;  //! 左前のホイールの回転数 (rad/s)
        private float wheelSpeedRearRight;  //! 右後のホイールの回転数 (rad/s)
        private float wheelSpeedRearLeft;   //! 左後のホイールの回転数 (rad/s)

        private Thread thread;
        private bool watchdog;
        private bool watchdogFlag;
        private bool isFinish;

        RRBSerial serial = null;

        public enum ID {        //! それぞれのモータのID
            FRONT_RIGHT = 1,
            FRONT_LEFT,
            REAR_RIGHT,
            REAR_LEFT,
        };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Mechanum()
        {
            Initialize();
            // ウォッチドックのスレッド
            isFinish = false;
            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~Mechanum()
        {
        }

        /// <summary>
        /// 通信ポートを閉じる処理（上半身でも通信を使用しているので閉じると上半身と通信ができなくなる）
        /// </summary>
        public void Close()
        {
            serial.Close();
            isFinish = true;
            thread.Join();
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
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            x = 0;
            y = 0;
            the = 0;
            watchdogFlag = true;
            watchdog = false;
        }

        /// <summary>
        /// モータの停止
        /// </summary>
        public void Stop()
        {
            setSpeed(0, 0, 0);
        }

        /// <summary>
        /// 速度の設定（m/sでの指定は実現できていない）
        /// </summary>
        /// <param name="dx">x方向（前が＋）の速度(m/s)</param>
        /// <param name="dy">y方向（左が＋）の速度(m/s)</param>
        /// <param name="dthe">回転方向（時計回りが＋）の速度(rad/s)</param>
        public void setSpeed(float dx, float dy, float dthe)
        {
            if (serial == null) return;

            this.dx = dx;
            this.dy = dy;
            this.dthe = dthe;
            calculateWheelSpeed();

            serial.sendSpeed((byte)ID.FRONT_RIGHT, (short)wheelSpeedFrontRight);
            serial.sendSpeed((byte)ID.FRONT_LEFT, (short)wheelSpeedFrontLeft);
            serial.sendSpeed((byte)ID.REAR_RIGHT, (short)wheelSpeedRearRight);
            serial.sendSpeed((byte)ID.REAR_LEFT, (short)wheelSpeedRearLeft);
            watchdog = true;
        }

        /// <summary>
        /// 加速度の設定
        /// </summary>
        /// <param name="ddx">x方向の速度(m/s^2)</param>
        /// <param name="ddy">y方向の速度(m/s^2)</param>
        /// <param name="ddthe">回転方向の速度(rad/s^2)</param>
        public void setAcceleration(float ddx, float ddy, float ddthe)
        {
            this.ddx = ddx;
            this.ddy = ddy;
            this.ddthe = ddthe;
        }

        /// <summary>
        /// x方向の位置を戻す
        /// </summary>
        /// <returns>x方向の位置(m)</returns>
        public float getX()
        {
            return x;
        }

        /// <summary>
        /// y方向の位置を戻す
        /// </summary>
        /// <returns>y方向の位置(m)</returns>
        public float getY()
        {
            return y;
        }

        /// <summary>
        /// 回転方向の角度を戻す
        /// </summary>
        /// <returns>回転方向の角度(rad)</returns>
        public float getThe()
        {
            return  the;
        }

        /// <summary>
        /// 処理ループ
        /// </summary>
        /// １秒間以上データが来ていない場合は停止する
        private void ThreadProc()
		{
            while (!isFinish)
            {
                if (watchdogFlag)
                {
                    if (watchdog == false)      // 信号が来ていない場合
                    {
                        Stop();
                    }
                    watchdog = false;
                }
                Thread.Sleep(1000);         // 監視する周期
            }
		}

        /// <summary>
        /// ロボットの方向からホイールの速度を決定
        /// </summary>
        private void calculateWheelSpeed()
        {
            const float r = 6.0f;
            wheelSpeedFrontRight = r * (  dx / 3 + dy / 3 + dthe / 3);
            wheelSpeedFrontLeft  = r * (- dx / 3 + dy / 3 + dthe / 3);
            wheelSpeedRearRight  = r * (  dx / 3 - dy / 3 + dthe / 3);
            wheelSpeedRearLeft   = r * (- dx / 3 - dy / 3 + dthe / 3);
        }
    }
}
