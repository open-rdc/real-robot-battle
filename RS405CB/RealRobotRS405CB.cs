using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using real_robot_battle;

namespace real_robot_battle
{
    /// <summary>
    /// リアルロボットバトル用RS405CBの制御
    /// </summary>
    public class RealRobotRS405CB
    {
        const string port_name = "COM2";    // ポート名はCOM2に固定

        /// <summary>
        /// モータのID
        /// </summary>
        public enum ID
        {
            right_front = 8,
            left_front = 7,
            left_shoulder = 4,
            right_shoulder = 5,
            bumper = 11,
            right_waist = 16,
            left_waist = 20,
            head_up = 43,
            tilt_angle = 23,
			right_launcher = 37,
            left_launcher = 3,
            right_handneck = 46,
            left_handneck = 45,
			waist_attach = 19,
			right_hand_attach = 41,
        }
		
        enum para
        {
            right_front_init=-11,
            left_front_init=-35,
            right_shoulder_init=-53,
            left_shoulder_init=90,
            bumper_init=-85,
            right_waist_init,
            left_waist_init,
            right_handneck_init=-110,
            left_handneck_init=126,
            
        }

		
        public static bool headisup = true;
        const float trancesec = 5.0f;
		
        RS405CB rs405cb;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RealRobotRS405CB()
        {
            rs405cb = new RS405CB();
            rs405cb.Open(port_name);
            Initialize();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            allservoOn(true);
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Close()
        {
            allservoOn(false);
            rs405cb.Close();
        }

        /// <summary>
        /// すべてのサーボのON/OFF
        /// </summary>
        /// <param name="is_on">true:on false:off</param>
        public void allservoOn(bool is_on)
        {
            if (is_on == true)
            {
                for (byte i = 0; i < 100; ++i)
                {
                    rs405cb.ServoOn(i, true);
                }
            }
            else
            {
                for (byte i = 0; i < 100; ++i)
                {
                   rs405cb.ServoOn(i, false);
                }
            }
        }

        /// <summary>
        /// サーボのON/OFF
        /// </summary>
        /// <param name="id">モータのID</param>
        /// <param name="is_on">true:ON, false:OFF</param>
        public void servoOn(byte id, bool is_on)
        {
            rs405cb.ServoOn(id, is_on);
        }

        /// <summary>
        /// 胸のドアの開閉
        /// </summary>
        /// <param name="is_open">true:open, false:close</param>
        public void FrontOpen(bool is_open)
        {
            servoOn((byte)ID.right_front, true);
            servoOn((byte)ID.left_front, true);
            if (is_open == true)
            {
                rs405cb.setAngle((byte)ID.right_front, (float)(para.right_front_init+145), trancesec);
                rs405cb.setAngle((byte)ID.left_front, (float)(para.left_front_init-145), trancesec);
                //rs405cb.setAngle((byte)ID.left_front, -31, trancesec);
                //rs405cb.setAngle((byte)ID.right_front, 144, trancesec);
            }
            else
            {
                rs405cb.setAngle((byte)ID.right_front, (float)(para.right_front_init), trancesec);
                rs405cb.setAngle((byte)ID.left_front, (float)para.left_front_init, trancesec);
                //rs405cb.setAngle((byte)ID.left_front, 110, trancesec);
                //rs405cb.setAngle((byte)ID.right_front, -11, trancesec);
            }
        }

		/// <summary>
		/// 肩の開閉
		/// </summary>
		/// <param name="robot_form">true:robot_form, false:truck_form</param>
        public void ShoulderExpand(bool robot_form)
        {
            servoOn((byte)ID.left_shoulder, true);
            servoOn((byte)ID.right_shoulder, true);
            if (robot_form == true)
            {
                rs405cb.setAngle((byte)ID.right_shoulder,(float)(para.right_shoulder_init+150), trancesec);
                rs405cb.setAngle((byte)ID.left_shoulder,(float)(para.left_shoulder_init-170), trancesec);
                //rs405cb.setAngle((byte)ID.right_shoulder, 101, trancesec);
                //rs405cb.setAngle((byte)ID.left_shoulder, -82, trancesec);
            }
            else
            {
                rs405cb.setAngle((byte)ID.right_shoulder, (float)para.right_shoulder_init, trancesec);
                rs405cb.setAngle((byte)ID.left_shoulder, (float)para.left_shoulder_init, trancesec);
                //rs405cb.setAngle((byte)ID.right_shoulder, -53, trancesec);
                //rs405cb.setAngle((byte)ID.left_shoulder, 90, trancesec);
            }
        }

		/// <summary>
		/// 横の腰の上下
		/// </summary>
		/// <param name="robot_form">true:robot_form, false:truck_form</param>
        public void SideWheelHide(bool robot_form)
        {
            servoOn((byte)ID.right_waist, true);
            servoOn((byte)ID.left_waist, true);
            if (robot_form == true)
            {
                rs405cb.setAngle((byte)ID.right_waist, (float)para.right_waist_init, trancesec);
                rs405cb.setAngle((byte)ID.left_waist, (float)para.left_waist_init, trancesec);
                //rs405cb.setAngle((byte)ID.right_waist, 85, trancesec);
                //rs405cb.setAngle((byte)ID.left_waist, 90, trancesec);
            }
            else
            {
                rs405cb.setAngle((byte)ID.right_waist, (float)para.right_waist_init, trancesec);
                rs405cb.setAngle((byte)ID.left_waist, (float)para.left_waist_init, trancesec);
                //rs405cb.setAngle((byte)ID.waist_right, 117, trancesec);
                //rs405cb.setAngle((byte)ID.left_waist, -128, trancesec);
            }
        }

        public void Midstream_SideWheelHide()
        {
            servoOn((byte)ID.right_waist, true);
            servoOn((byte)ID.left_waist, true);
            rs405cb.setAngle((byte)ID.right_waist, (float)(para.right_waist_init), trancesec);
            rs405cb.setAngle((byte)ID.left_waist, (float)(para.left_waist_init), trancesec);
        }

		/// <summary>
		/// 正面のバンパーの上下
		/// </summary>
		/// <param name="robot_form">true:robot_form, false:truck_form</param>
        public void BumperHide(bool robot_form)
        {
            servoOn((byte)ID.bumper, true);
            if (robot_form == true)
            {
                rs405cb.setAngle((byte)ID.bumper, (float)(para.bumper_init+180), trancesec);
                //rs405cb.setAngle((byte)ID.bumper, 95, trancesec);
            }
            else
            {
                rs405cb.setAngle((byte)ID.bumper, (float)para.bumper_init, trancesec);
                //rs405cb.setAngle((byte)ID.bumper, -83, trancesec);
            }
        }

		/// <summary>
		/// 頭の上下
		/// </summary>
		/// <param name="robot_form">true:robot_form, false:truck_form</param>
        public void HeadUp(bool robot_form)
        {
            servoOn((byte)ID.head_up, true);    //ポテンショは91度
            if (robot_form == true)
            {
                Thread.Sleep(1000);
                rs405cb.setAngle((byte)ID.head_up, 85, trancesec);     //91-で上方向に回転
                Thread.Sleep(8500);
                servoOn((byte)ID.head_up, false);
                Thread.Sleep(100);
                servoOn((byte)ID.head_up, true);
            }
            else
            {
                Thread.Sleep(500);
                rs405cb.setAngle((byte)ID.head_up, 103, trancesec);     //91+で下方向に回転
                Thread.Sleep(6000);
                servoOn((byte)ID.head_up, false);
                Thread.Sleep(100);
                servoOn((byte)ID.head_up, true);
            }
        }

		/// <summary>
		/// 首の角度の調整
		/// </summary>
		/// <param name="Angle">首の角度(deg)</param>
        public void TiltAngle(int Angle, int time)
        {
            servoOn((byte)ID.tilt_angle, true);
            rs405cb.setAngle((byte)ID.tilt_angle, Angle, time);
        }

		/// <summary>
		/// モスカートキャノンの発射
		/// </summary>
        public void Launcher()
        {
            servoOn((byte)ID.left_launcher, true);
            servoOn((byte)ID.right_launcher, true);
            rs405cb.setAngle((byte)ID.left_launcher, 30, 0);    //左のランチャー
            Thread.Sleep(500);
            rs405cb.setAngle((byte)ID.left_launcher, -7, 0);
            Thread.Sleep(500);
            rs405cb.setAngle((byte)ID.right_launcher, -111, 0);  //右のランチャー
            Thread.Sleep(500);
            rs405cb.setAngle((byte)ID.right_launcher, -95, 0);
            Thread.Sleep(500);
            servoOn((byte)ID.left_launcher, false);
            servoOn((byte)ID.right_launcher, false);
        }

		/// <summary>
		/// 手首の出し入れ
		/// </summary>
		/// <param name="robot_form">true:robot_form, false:truck_form</param>
        public void HandNeck(bool robot_form)
        {
			servoOn((byte)ID.right_handneck, true);
            servoOn((byte)ID.left_handneck, true);
            if (robot_form == true)
            {
                rs405cb.setAngle((byte)ID.right_handneck, (float)(para.right_handneck_init + 170), trancesec);
                rs405cb.setAngle((byte)ID.left_handneck, (float)(para.left_handneck_init - 170), trancesec);
                //rs405cb.setAngle((byte)ID.right_handneck, 64, trancesec);
                //rs405cb.setAngle((byte)ID.left_handneck, -54, trancesec);
            }
            else
            {
                rs405cb.setAngle((byte)ID.right_handneck, (float)para.right_handneck_init, trancesec);
                rs405cb.setAngle((byte)ID.left_handneck, (float)para.left_handneck_init, trancesec);
                //rs405cb.setAngle((byte)ID.right_handneck, -110, trancesec);
                //rs405cb.setAngle((byte)ID.left_handneck, 126, trancesec);
            }
        }

		/// <summary>
		/// 手の方の脱着機構
		/// </summary>
		/// <param name="is_hold">is_hold:着 false:脱</param>
        public void HandHold(bool is_hold)
        {
            if (is_hold == true)
            {
            }
            else
            {
            }
        }

		/// <summary>
		/// 腰の方の脱着機構	
		/// </summary>
		/// <param name="is_hold">true:着 false:脱</param>
        public void WaistHold(bool is_hold)
        {
            if (is_hold == true)
            {
            }
            else
            {
            }
        }

		/// <summary>
		/// 頭を上げるときのスレッド用関数
		/// </summary>
        public void HeadThread_up()
        {
            HeadUp(true);
        }

		/// <summary>
		/// 頭を下げるときのスレッド用関数
		/// </summary>
        public void HeadThread_down()
        {
            HeadUp(false);
        }

		/// <summary>
		/// ランチャーのスレッド用関数
		/// </summary>
        public void LauncherThread()
        {
            Launcher();
        }

    }
}
