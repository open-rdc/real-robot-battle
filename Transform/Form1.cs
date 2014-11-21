using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using real_robot_battle;
using System.Threading;

namespace Transform
{
    public partial class Form1 : Form
    {
        const string RRBservo_port = "COM1";
        MotionControl motionControl;
        Joystick joystick;
        Mechanum mechanum;
        RRBSerial serial;
        Sound sound;
        RealRobotRS405CB rs;
        RealRobotRelay relay;
        private Thread threadTF = null;
        private Thread threadSetTF = null;
//        private Thread threadButton0 = null;
//        private Thread threadButton1 = null;
        private Thread threadButtonFrontLight = null;
        private Thread threadButtonSholderSmoke = null;
        private Thread threadButtonMatrixLight = null;
        private Thread threadButtonDoorOpen = null;
        private Thread threadButtonHeadLight = null;
        bool front = true;
        bool light = true;
        bool H_light = true;
        bool but0 = true;
        bool but1 = true;
        bool but2 = true;
        bool but3 = true;
        bool but4 = true;
        bool but5 = true;

        int selectedSequence = 0;
        bool isExecute = false;
        bool isPlay = false;
        Network network;
        const int port = 50000;

        public Form1()
        {
            InitializeComponent();
            serial = new RRBSerial();
            serial.Open(RRBservo_port);
            mechanum = new Mechanum();
            mechanum.setSerialPort(serial);
            motionControl = new MotionControl();
            motionControl.setSerialPort(serial);
            motionControl.readOffsetAngle();
            sound = new Sound();
            joystick = new Joystick();
            rs = new RealRobotRS405CB();
            relay = new RealRobotRelay();
            network = new Network();
            network.setBinary(true);                // データをバイナリ形式で送信
            network.Open("localhost", port, port);  // 通信ポートのオープン

            timer1.Start();

            comboBoxSquence.SelectedIndex = 0;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            joystick.Close();
            motionControl.Close();
            mechanum.Close();
            network.Close();
            rs.Close();
            relay.Close();
        }
        
        /// <summary>
        /// トランスフォームキーを押した場合
        /// </summary>
        private void Transform_Click(object sender, EventArgs e)
        {
            threadTF = new Thread(new ThreadStart(ThreadTransform));
            threadTF.Start();
        }

        /// <summary>
        /// 周期的(100ms)に実行する処理
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            int t = 0;
            
            if (joystick.isAvailable)
            {
                x = (int)joystick.getLX();
                y = (int)joystick.getLY();
                z = (int)joystick.getRX();
                t = (int)joystick.getT();
            }
            else
            {
                // UDP通信を用いてデータを受信する．
                byte[] data;
                data = network.RecvBinary();
                if (data.Length == 11)
                {
                    x = (sbyte)data[0];
                    y = (sbyte)data[1];
                    z = (sbyte)data[2];
                }
            }
            textBoxX.Text = (-y).ToString();
            textBoxY.Text = x.ToString();
            textBoxZ.Text = z.ToString();
            int C = 5;    //ジョイパッド（0~100）* C(1~10)　C:最大出力値（1~50%） 
            
            // メカナムホイールの処理
            if (!checkBoxBrake.Checked)
            {
                mechanum.setSpeed(-y * C, x * C, z * C);        // メカナムホイールは前が+x,左が+y，時計回りに+z
            }
            else
            {
                mechanum.Stop();
            }
            if (!checkBoxLiftLock.Checked)
            {
                //RTでDown,LTでUp
                motionControl.Lift(t * 10); //(-99~99)
            }
            else
            {
                serial.sendPWM((byte)12, 0);
                serial.sendPWM((byte)13, 0);
            }

            // ジョイスティックのボタンに対する処理
            /*
            if (joystick.getButton(0))
            {
                threadButton0 = new Thread(new ThreadStart(ThreadBut0));
                threadButton0.Start();
            }

            if (joystick.getButton(1))
            {
                threadButton1 = new Thread(new ThreadStart(ThreadBut1));
                threadButton1.Start();
            }
            */

            if (joystick.getButton(2))      // フロントライト
            {
                if (but2 == true)
                {
                    threadButtonFrontLight = new Thread(new ThreadStart(ThreadFrontLight));
                    threadButtonFrontLight.Start();
                }
            }

            if (joystick.getButton(3))      // 
            {
                if (but3 == true)
                {
                    threadButtonSholderSmoke = new Thread(new ThreadStart(ThreadSholderSmoke));
                    threadButtonSholderSmoke.Start();
                }
            }

            if (joystick.getButton(4))
            {
                if (but4 == true)
                {
                    threadButtonMatrixLight = new Thread(new ThreadStart(ThreadMatrixLight));
                    threadButtonMatrixLight.Start();
                }
            }

            if (joystick.getButton(5))
            {
                if (but5 == true)
                {
                    threadButtonDoorOpen = new Thread(new ThreadStart(ThreadDoorOpen));
                    threadButtonDoorOpen.Start();
                }
            }

        }
        private void ThreadTransform()
        {

            //効果音，蒸気
//            sound.Play("..\\..\\01.wav");//定番のBGM
            relay.setShoulderSmoke(1000, true);
            Thread.Sleep(1100);
//            sound.Play("..\\..\\TF.wav");//トランスフォーーーム

            //前輪を傾かせる（接触対策）
//            if (checkBoxFUTABAservoON.Checked)
//            {
//                rs.Midstream_SideWheelHide();
//            }

            //上半身が上がり始める．
            //ジョイパッドTで操作する


            //肩が外に出始める．
            if (checkBoxFUTABAservoON.Checked)
            {
                rs.ShoulderExpand(true);
            }
            Thread.Sleep(5000);
             

            //手先が回転，ライトからハンド
            if (checkBoxFUTABAservoON.Checked)
            {
                rs.HandNeck(true);
            }


            //前のバンパーが回転
            if (checkBoxFUTABAservoON.Checked)
            {
                rs.BumperHide(true);
            }
             

            Thread.Sleep(5000);
            //完全に肩が出たら，脇をあける
//            if (checkBoxRRBservoON.Checked)
//            {
//                motionControl.playMotion("..\\..\\motion1.csv");
//            }

//            Thread.Sleep(1500);
//            //前輪をロール軸に回転して収納
//            if (checkBoxFUTABAservoON.Checked)
//            {
//                rs.SideWheelHide(true);
//            }

            //頭を出す
            if (checkBoxFUTABAservoON.Checked)
            {
                rs.HeadThread_up();
            }
            

            Thread.Sleep(8300);
            //目を光らせて，何か喋らせる．
//            sound.Play("..\\..\\Myname.wav");//私が司令官オプティマスプライム
            relay.setHeadLight(true);
            Thread.Sleep(2100);
            
            Thread.Sleep(1000);
            //蒸気，ポージング
//            if (checkBoxRRBservoON.Checked)
//            {
//                sound.Play("..\\..\\Tojyo-03.wav");//
//                motionControl.playMotion("..\\..\\motion2.csv");
//                relay.setShoulderSmoke(2000,true);
//            }
        }

        private void checkBoxRRBservoON_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn(checkBoxRRBservoON.Checked);
        }

        /*
        private void ThreadBut0()
        {
            sound.Play("..\\..\\06.wav");
        }
        private void ThreadBut1()
        {
            sound.Play("..\\..\\05a.wav");
        }
         * */

        /// <summary>
        /// フロントライトの点灯
        /// </summary>
        private void ThreadFrontLight()
        {
            but2 = false;
            if (light == true)
            {
                relay.setFrontLight(true);
                light = false;
            }
            else
            {
                relay.setFrontLight(false);
                light = true;
            }
            Thread.Sleep(1000);
            but2 = true;
        }

        /// <summary>
        /// ヘッドライトの点灯
        /// </summary>
        private void ThreadHeadLight()
        {
            if (H_light == true)
            {
                relay.setHeadLight(true);
                H_light = false;
            }
            else
            {
                relay.setHeadLight(false);
                H_light = true;
            }
            Thread.Sleep(1000);
        }

        /// <summary>
        /// ショルダーのスモークを出す
        /// </summary>
        private void ThreadSholderSmoke()
        {
            but3 = false;
            relay.setShoulderSmoke(2000, true);
            Thread.Sleep(2100);
            but3 = true;
        }

        /// <summary>
        /// マトリクスのライトを付ける．
        /// </summary>
        private void ThreadMatrixLight()
        {
            but4 = false;
            relay.setMatrixLight(5000, true);
            Thread.Sleep(5100);
            but4 = true;
        }

        /// <summary>
        /// フロントドアのオープン
        /// </summary>
        private void ThreadDoorOpen()
        {
            but5 = false;
            if (front == true)
            {
                rs.FrontOpen(true);
                front = false;
            }
            else
            {
                rs.FrontOpen(false);
                front = true;
            }
            Thread.Sleep(1000);
            but5 = true;
        }

        /// <summary>
        /// 情けないトランスフォーム
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            threadSetTF = new Thread(new ThreadStart(ThreadSetTransform));
            threadSetTF.Start();
        }
        private void ThreadSetTransform()
        {
                        relay.setFrontLight(true);
                        Thread.Sleep(1000);            
            relay.setShoulderSmoke(1000, true);
            Thread.Sleep(1000);
                        rs.BumperHide(true);
                        rs.ShoulderExpand(true);
                        Thread.Sleep(3000);
                        rs.HandNeck(true);
                        relay.setFrontLight(false);
                        rs.HeadThread_up();
                        Thread.Sleep(3000);
                        relay.setHeadLight(true);
                        Thread.Sleep(1000);
                        relay.setShoulderSmoke(1000, true);        
        }
    
        /// <summary>
        /// ESCAPEキーを受け付ける
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                motionControl.servoOn(false);
                checkBoxRRBservoON.Checked = false;
                rs.allservoOn(false);
                checkBoxFUTABAservoON.Checked = false;
                MessageBox.Show("全てのサーボを停止しました");
            }
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            selectedSequence = comboBoxSquence.SelectedIndex;
            if (comboBoxSquence.SelectedIndex < (comboBoxSquence.Items.Count - 1))
            comboBoxSquence.SelectedIndex++;
            isExecute = true;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            motionControl.Lift(30);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            motionControl.Lift(-30);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            selectedSequence = comboBoxSquence.SelectedIndex;
            isPlay = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            isPlay = false;
            isExecute = false;
        }

        enum Sequence
        {
            HEAD_LIGHT,
            FORWARD,
            STEAM,
            LIFT,
            BUMPER,
            SHOULDER,
            HAND,
            HEAD,
            EYE_LIGHT,
            STEAM2,
            MOVE,
            POSE,
        };

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isExecute)
            {
                switch (selectedSequence)
                {
                    case (int)Sequence.HEAD_LIGHT:
                        relay.setFrontLight(true);
                        selectedSequence++;
                        break;
                    case (int)Sequence.FORWARD:
                        break;
                    case (int)Sequence.STEAM:
                        relay.setShoulderSmoke(500, true);
                        break;
                    case (int)Sequence.LIFT:
                        break;
                    case (int)Sequence.BUMPER:
                        rs.BumperHide(true);
                        break;
                    case (int)Sequence.SHOULDER:
                        rs.ShoulderExpand(true);
                        break;
                    case (int)Sequence.HAND:
                        rs.HandNeck(true);
                        relay.setFrontLight(false);
                        break;
                    case (int)Sequence.HEAD:
                        rs.HeadThread_up();
                        break;
                    case (int)Sequence.EYE_LIGHT:
                        relay.setHeadLight(true);
                        break;
                    case (int)Sequence.STEAM2:
                        relay.setShoulderSmoke(500, true);
                        break;
                    case (int)Sequence.MOVE:
                        break;
                    case (int)Sequence.POSE:
                        break;
                }
            }
            isExecute = false;
        }

        private void Frontlight_Click(object sender, EventArgs e)
        {
            if (but2 == true)
            {
                threadButtonFrontLight = new Thread(new ThreadStart(ThreadFrontLight));
                threadButtonFrontLight.Start();
            }
        }

        private void Matrix_Click(object sender, EventArgs e)
        {
            if (but4 == true)
            {
                threadButtonMatrixLight = new Thread(new ThreadStart(ThreadMatrixLight));
                threadButtonMatrixLight.Start();
            }
        }

        private void Smoke_Click(object sender, EventArgs e)
        {
            if (but3 == true)
            {
                threadButtonSholderSmoke = new Thread(new ThreadStart(ThreadSholderSmoke));
                threadButtonSholderSmoke.Start();
            }
        }

        private void HeadLight_Click(object sender, EventArgs e)
        {
            threadButtonHeadLight = new Thread(new ThreadStart(ThreadHeadLight));
            threadButtonHeadLight.Start();
        }

        private void checkBoxFUTABAservoON_CheckedChanged(object sender, EventArgs e)
        {
            rs.allservoOn(checkBoxFUTABAservoON.Checked);
        }

    }
}
