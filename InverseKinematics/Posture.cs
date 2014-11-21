using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace real_robot_battle
{
    public enum Part
    {
        LEFT_SHOULDER,
        LEFT_ELBOW,
        LEFT_HAND,
        RIGHT_SHOULDER,
        RIGHT_ELBOW,
        RIGHT_HAND,
    };

    public partial class Posture : PictureBox
    {        
        double[,] pos = new double[6,3];
        double[,] hand = new double[2, 3];
        Point p0 = new Point(150, 300);
        Point p1 = new Point(150, 200);
        Point p2 = new Point(400, 300);
        const double r = 150.0;
        
        public Posture()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void setPosition(double[,] p)
        {
            pos = (double[,])p.Clone();
        }

        public void setHandPosition(double[,] h)
        {
            hand = (double[,])h.Clone();
        }

        private void DrawCircle(Graphics g, Point c, int  r)
        {
            int x = c.X - r;
            int y = c.Y - r;

            g.DrawEllipse(Pens.Red, x, y, r * 2, r * 2);
        }

        private void Posture_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Point[] drawPos = new Point[10];
            Point org = new Point(-3, -3);
            for (int i = 0; i < 6; i++)
            {
                drawPos[i].X =  (int)(r * pos[i,1]) + p0.X;
                drawPos[i].Y = -(int)(r * pos[i,2]) + p0.Y;
            }
            drawPos[6].X = p0.X;
            drawPos[6].Y = p0.Y;
            drawPos[7].X = p0.X;
            drawPos[7].Y = -(int)(r * -0.5) + p0.Y;
            drawPos[8].X = (int)(r * hand[0, 1]) + p0.X;
            drawPos[8].Y = -(int)(r * hand[0, 2]) + p0.Y;
            drawPos[9].X = (int)(r * hand[1, 1]) + p0.X;
            drawPos[9].Y = -(int)(r * hand[1, 2]) + p0.Y;

            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_SHOULDER], drawPos[(int)Part.RIGHT_SHOULDER]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_SHOULDER], drawPos[(int)Part.LEFT_ELBOW]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_ELBOW], drawPos[(int)Part.LEFT_HAND]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.RIGHT_SHOULDER], drawPos[(int)Part.RIGHT_ELBOW]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.RIGHT_ELBOW], drawPos[(int)Part.RIGHT_HAND]);
            g.DrawLine(Pens.Black, drawPos[6], drawPos[7]);
            for (int i = 0; i < 7; i++)
            {
                DrawCircle(g, drawPos[i], 3);
            }
            DrawCircle(g, drawPos[8], 5);
            DrawCircle(g, drawPos[9], 5);
            
            for (int i = 0; i < 6; i++)
            {
                drawPos[i].X = (int)(r * pos[i, 1]) + p1.X;
                drawPos[i].Y = -(int)(r * pos[i, 0]) + p1.Y;
            }
            drawPos[6].X = p1.X;
            drawPos[6].Y = p1.Y;
            drawPos[8].X = (int)(r * hand[0, 1]) + p1.X;
            drawPos[8].Y = -(int)(r * hand[0, 0]) + p1.Y;
            drawPos[9].X = (int)(r * hand[1, 1]) + p1.X;
            drawPos[9].Y = -(int)(r * hand[1, 0]) + p1.Y;

            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_SHOULDER], drawPos[(int)Part.RIGHT_SHOULDER]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_SHOULDER], drawPos[(int)Part.LEFT_ELBOW]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_ELBOW], drawPos[(int)Part.LEFT_HAND]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.RIGHT_SHOULDER], drawPos[(int)Part.RIGHT_ELBOW]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.RIGHT_ELBOW], drawPos[(int)Part.RIGHT_HAND]);
            for (int i = 0; i < 7; i++)
            {
                DrawCircle(g, drawPos[i], 3);
            }
            DrawCircle(g, drawPos[8], 5);
            DrawCircle(g, drawPos[9], 5);
            
            for (int i = 0; i < 6; i++)
            {
                drawPos[i].X = (int)(r * pos[i, 0]) + p2.X;
                drawPos[i].Y = -(int)(r * pos[i, 2]) + p2.Y;
            }
            drawPos[6].X = p2.X;
            drawPos[6].Y = p2.Y;
            drawPos[7].X = p2.X;
            drawPos[7].Y = -(int)(r * -0.5) + p2.Y;
            drawPos[8].X = (int)(r * hand[0, 0]) + p2.X;
            drawPos[8].Y = -(int)(r * hand[0, 2]) + p2.Y;
            drawPos[9].X = (int)(r * hand[1, 0]) + p2.X;
            drawPos[9].Y = -(int)(r * hand[1, 2]) + p2.Y;

            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_SHOULDER], drawPos[(int)Part.RIGHT_SHOULDER]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_SHOULDER], drawPos[(int)Part.LEFT_ELBOW]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.LEFT_ELBOW], drawPos[(int)Part.LEFT_HAND]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.RIGHT_SHOULDER], drawPos[(int)Part.RIGHT_ELBOW]);
            g.DrawLine(Pens.Black, drawPos[(int)Part.RIGHT_ELBOW], drawPos[(int)Part.RIGHT_HAND]);
            g.DrawLine(Pens.Black, drawPos[6], drawPos[7]);
            for (int i = 0; i < 7; i++)
            {
                DrawCircle(g, drawPos[i], 3);
            }
            DrawCircle(g, drawPos[8], 5);
            DrawCircle(g, drawPos[9], 5);
        }
    }
}
