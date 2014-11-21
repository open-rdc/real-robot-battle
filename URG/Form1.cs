using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using real_robot_battle;

namespace urg
{
    public partial class Form1 : Form
    {
        URG urg = new URG();
        float[] distance = new float[0];

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            distance = urg.getData();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            System.Diagnostics.Debug.WriteLine(distance.Count());
            int cx = Width/2;
            int cy = 10;
            
            for (int i = 0; i < distance.Count(); i++)
            {
                g.DrawLine(Pens.Black, cx, cy, (float)(distance[i] * 50 * Math.Cos(Math.PI - Math.PI * i / 240) + cx), (float)(distance[i] * 50 * Math.Sin(Math.PI - Math.PI * i / 240) + cy));
            }

            float ex = urg.getEnemyX();
            float ey = urg.getEnemyY();
            g.FillEllipse(Brushes.Red, -50 * ey + cx - 20, 50 * ex + cy - 20, 40, 40);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            urg.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
