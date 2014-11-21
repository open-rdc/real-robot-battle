using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;

namespace sound
{
    public partial class Form1 : Form
    {
        Sound sound;

        public Form1()
        {
            InitializeComponent();
            sound = new Sound();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound.Play("..\\..\\sample.wav");
        }
    }
}
