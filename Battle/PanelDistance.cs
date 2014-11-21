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
    public partial class PanelDistance : Panel
    {
        float distance = 1.0f;

        public PanelDistance()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public void setDistance(float distance)
        {
            this.distance = distance;
        }

        private void PanelDistance_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int h = (int)(Height * (5.0f - distance) / 5.0f);
            g.FillRectangle(Brushes.Red, 0, h - 10, Width, 20);

            Font font = new Font("optimus", 10);
            string str = ((int)(distance * 1000)).ToString();
            g.DrawString(str, font, Brushes.White, 0, h - 10);
        }
    }
}
