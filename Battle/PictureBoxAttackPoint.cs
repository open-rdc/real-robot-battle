using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Battle
{
    public partial class PictureBoxAttackPoint : PictureBox
    {
        const float limit_low = 800;        // 写真の一番低い値(800mm)
        const float limit_high = 2200;      // 写真の一番高い値(2200mm)
        float limit_left;
        int x;
        int y;
        int radius;
        private Thread thread = null;
        bool isTerminate;
        int attack_x;
        int attack_y;
        bool is_attack;
        float ratio;
        int real_x;
        int real_y;
        bool nowAttack;
        
        public PictureBoxAttackPoint()
        {
            InitializeComponent();
            isTerminate = false;
            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();
        }

        public void Initialize()
        {
            x = 0;
            y = 0;
            radius = 4;
            attack_x = Width/2;
            attack_y = Height/2;
            is_attack = false;
            ratio = (limit_high - limit_low) / Height;  // 係数　写真の高さ　→　実際の高さ(mm)
            limit_left = - Width / 2 * ratio;
            real_x = 0;
            real_y = 0;
        }

        ~PictureBoxAttackPoint()
        {
        }

        private void calcRealPosition(int x, int y, out int real_x, out int real_y)
        {
            real_x = (int)(limit_left + ratio * x);
            real_y = (int)(limit_high - ratio * y);
        }

        private void PictureBoxAttackPoint_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            if (e.Button == MouseButtons.Left)
            {
                attack_x = x;
                attack_y = y;
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;

            if (is_attack)
            {
                int r = radius;
                g.DrawEllipse(Pens.Red, attack_x - r, attack_y - r, r * 2, r * 2);
                r--;
                g.DrawEllipse(Pens.Blue, attack_x - r, attack_y - r, r * 2, r * 2);
                r--;
                g.DrawEllipse(Pens.Yellow, attack_x - r, attack_y - r, r * 2, r * 2);
            }

            calcRealPosition(x, y, out real_x, out real_y);
            string str = String.Format("({0},{1})", real_x, real_y);
            Font font = new Font("optimus", 12);
            g.DrawString(str, font, Brushes.Black, Math.Min(x,Width - 80), Math.Min(y, Height - 20));
            g.DrawString(str, font, Brushes.Yellow, Math.Min(x, Width - 80) - 2, Math.Min(y, Height - 20) - 2);
        }

        private void ThreadProc()
        {
            while (!isTerminate)
            {
                if (is_attack)
                {
                    radius += 2;
                    if (radius > 20) radius = 4;
                }
                Invalidate();
                Thread.Sleep(100);
            }
        }

        public bool isAttack()
        {
            return is_attack;
        }

        /// <summary>
        /// 攻撃するポイントの指定
        /// </summary>
        /// <returns>横方向の位置(mm)</returns>
        public int getAttackX()
        {
            calcRealPosition(attack_x, attack_y, out real_x, out real_y);
            return real_x;
        }

        /// <summary>
        /// 攻撃するポイントの指定
        /// </summary>
        /// <returns>縦方向の位置(mm)</returns>
        public int getAttackY()
        {
            calcRealPosition(attack_x, attack_y, out real_x, out real_y);
            return real_y;
        }

        private void PictureBoxAttackPoint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                attack_x = e.X;
                attack_y = e.Y;
                is_attack = true;
                nowAttack = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                is_attack = false;
            }
        }

        private void PictureBoxAttackPoint_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        public bool isNowAttack()
        {
            bool res = nowAttack;
            nowAttack = false;
            return res;
        }
    }
}
