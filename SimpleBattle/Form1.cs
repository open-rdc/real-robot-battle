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

namespace SimpleBattle
{
    public partial class Form1 : Form
    {
        const string port_name = "COM1";
        Joystick joystick;
        RRBSerial serial;
        Mechanum mechanum;
        MotionControl motionControl;
        Sound sound;

        public Form1()
        {
            InitializeComponent();
            joystick = new Joystick();
            serial = new RRBSerial();
            serial.Open(port_name);
            mechanum = new Mechanum();
            mechanum.setSerialPort(serial);
            motionControl = new MotionControl();
            motionControl.setSerialPort(serial);
            motionControl.readOffsetAngle();
            sound = new Sound();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = (int)joystick.getLX();
            int y = (int)joystick.getLY();
            int z = (int)joystick.getRX();
            int C = 10;    //ジョイパッド（0~100）* C(1~10)　C:最大出力値（1~100%） 

            textBoxX.Text = x.ToString();
            textBoxY.Text = y.ToString();
            textBoxZ.Text = z.ToString();
            if (!checkBoxBrake.Checked)
            {
                mechanum.setSpeed(-y * C, x * C, z * C);        // メカナムホイールは前が+x,左が+y，時計回りに+z
            }
            else
            {
                mechanum.Stop();
            }

            if (!motionControl.IsMotionPlay())
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
            }
            
            if (joystick.getButton(0))
            {
                textBox1.BackColor = Color.LightPink;
                if (checkBoxServoOn.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\motion1.csv");
                }
                sound.Play("..\\..\\1.wav");
            }

            if (joystick.getButton(1))
            {
                textBox2.BackColor = Color.LightPink;
                if (checkBoxServoOn.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\motion1.csv");
                }
                sound.Play("..\\..\\2.wav");
            }

            if (joystick.getButton(2))
            {
                textBox3.BackColor = Color.LightPink;
                if (checkBoxServoOn.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\motion1.csv");
                }
                sound.Play("..\\..\\3.wav");
            }

            if (joystick.getButton(3))
            {
                textBox4.BackColor = Color.LightPink;
                if (checkBoxServoOn.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\motion1.csv");
                }
                sound.Play("..\\..\\4.wav");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            joystick.Close();
            motionControl.Close();
            mechanum.Close();       // こちらでシリアルもクローズ（変更した方が良いかも）
        }

        /// <summary>
        /// ESCAPEキーを受け付ける
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                checkBoxBrake.Checked = true;
                MessageBox.Show("全てのサーボを停止しました");
            }
        }

        private void checkBoxServoOn_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn(checkBoxServoOn.Checked);
            checkBoxTestMode.Checked = true;
        }

        private void buttonFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MOTIONファイル(*.csv) | *.csv";
            ofd.Title = "開く MOTIONファイルを選択して下さい";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxFilename.Text = ofd.FileName;
            }
        }


        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (checkBoxServoOn.Checked && (!motionControl.IsMotionPlay()))
            {
                motionControl.readMotionData(textBoxFilename.Text);
                motionControl.playMotion();
            }
        }

        private void checkBoxTestMode_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.setTestMode(checkBoxTestMode.Checked);
        }
    }
}