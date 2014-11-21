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
    public partial class Form1 : Form
    {
        USBRelay usbrelay;
        
        public Form1()
        {
            InitializeComponent();
            usbrelay = new USBRelay();
            usbrelay.Open("COM4");
        }

        private void checkBoxRelay0_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(0, checkBoxRelay0.Checked);
        }

        private void checkBoxRelay1_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(1, checkBoxRelay1.Checked);
        }

        private void checkBoxRelay2_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(2, checkBoxRelay2.Checked);
        }

        private void checkBoxRelay3_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(3, checkBoxRelay3.Checked);
        }

        private void checkBoxRelay4_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(4, checkBoxRelay4.Checked);
        }

        private void checkBoxRelay5_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(5, checkBoxRelay5.Checked);
        }

        private void checkBoxRelay6_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(6, checkBoxRelay6.Checked);
        }

        private void checkBoxRelay7_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(7, checkBoxRelay7.Checked);
        }

        private void checkBoxRelay8_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(8, checkBoxRelay8.Checked);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void checkBoxRelay9_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(9, checkBoxRelay9.Checked);
        }

        private void checkBoxRelay10_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(10, checkBoxRelay10.Checked);
        }

        private void checkBoxRelay11_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(11, checkBoxRelay11.Checked);
        }

        private void checkBoxRelay12_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(12, checkBoxRelay12.Checked);
        }

        private void checkBoxRelay13_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(13, checkBoxRelay13.Checked);
        }

        private void checkBoxRelay14_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(14, checkBoxRelay14.Checked);
        }

        private void checkBoxRelay15_CheckedChanged(object sender, EventArgs e)
        {
            usbrelay.setRelay(15, checkBoxRelay15.Checked);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            usbrelay.Reset();
            checkBoxRelay0.Checked = false;
            checkBoxRelay1.Checked = false;
            checkBoxRelay2.Checked = false;
            checkBoxRelay3.Checked = false;
            checkBoxRelay4.Checked = false;
            checkBoxRelay5.Checked = false;
            checkBoxRelay6.Checked = false;
            checkBoxRelay7.Checked = false;
            checkBoxRelay8.Checked = false;
            checkBoxRelay9.Checked = false;
            checkBoxRelay10.Checked = false;
            checkBoxRelay11.Checked = false;
            checkBoxRelay12.Checked = false;
            checkBoxRelay13.Checked = false;
            checkBoxRelay14.Checked = false;
            checkBoxRelay15.Checked = false;
        }

        private void buttonReadAD_Click(object sender, EventArgs e)
        {
            textBoxAD0.Text = usbrelay.getADC(0).ToString();
            textBoxAD1.Text = usbrelay.getADC(1).ToString();
            textBoxAD2.Text = usbrelay.getADC(2).ToString();
            textBoxAD3.Text = usbrelay.getADC(3).ToString();
            textBoxAD4.Text = usbrelay.getADC(4).ToString();
        }
    }
}
