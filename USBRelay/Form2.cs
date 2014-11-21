using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;

namespace usbrelay
{
    public partial class Form2 : Form
    {
        RealRobotRelay realRobotRelay;

        public Form2()
        {
            InitializeComponent();
            realRobotRelay = new RealRobotRelay();
        }

        private void checkBoxFrontLight_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.setFrontLight(checkBoxFrontLight.Checked);
        }

        private void buttonWinkerRight_Click(object sender, EventArgs e)
        {
            realRobotRelay.setWinkerRight(5000, true);
        }

        private void buttonWinkerLeft_Click(object sender, EventArgs e)
        {
            realRobotRelay.setWinkerLeft(5000, true);
        }

        private void checkBoxHeadBoostLight_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.setHeadLightBoost(checkBoxHeadLightBoost.Checked);
        }

        private void checkBoxExaustShoot_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.shootExaust(checkBoxExaustShoot.Checked);
        }

        private void checkBoxExaustXCharge_CheckedChanged(object sender, EventArgs e)
        {
            realRobotRelay.chargeExaust(checkBoxExaustCharge.Checked);
        }

        private void buttonHeadLight_Click(object sender, EventArgs e)
        {
            realRobotRelay.setHeadLight(true);
        }

        private void buttonSmoke_Click(object sender, EventArgs e)
        {
            realRobotRelay.setShoulderSmoke(1000, true);
        }

    }
}
