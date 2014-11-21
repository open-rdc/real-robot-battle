using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JUNKBOX.IO;

namespace USBCamera
{
    public partial class Form1 : Form
    {
        CaptureDevice camera;

        public Form1()
        {
            InitializeComponent();
            
            // すべてのキャプチャデバイスを取得
            VideoCapture capture = new VideoCapture();
            List<CaptureDevice> devices = capture.Devices;

            if (devices != null)
            {
                // 0番目のデバイス名を取得
                camera = devices[0];
                this.toolStripStatusLabel1.Text = camera.Name;

                // 0番目のデバイスを 320x240 pixel の Bitmap を出力するように初期化
                camera.Activate(this.previewPanel, 320, 240); // ToDo:元に戻す．
            }
            else
            {
                this.toolStripStatusLabel1.Text = "キャプチャデバイスが見つかりませんでした";
            }
        }

    }
}
