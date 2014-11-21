using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace real_robot_battle
{
    public class RealRobotRelay
    {
        const string com_port = "COM4";
        USBRelay usbRelay;
        Thread winkerLeftThread;
        bool is_finish_winker_left_thread;
        int winker_left_thread_time;
        Thread winkerRightThread;
        bool is_finish_winker_right_thread;
        int winker_right_thread_time;
        Thread smokeThread;
        bool is_finish_smoke_thread;
        int smoke_thread_time;
        Thread headThread;
        bool is_finish_head_thread;
        int head_thread_time;
        Thread matrixThread;
        bool is_finish_matrix_thread;
        int matrix_thread_time;

        public enum Relay{
            LIGHT_ARM_FRONT_RIGHT = 0,
            LIGHT_ARM_FRONT_LEFT,
            LIGHT_HEAD,
            LIGHT_HEAD_BOOST,
            EXAUST_SHOOT,
            EXAUST_CHARGE,
            SMOKE_RIGHT,
            SMOKE_LEFT,
            LIGHT_WINKER_RIGHT,
            LIGHT_WINKER_LEFT,
            MATRIX,
        }

        public RealRobotRelay()
        {
            usbRelay = new USBRelay(); ;
            usbRelay.Open(com_port);
        }

        public void Close()
        {
            usbRelay.Close();
        }

        /// <summary>
        /// フロントライトの点灯
        /// </summary>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void setFrontLight(bool is_on)
        {
            usbRelay.setRelay((int)Relay.LIGHT_ARM_FRONT_LEFT, is_on);
            usbRelay.setRelay((int)Relay.LIGHT_ARM_FRONT_RIGHT, is_on);
        }

        /// <summary>
        /// ヘッドライトの点灯
        /// </summary>
        /// <param name="is_on">true:ON, false:off</param>
        public void setHeadLight(bool is_on)
        {
            usbRelay.setRelay((int)Relay.LIGHT_HEAD, is_on);
        }

        /// <summary>
        /// ブーストの時のヘッドライト
        /// </summary>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void setHeadLightBoost(bool is_on)
        {
            usbRelay.setRelay((int)Relay.LIGHT_HEAD_BOOST, is_on);
        }

        /// <summary>
        /// イグゾーストの発射
        /// </summary>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void shootExaust(bool is_on)
        {
            usbRelay.setRelay((int)Relay.EXAUST_SHOOT, is_on);
        }

        /// <summary>
        /// イグゾーストのチャージ
        /// </summary>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void chargeExaust(bool is_on)
        {
            usbRelay.setRelay((int)Relay.EXAUST_CHARGE, is_on);
        }

        /// <summary>
        /// 肩からスモークを出す
        /// </summary>
        /// <param name="period">時間(ms)</param>
        /// <param name="is_on">true:出力，false:停止</param>
        public void setShoulderSmoke(int period, bool is_on)
        {
            if (is_on)
            {
                is_finish_smoke_thread = false;
                smoke_thread_time = period;
                if ((smokeThread == null) || (!smokeThread.IsAlive))
                {
                    smokeThread = new Thread(new ThreadStart(SmokeThreadProc));
                    smokeThread.Start();
                }
            }
            else
            {
                is_finish_smoke_thread = true;
            }
        }


        /// <summary>
        /// 右のウインカーの制御
        /// </summary>
        /// <param name="period">時間(msec)</param>
        /// <param name="is_on">true:on, false:off</param>
        public void setWinkerRight(int period, bool is_on)
        {
            if (is_on)
            {
                is_finish_winker_right_thread = false;
                winker_right_thread_time = period;
                if ((winkerRightThread == null)||(!winkerRightThread.IsAlive))
                {
                    winkerRightThread = new Thread(new ThreadStart(WinkerRightThreadProc));
                    winkerRightThread.Start();
                }
            }
            else
            {
                is_finish_winker_right_thread = true;
            }
        }

        /// <summary>
        /// 左ウインカーの点灯
        /// </summary>
        /// <param name="period">時間(ms)</param>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void setWinkerLeft(int period, bool is_on)
        {
            if (is_on)
            {
                is_finish_winker_left_thread = false;
                winker_left_thread_time = period;
                if ((winkerLeftThread == null)||(!winkerRightThread.IsAlive))
                {
                    winkerLeftThread = new Thread(new ThreadStart(WinkerLeftThreadProc));
                    winkerLeftThread.Start();
                }
            }
            else
            {
                is_finish_winker_left_thread = true;
            }
        }

        /// <summary>
        /// 右ウインカーのスレッド
        /// </summary>
        private void WinkerRightThreadProc()
        {
            bool is_on = false;

            while (!is_finish_winker_right_thread)
            {
                is_on ^= true;
                usbRelay.setRelay((int)Relay.LIGHT_WINKER_RIGHT, is_on);
                Thread.Sleep(500);
                winker_right_thread_time -= 500;
                if (winker_right_thread_time < 0) break;
            }
            usbRelay.setRelay((int)Relay.LIGHT_WINKER_RIGHT, false);
        }

        /// <summary>
        /// 左ウィンカーのスレッド
        /// </summary>
        private void WinkerLeftThreadProc()
        {
            bool is_on = false;

            while (!is_finish_winker_left_thread)
            {
                is_on ^= true;
                usbRelay.setRelay((int)Relay.LIGHT_WINKER_LEFT, is_on);
                Thread.Sleep(500);
                winker_left_thread_time -= 500;
                if (winker_left_thread_time < 0) break;
            }
            usbRelay.setRelay((int)Relay.LIGHT_WINKER_LEFT, false);
        }

        /// <summary>
        /// 煙スレッド
        /// </summary>
        private void SmokeThreadProc()
        {
            usbRelay.setRelay((int)Relay.SMOKE_RIGHT, true);
            usbRelay.setRelay((int)Relay.SMOKE_LEFT, true);
            while (!is_finish_smoke_thread)
            {
                Thread.Sleep(100);
                smoke_thread_time -= 100;
                if (smoke_thread_time < 0) break;
            }
            usbRelay.setRelay((int)Relay.SMOKE_RIGHT, false);
            usbRelay.setRelay((int)Relay.SMOKE_LEFT, false);
        }

        /// <summary>
        /// マトリクスのライトの点灯
        /// </summary>
        /// <param name="period">時間(ms)</param>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void setMatrixLight(int period,bool is_on)
        {
            if (is_on)
            {
                is_finish_matrix_thread = false;
                matrix_thread_time = period;
                if ((matrixThread == null) || (!matrixThread.IsAlive))
                {
                    matrixThread = new Thread(new ThreadStart(MatrixThreadProc));
                    matrixThread.Start();
                }
            }
            else
            {
                is_finish_matrix_thread = true;
            }
        }

        /// <summary>
        /// マトリクス点灯のスレッド
        /// </summary>
        private void MatrixThreadProc()
        {
            usbRelay.setRelay((int)Relay.MATRIX, true);
            while (!is_finish_matrix_thread)
            {
                Thread.Sleep(100);
                matrix_thread_time -= 100;
                if (matrix_thread_time < 0) break;
            }
            usbRelay.setRelay((int)Relay.MATRIX, false);
        }
    }
}
