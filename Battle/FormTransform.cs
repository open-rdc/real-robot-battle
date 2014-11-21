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

namespace Battle
{
    public partial class FormTransform : Form
    {
        bool isExecute = false;
        int selectedSequence = 0;
        RealRobotRelay realRobotRelay;
        RealRobotRS405CB realRobotRS405CB;
        MotionControl motionControl;

        public FormTransform(RealRobotRelay realRobotRelay, RealRobotRS405CB realRobotRS405CB, MotionControl motionControl)
        {
            InitializeComponent();
            comboBoxSquence.SelectedItem = 0;
            this.realRobotRelay = realRobotRelay;
            this.realRobotRS405CB = realRobotRS405CB;
            timer1.Start();
        }

        enum Sequence
        {
            HEAD_LIGHT,
            FORWARD,
            STEAM,
            LIFT,
            SHOULDER,
            EYE_LIGHT,
            STEAM2,
            MOVE,
            POSE,
        };

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            selectedSequence = comboBoxSquence.SelectedIndex;
            if (comboBoxSquence.SelectedIndex < (comboBoxSquence.Items.Count - 1))
                comboBoxSquence.SelectedIndex++;
            isExecute = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isExecute)
            {
                switch (selectedSequence)
                {
                    case (int)Sequence.HEAD_LIGHT:
                        realRobotRelay.setFrontLight(true);
                        selectedSequence++;
                        break;
                    case (int)Sequence.FORWARD:
                        break;
                    case (int)Sequence.STEAM:
                        realRobotRelay.setShoulderSmoke(1000, true);
                        break;
                    case (int)Sequence.LIFT:
                        break;
                    case (int)Sequence.SHOULDER:
                        realRobotRS405CB.ShoulderExpand(true);
                        break;
                    case (int)Sequence.EYE_LIGHT:
                        realRobotRelay.setHeadLight(true);
                        break;
                    case (int)Sequence.STEAM2:
                        realRobotRelay.setShoulderSmoke(1000, true);
                        break;
                    case (int)Sequence.MOVE:
                        break;
                    case (int)Sequence.POSE:
                        break;
                }
            }
            isExecute = false;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i += 10)
            {
                motionControl.Lift(i);
                Thread.Sleep(200);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            motionControl.Lift(0);
        }

        private void trackBar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // エスケープを押すと，ロボットが停止する
                if (e.KeyCode == Keys.Escape)
                {
                    motionControl.servoOn(false);
                    realRobotRS405CB.allservoOn(false);
                    MessageBox.Show("全てのサーボを停止しました");
                }
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i += 10)
            {
                motionControl.Lift(-i);
                Thread.Sleep(200);
            }
        }

        private void checkBoxFrontLight_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.setFrontLight(checkBoxFrontLight.Checked);
        }

        private void buttonSmoke_Click(object sender, EventArgs e)
        {
            realRobotRelay.setShoulderSmoke(1000, true);
        }

        private void checkBoxHeadLight_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.setHeadLight(true);
        }

        private void checkBoxHeadBoostLight_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.setHeadLightBoost(checkBoxHeadBoostLight.Checked);
        }

        private void checkBoxExaustShoot_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.shootExaust(checkBoxExaustShoot.Checked);
        }

        private void checkBoxExaustCharge_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.chargeExaust(checkBoxExaustCharge.Checked);
        }
    }
}
