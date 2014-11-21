using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;

namespace joystick
{
    public partial class Form1 : Form
    {
        Joystick joystick = new Joystick();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i;
            textBox1.Text = "LX = " + joystick.getLX().ToString() + "\r\n";
            textBox1.Text += "LY = " + joystick.getLY().ToString() + "\r\n";
            textBox1.Text += "RX = " + joystick.getRX().ToString() + "\r\n";
            textBox1.Text += "RY = " + joystick.getRY().ToString() + "\r\n";
            textBox1.Text += "T = " + joystick.getT().ToString() + "\r\n";
            for(i=0;i<10;++i){
                textBox1.Text += "button " + (i + 1) + " " + joystick.getButton(i).ToString() + "\r\n";
            }
        }
    }
}
