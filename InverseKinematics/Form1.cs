using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;

namespace inverseKinematics
{
    public partial class Form1 : Form
    {
        InverseKinematics ik = new InverseKinematics();
        double[] angle = new double[7];
        double[,] hand = new double[2, 3];

        public Form1()
        {
            InitializeComponent();
            angle[3] = 90;
            angle[6] = 90;
        }

        private void Copy(double[] a, double[,] b, int n)
        {
            for (int i = 0; i < 3; i++)
            {
                b[n, i] = a[i];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setAngle();
        }

        bool is_first = true;

        private void setAngle()
        {
            double[,] p = new double[6, 3];
            double[] val = new double[3];

            val = ik.getLeftHandPosition(angle);
            Copy(val, p, (int)Part.LEFT_HAND);

            if (is_first) Copy(val, hand, 0);
            val = ik.getPartPosition(0);
            Copy(val, p, (int)Part.LEFT_SHOULDER);
            val = ik.getPartPosition(1);
            Copy(val, p, (int)Part.LEFT_ELBOW);

            val = ik.getRightHandPosition(angle);
            Copy(val, p, (int)Part.RIGHT_HAND);

            if (is_first) Copy(val, hand, 1);
            val = ik.getPartPosition(0);
            Copy(val, p, (int)Part.RIGHT_SHOULDER);
            val = ik.getPartPosition(1);
            Copy(val, p, (int)Part.RIGHT_ELBOW);

            posture.setPosition(p);
            is_first = false;
        }

        private void setHandPosition()
        {
            double[] ang;
            double[] left_hand = new double[3];
            for(int i = 0;i < 3;i ++) left_hand[i] = hand[0,i];
//            System.Diagnostics.Debug.Print("hand[0]:" + hand[0, 0].ToString() + ", hand[1]:" + hand[0, 1].ToString() + ", hand[2]:" + hand[0, 2].ToString()); 
            ang = ik.getLeftArmAngle(left_hand, angle[0]);
            angle[1] = ang[0];
            angle[2] = ang[1];
            angle[3] = ang[2];
//            System.Diagnostics.Debug.Print("ang[0]:" + ang[0].ToString() + ", ang[1]:" + ang[1].ToString() + ", ang[2]:" + ang[2].ToString()); 
            double[] right_hand = new double[3];
            for (int i = 0; i < 3; i++) right_hand[i] = hand[1, i];
            ang = ik.getRightArmAngle(right_hand, angle[0]);
            angle[4] = ang[0];
            angle[5] = ang[1];
            angle[6] = ang[2];
            posture.setHandPosition(hand);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool is_change = true;

            switch (e.KeyCode)
            {
                case Keys.A:
                    angle[0] += 1;
                    break;
                case Keys.Z:
                    angle[0] -= 1;
                    break;
                case Keys.S:
                    angle[1] += 1;
                    break;
                case Keys.X:
                    angle[1] -= 1;
                    break;
                case Keys.D:
                    angle[2] += 1;
                    break;
                case Keys.C:
                    if (angle[2] > 0) angle[2] -= 1;
                    break;
                case Keys.F:
                    angle[3] += 1;
                    break;
                case Keys.V:
                    angle[3] -= 1;
                    break;
                case Keys.G:
                    angle[4] += 1;
                    break;
                case Keys.B:
                    angle[4] -= 1;
                    break;
                case Keys.H:
                    if (angle[5] < 0) angle[5] += 1;
                    break;
                case Keys.N:
                    angle[5] -= 1;
                    break;
                case Keys.J:
                    angle[6] += 1;
                    break;
                case Keys.M:
                    angle[6] -= 1;
                    break;
                default:
                    is_change = false;
                    break;
            }

            if (is_change){
                setAngle();
            }

            is_change = true;

            switch (e.KeyCode)
            {
                case Keys.D1:
                    hand[0, 0] += 0.01;
                    break;
                case Keys.Q:
                    hand[0, 0] -= 0.01;
                    break;
                case Keys.D2:
                    hand[0, 1] += 0.01;
                    break;
                case Keys.W:
                    hand[0, 1] -= 0.01;
                    break;
                case Keys.D3:
                    hand[0, 2] += 0.01;
                    break;
                case Keys.E:
                    hand[0, 2] -= 0.01;
                    break;
                case Keys.D4:
                    hand[1, 0] += 0.01;
                    break;
                case Keys.R:
                    hand[1, 0] -= 0.01;
                    break;
                case Keys.D5:
                    hand[1, 1] += 0.01;
                    break;
                case Keys.T:
                    hand[1, 1] -= 0.01;
                    break;
                case Keys.D6:
                    hand[1, 2] += 0.01;
                    break;
                case Keys.Y:
                    hand[1, 2] -= 0.01;
                    break;
                default:
                    is_change = false;
                    break;
            }

            if (is_change){
                setHandPosition();
                setAngle();
            }

            posture.Invalidate();
        }
    }
}
