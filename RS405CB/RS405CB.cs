using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using RS405CB;

namespace real_robot_battle
{
    /// <summary>
    /// RS405CBを制御するクラス
    /// </summary>
    /// 
    public class RS405CB
    {
        const string defaultComPort = "COM2";
        const int BAUDRATE = 460800;
        SerialPort serial;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RS405CB()
        {
            Initialize();
            serial = new SerialPort();
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~RS405CB()
        {
        }

        /// <summary>
        /// 初期化ファイル
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// 通信ポートのオープン
        /// </summary>
        /// <param name="portName">ポート名</param>
        public void Open(string portName)
        {
            serial.PortName = portName;
            serial.BaudRate = BAUDRATE;
            try
            {
                serial.Open();
            }
            catch
            {
                MessageBox.Show("RS405CBのCOM2ポートを開くことができません．");
            }
        }

        /// <summary>
        /// 通信ポートのオープン
        /// </summary>
        public void Open()
        {
            Open(defaultComPort);
        }

        /// <summary>
        /// 通信ポートのクローズ
        /// </summary>
        public void Close()
        {
            serial.Close();
        }

        /// <summary>
        /// サーボの角度の設定
        /// </summary>
        /// <param name="id">サーボのID</param>
        /// <param name="angle">サーボの角度 (deg)</param>
        /// <param name="period">時間(s)</param>
        public void setAngle(byte id, float angle, float period)
        {
            byte[] buf = new byte[20];

            angle = Math.Min(Math.Max(angle, -150), 150);
            int deg = (int)(angle * 10.0f);
            byte data1 = (byte)(deg & 0xff);
            byte data2 = (byte)(deg >> 8);

            int p = (int)(period * 100);
            byte data3 = (byte)(p & 0xff);
            byte data4 = (byte)(p >> 8);

            buf[0] = 0xFA;
            buf[1] = 0xAF;
            buf[2] = id;
            buf[3] = 0x00;
            buf[4] = 0x1e;      // 目標位置のアドレス
            buf[5] = 0x04;
            buf[6] = 0x01;
            buf[7] = data1;
            buf[8] = data2;
            buf[9] = data3;
            buf[10] = data4;
            buf[11] = 0;
            for (int i = 2; i < 11; i++)
            {
                buf[11] ^= buf[i];
            }

            if (serial.IsOpen == true)
            {
                serial.Write(buf, 0, 12);
            }
        }

        /// <summary>
        /// サーボのON/OFF
        /// </summary>
        /// <param name="id">サーボのID</param>
        /// <param name="is_on">サーボをONするか(true:ON，false:OFF)</param>
        public void ServoOn(byte id, bool is_on)
        {
            byte[] buf = new byte[20];

            byte data;
            if (is_on) data = 1;
            else data = 0;

            buf[0] = 0xfa;
            buf[1] = 0xaf;
            buf[2] = id;
            buf[3] = 0x00;
            buf[4] = 0x24;      // 目標位置のアドレス
            buf[5] = 0x01;
            buf[6] = 0x01;
            buf[7] = data;
            buf[8] = 0;
            for (int i = 2; i < 8; i++)
            {
                buf[8] ^= buf[i];
            }

            if (serial.IsOpen == true)
            {
                serial.Write(buf, 0, 9);
            }
        }

    }
}
