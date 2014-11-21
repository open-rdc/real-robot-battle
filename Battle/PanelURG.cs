using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Battle
{
    public partial class PanelURG : Panel
    {
        float[] distance = new float[0];
        float enemy_x = 0, enemy_y = 0;

        public PanelURG()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public void setDistance(float[] distance)
        {
            this.distance = distance;
        }

        public void setEnemy(float enemy_x, float enemy_y)
        {
            this.enemy_x = enemy_x;
            this.enemy_y = enemy_y;
        }

        private void PanelURG_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            const float ratio = 50.0f;
            System.Diagnostics.Debug.WriteLine(distance.Count());
            int cx = Width / 2;
            int cy = Height;

            for (int i = 0; i < distance.Count(); i++)
            {
                g.DrawLine(Pens.Black, cx, cy, (float)(distance[i] * ratio * Math.Cos(Math.PI - Math.PI * i / 240) + cx), -(float)(distance[i] * ratio * Math.Sin(Math.PI - Math.PI * i / 240)) + cy);
            }

            g.FillEllipse(Brushes.Red, -ratio * enemy_y + cx - 20, -ratio * enemy_x + cy - 20, 40, 40);
        }
    }
}
