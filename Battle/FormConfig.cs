using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using real_robot_battle;

namespace Battle
{
    public partial class FormConfig : Form
    {
        MotionControl motionControl;
        
        public FormConfig(MotionControl motionControl)
        {
            InitializeComponent();
            this.motionControl = motionControl;
        }

        private void checkBoxWaist_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.WAIST, checkBoxWaist.Checked);
        }

        private void checkBoxLeftShoulderPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.LEFT_SHOULDER_PITCH, checkBoxLeftShoulderPitch.Checked);
        }

        private void checkBoxLeftShoulderRoll_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.LEFT_SHOULDER_ROLL, checkBoxLeftShoulderRoll.Checked);
        }

        private void checkBoxLeftElbowPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.LEFT_ELBOW_PITCH, checkBoxLeftElbowPitch.Checked);
        }

        private void checkBoxRightShoulderPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.RIGHT_SHOULDER_PITCH, checkBoxRightShoulderPitch.Checked);
        }

        private void checkBoxRightShoulderRoll_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.RIGHT_SHOULDER_ROLL, checkBoxRightShoulderRoll.Checked);
        }

        private void checkBoxRightElbowPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.RIGHT_ELBOW_PITCH, checkBoxRightElbowPitch.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("本当に保存しますか", "警告", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
                {
                    motionControl.readAngle(i);
                    int angle = motionControl.getAngle(i);
                    motionControl.setOffsetAngle(i, angle);
                }
                motionControl.writeOffsetAngle();
            }
        }

        private void trackBarWaist_Scroll(object sender, EventArgs e)
        {
            motionControl.sendAngleDeg((int)ID.WAIST, trackBarWaist.Value,5000);
            textBoxWaist.Text = trackBarWaist.Value.ToString();
        }

        private void trackBarLeftShoulderPitch_Scroll(object sender, EventArgs e)
        {
            motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_PITCH, trackBarLeftShoulderPitch.Value, 5000);
            textBoxLeftShoulderPitch.Text = trackBarLeftShoulderPitch.Value.ToString();
        }

        private void trackBarLeftShoulderRoll_Scroll(object sender, EventArgs e)
        {
            motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_ROLL, trackBarLeftShoulderRoll.Value, 5000);
            textBoxLeftShoulderRoll.Text = trackBarLeftShoulderRoll.Value.ToString();
        }

        private void trackBarLeftElbowPitch_Scroll(object sender, EventArgs e)
        {
            motionControl.sendAngleDeg((int)ID.LEFT_ELBOW_PITCH, trackBarLeftElbowPitch.Value, 5000);
            textBoxLeftElbowPitch.Text = trackBarLeftElbowPitch.Value.ToString();
        }

        private void trackBarRightShoulderPitch_Scroll(object sender, EventArgs e)
        {
            motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_PITCH, trackBarRightShoulderPitch.Value, 5000);
            textBoxRightShoulderPitch.Text = trackBarRightShoulderPitch.Value.ToString();
        }

        private void trackBarRightShoulderRoll_Scroll(object sender, EventArgs e)
        {
            motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_ROLL, trackBarRightShoulderRoll.Value, 5000);
            textBoxRightShoulderRoll.Text = trackBarRightShoulderRoll.Value.ToString();
        }

        private void trackBarRightElbowPitch_Scroll(object sender, EventArgs e)
        {
            motionControl.sendAngleDeg((int)ID.RIGHT_ELBOW_PITCH, trackBarRightElbowPitch.Value, 5000);
            textBoxRightElbowPitch.Text = trackBarRightElbowPitch.Value.ToString();
        }

        private void numericUpDownRange_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)numericUpDownRange.Value;
            trackBarWaist.Maximum = val;
            trackBarWaist.Minimum = -val;
            trackBarRightShoulderPitch.Maximum = val;
            trackBarRightShoulderPitch.Minimum = -val;
            trackBarRightShoulderRoll.Maximum = val;
            trackBarRightShoulderRoll.Minimum = -val;
            trackBarRightElbowPitch.Maximum = val;
            trackBarRightElbowPitch.Minimum = -val;
            trackBarLeftShoulderPitch.Maximum = val;
            trackBarLeftShoulderPitch.Minimum = -val;
            trackBarLeftShoulderRoll.Maximum = val;
            trackBarLeftShoulderRoll.Minimum = -val;
            trackBarLeftElbowPitch.Maximum = val;
            trackBarLeftElbowPitch.Minimum = -val;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p = Process.Start("notepad.exe", "..\\..\\offset_angle.txt");
        }
    }
}
