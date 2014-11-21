using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;

namespace network
{
    public partial class Form1 : Form
    {
        Network network;
        
        public Form1()
        {
            InitializeComponent();
            network = new Network();
            network.Open("localhost", 50000, 50000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            network.Send("test\r\n");
            textBox1.Text += network.Recv();
        }
    }
}
