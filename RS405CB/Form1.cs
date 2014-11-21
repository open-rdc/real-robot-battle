using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using real_robot_battle;

namespace RS405CB
{
    public partial class Form1 : Form
    {
        Sound sound;

        RealRobotRS405CB rs = new RealRobotRS405CB();
        public Form1()
        {
            InitializeComponent();
            sound = new Sound();
        }

        private void ServoOn_Click(object sender, EventArgs e)
        {
            rs.allservoOn(true);
        }

        private void ServoOff_Click(object sender, EventArgs e)
        {
            rs.allservoOn(false);
        }

        //デフォルトでEscapeキーによって起動もする
        private void CloseButton_Click(object sender, EventArgs e)
        {
            rs.allservoOn(false);
            this.Close();
        }

        private void Front_Click(object sender, EventArgs e)
        {
            if (this.Front.Text=="FRONT OPEN")
            {
                rs.FrontOpen(true);
                this.Front.Text = "FRONT CLOSE";
            }
            else
            {
                rs.FrontOpen(false);
                this.Front.Text = "FRONT OPEN";
            }
        }

        private void Shoulder_Click(object sender, EventArgs e)
        {
            if (this.Shoulder.Text=="Shoulder Expand")
            {
                rs.ShoulderExpand(true);
                this.Shoulder.Text = "Shoulder Contract";
            }
            else
            {
                rs.ShoulderExpand(false);
                this.Shoulder.Text = "Shoulder Expand";
            }
        }

        private void Bumper_Click(object sender, EventArgs e)
        {
            if (this.Bumper.Text=="Bumper Up")
            {
                rs.BumperHide(true);
                this.Bumper.Text = "Bumper Down";
            }
            else
            {
                rs.BumperHide(false);
                this.Bumper.Text = "Bumper Up";
            }
        }

        private void Sidewheel_Click(object sender, EventArgs e)
        {
            if (this.Sidewheel.Text=="SideWheel Up")
            {
                rs.SideWheelHide(true);
                this.Sidewheel.Text = "SideWheel Down";
            }
            else
            {
                rs.SideWheelHide(false);
                this.Sidewheel.Text = "SideWheel Up";
            }
        }

        private void HeadButton1_Click(object sender, EventArgs e)
        {
            Thread ht = new Thread(new ThreadStart(rs.HeadThread_up));
            ht.Start();
        }

        private void HeadButton2_Click(object sender, EventArgs e)
        {
            Thread ht = new Thread(new ThreadStart(rs.HeadThread_down));
            ht.Start();
        }

        private void Allgo2_Click(object sender, EventArgs e)
        {
            sound.Play("TF.wav");
            rs.FrontOpen(true);
            rs.ShoulderExpand(true);
            rs.BumperHide(true);
            rs.SideWheelHide(true);
            rs.HeadThread_up();
        }

        private void Allback2_Click(object sender, EventArgs e)
        {
            rs.FrontOpen(false);
            rs.ShoulderExpand(false);
            rs.BumperHide(false);
            rs.SideWheelHide(false);
            rs.HeadThread_down();
        }

        private void Launcherbutton_Click(object sender, EventArgs e)
        {
            Thread lt = new Thread(new ThreadStart(rs.LauncherThread));
            lt.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            rs.TiltAngle(this.trackBar1.Value,0);
            this.TiltangleLabel.Text = string.Format("tilt={0}",this.trackBar1.Value);
        }

        private void Tiltfront_Click(object sender, EventArgs e)
        {
            rs.TiltAngle(0,0);
            this.trackBar1.Value = 0;
            this.TiltangleLabel.Text = "tilt=0";
        }

        private void Handneck_Click(object sender, EventArgs e)
        {
            if (this.Handneck.Text == "Handneck Open")
            {
                rs.HandNeck(true);
                this.Handneck.Text = "Handneck Close";
            }
            else
            {
                rs.HandNeck(false);
                this.Handneck.Text = "Handneck Open";
            }
        }
    }
}
