using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;

namespace mechanum
{
    public partial class Form1 : Form
    {
        int x, y;
        RRBSerial serial;
        Mechanum mechanum;

        public Form1()
        {
            InitializeComponent();
            serial = new RRBSerial();
            serial.Open("COM1");
            mechanum = new Mechanum();
            mechanum.setSerialPort(serial);
            serial.sendMaxTorque(0xff, 1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point sp = Cursor.Position;
            Point cp = this.PointToClient(sp);
            x =   cp.X - this.Width  / 2 ;
            y = -(cp.Y - this.Height / 2);
            mechanum.setSpeed(x * 1, y * 1, 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mechanum.Close();
        }
    }
}
