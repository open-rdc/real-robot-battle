using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using real_robot_battle;

namespace JoystickUDP
{
    public partial class Form1 : Form
    {
        const int port = 50000;
        Network network;
        Joystick joystick;
        
        // 送信するUDPのデータ
        struct UDPData
        {
            public sbyte x;
            public sbyte y;
            public sbyte z;
            public bool button0;
            public bool button1;
            public bool button2;
            public bool button3;
            public bool button4;
            public bool button5;
            public bool button6;
            public bool button7;
        };
        UDPData udpData;

        public Form1()
        {
            InitializeComponent();
            network = new Network();
            joystick = new Joystick();
            udpData = new UDPData();
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer100ms_Tick(object sender, EventArgs e)
        {
            if (joystick == null) return;
            if (!joystick.isAvailable) return;
            udpData.x = (sbyte)joystick.getLX();
            udpData.y = (sbyte)joystick.getLY();
            udpData.z = (sbyte)joystick.getRX();
            udpData.button0 = joystick.getButton(0);
            udpData.button1 = joystick.getButton(1);
            udpData.button2 = joystick.getButton(2);
            udpData.button3 = joystick.getButton(3);
            udpData.button4 = joystick.getButton(4);
            udpData.button5 = joystick.getButton(5);
            udpData.button6 = false;
            udpData.button7 = false;
            if (joystick.getT() < -50)
            {
                udpData.button6 = true;
            }
            else if (joystick.getT() > 50)
            {
                udpData.button7 = true;
            }

            textBoxX.Text = udpData.x.ToString();
            textBoxY.Text = udpData.y.ToString();
            textBoxZ.Text = udpData.z.ToString();
            if (udpData.button0)
            {
                textBoxButton0.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton0.BackColor = Color.White;
            }
            if (udpData.button1)
            {
                textBoxButton1.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton1.BackColor = Color.White;
            }
            if (udpData.button2)
            {
                textBoxButton2.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton2.BackColor = Color.White;
            }
            if (udpData.button3)
            {
                textBoxButton3.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton3.BackColor = Color.White;
            }
            if (udpData.button4)
            {
                textBoxButton4.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton4.BackColor = Color.White;
            }
            if (udpData.button5)
            {
                textBoxButton5.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton5.BackColor = Color.White;
            }
            if (udpData.button6)
            {
                textBoxButton6.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton6.BackColor = Color.White;
            }
            if (udpData.button7)
            {
                textBoxButton7.BackColor = Color.Pink;
            }
            else
            {
                textBoxButton7.BackColor = Color.White;
            }

            byte[] data = new byte[11];
            data[0] = (byte)udpData.x;
            data[1] = (byte)udpData.y;
            data[2] = (byte)udpData.z;
            data[3] = (udpData.button0) ? (byte)1 : (byte)0;
            data[4] = (udpData.button1) ? (byte)1 : (byte)0;
            data[5] = (udpData.button2) ? (byte)1 : (byte)0;
            data[6] = (udpData.button3) ? (byte)1 : (byte)0;
            data[7] = (udpData.button4) ? (byte)1 : (byte)0;
            data[8] = (udpData.button5) ? (byte)1 : (byte)0;
            data[9] = (udpData.button6) ? (byte)1 : (byte)0;
            data[10] = (udpData.button7) ? (byte)1 : (byte)0;
            network.Send(data);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            joystick.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBoxConnect.Checked = true;
        }

        private void checkBoxConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxConnect.Checked)
            {
                network.setBinary(true);
                network.Open(textBoxAddress.Text, port + 1, port);
            }
            else
            {
                network.Close();
            }
        }
    }
}
