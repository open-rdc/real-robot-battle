using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;

namespace real_robot_battle
{
    public class Joystick
    {
        private Device joystick = null;
        private string name;
        private Thread thread;
        private bool is_finish;
        private JoystickState state;
        const int MAX_VALUE = 65535;
        const int DEAD_ZONE = 10;
        const float COEF = (float)(100 + DEAD_ZONE) / (MAX_VALUE / 2);
        public bool isAvailable = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Joystick()
        {
            DeviceList devList;

            try
            {
                // ゲームコントローラのデバイス一覧を取得
                devList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);

                // 全てのコントローラを列挙
                foreach (DeviceInstance dev in devList)
                {
                    joystick = new Device(dev.InstanceGuid);
                    // 最初に見つかったジョイスティックを操作対象とする
                    break;
                }

                joystick.SetDataFormat(DeviceDataFormat.Joystick);

                // デバイスに対するアクセス権をとる
                joystick.Acquire();
                name = joystick.DeviceInformation.ProductName;

                is_finish = false;
                thread = new Thread(new ThreadStart(ThreadProc));
                thread.Start();
                isAvailable = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Joystickが接続されていません");
            }
        }

        public void Close()
        {
            is_finish = true;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~Joystick()
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// 不感帯を踏まえた値の整形
        /// </summary>
        /// <param name="value">元の値</param>
        /// <param name="dead_zone">不感帯の値（正の値）</param>
        /// <returns>整形した値</returns>
        private float getValue(float value, float dead_zone)
        {
            if (value > dead_zone)
            {
                value -= dead_zone;
            }
            else if (value < -dead_zone)
            {
                value += dead_zone;
            }
            else
            {
                value = 0;
            }
            return value;
        }

        /// <summary>
        /// 傾きの取得
        /// </summary>
        /// <returns>左のx方向の傾き(-100～100)</returns>
        public float getLX()
        {
            float lx = 0;
            if (joystick != null)
            {
                lx = (state.X - MAX_VALUE / 2) * COEF;
            }
            return getValue(lx, DEAD_ZONE);
        }

        /// <summary>
        /// 傾きの取得
        /// </summary>
        /// <returns>左のy方向の傾き(-100～100)</returns>
        public float getLY()
        {
            float ly = 0;
            if (joystick != null)
            {
                ly = -(state.Y - MAX_VALUE / 2) * COEF;
            }
            return getValue(ly, DEAD_ZONE);
        }

        /// <summary>
        /// 傾きの取得
        /// </summary>
        /// <returns>右のx方向の傾き(-100～100)</returns>
        public float getRX()
        {
            float rx = 0;
            if (joystick != null)
            {
                rx = (state.Rx - MAX_VALUE / 2) * COEF;
            }
            return getValue(rx, DEAD_ZONE);
        }

        /// <summary>
        /// 傾きの取得
        /// </summary>
        /// <returns>右のy方向の傾き(-100～100)</returns>
        public float getRY()
        {
            float ry = 0;
            if (joystick != null)
            {
                ry = -(state.Ry - MAX_VALUE / 2) * COEF;
            }
            return getValue(ry, DEAD_ZONE);
        }

        /// <summary>
        /// 傾きの取得
        /// </summary>
        /// <returns>Tの傾き(-100～100)</returns>
        public float getT()
        {
            float t = 0;
            if (joystick != null)
            {
                t = -(state.Z - MAX_VALUE / 2) * COEF;
            }
            return getValue(t, DEAD_ZONE);
        }

        /// <summary>
        /// ボタンの取得
        /// </summary>
        /// <param name="no">ボタンの番号</param>
        /// <returns>true:押されている，false:押されていない</returns>
        public bool getButton(int no)
        {

            byte res = 0;
            try
            {
                res = state.GetButtons()[no];
            }
            catch (Exception e) { }

            if (res == 0) return false;
            return true;
        }
        
        /// <summary>
        /// 処理ループ
        /// </summary>
        private void ThreadProc()
        {
            while (!is_finish)
            {
                // デバイス未決定時は何もしない
                if (joystick == null)
                {
                    return;
                }

                try
                {
                    // コントローラの状態をポーリングで取得
                    if (isAvailable)
                    {
                        joystick.Poll();
                        state = joystick.CurrentJoystickState;
                    }
                }
                catch (Exception)
                {
                }
                Thread.Sleep(50);         // 監視する周期
            }
        }
    }
}
