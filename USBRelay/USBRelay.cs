using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace real_robot_battle
{
    /// <summary>
    /// USBRelayを制御するクラス
    /// </summary>
    class USBRelay
    {
        SerialPort serial;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public USBRelay()
        {
            serial = new SerialPort();
            serial.PortName = "COM4";
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~USBRelay()
        {
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// 通信ポートのオープン
        /// </summary>
        /// <param name="portName"></param>
        public void Open(string portName)
        {
            serial.PortName = portName;
            serial.NewLine = "\n";
            try
            {
                serial.Open();
                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();
            }
            catch
            {
                MessageBox.Show("USBリレーのCOM4を開くことができません．");
            }
        }

        /// <summary>
        /// 通信ポートのクローズ
        /// </summary>
        public void Close()
        {
            serial.Close();
        }

        /// <summary>
        /// リレーのON/OFF
        /// </summary>
        /// <param name="no">リレーの番号</param>
        /// <param name="is_on">リレーのON/OFF(true:ON, false:OFF)</param>
        public void setRelay(int no, bool is_on)
        {
            string com;
            if (is_on)
            {
                com = "relay on ";
            }
            else
            {
                com = "relay off ";
            }
            com += Convert.ToString(no, 16).ToUpper();

            if (serial.IsOpen)
            {
                serial.DiscardOutBuffer();
                serial.Write(com+"\n\r");
            }
        }

        /// <summary>
        /// GPIOのステータスの取得
        /// </summary>
        /// <param name="no">ポートの番号</param>
        /// <returns>ステータス(true:HIGH, false:LOW)</returns>
        public bool getGPIO(int no)
        {
            byte[] buf = new byte[10];
            string com = "gpio read ";
            com += Convert.ToString(no, 16);
            if (serial.IsOpen)
            {
                serial.DiscardOutBuffer();
                serial.Write(com + "\n\r");
            }

            Thread.Sleep(10);
            if (serial.IsOpen)
            {
                serial.Read(buf, 0, 10);
            }
            if (buf[0] == '1') return true;
            else return false;
        }

        /// <summary>
        /// 電圧値の取得
        /// </summary>
        /// <param name="no">ADCの番号</param>
        /// <returns>電圧値(0-1023,0-3.3V)</returns>
        public int getADC(int no)
        {
            string buf  = "-1";
            string com = "adc read ";
            com += Convert.ToString(no, 16);
            if (serial.IsOpen)
            {
                serial.DiscardOutBuffer();
                serial.Write(com + "\n\r");
                Thread.Sleep(20);
                buf = serial.ReadExisting();
                if (buf.Length > 16)
                {
                    buf = buf.Substring(12, 4);
                }
                else
                {
                    buf = "-1";
                }
            }
            return int.Parse(buf);
        }

        public void Reset()
        {
            if (serial.IsOpen)
            {
                serial.DiscardOutBuffer();
                serial.Write("reset\n\r");
            }
        }
    }
}
