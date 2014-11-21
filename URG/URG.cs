using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using SCIP_library;

namespace real_robot_battle
{
    /// <summary>
    /// URGを制御するクラス
    /// </summary>
    public class URG
    {
        NetworkStream stream;           // データのストリーム
        TcpClient urg;
        string ip_address;              // IPアドレス
        int port_number;                // ポートの番号
        private Thread thread;
        bool isTerminate = false;
        float[] data = new float[0];
        float enemyX = 1;
        float enemyY = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public URG()
        {
            ip_address = "192.168.0.10";
            port_number = 10940;

            try
            {
                urg = new TcpClient();
                var result = urg.BeginConnect(ip_address, port_number, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                if (!success)
                {
                    throw new Exception("Failed to connect.");
                }

                stream = urg.GetStream();

                write(stream, SCIP_Writer.SCIP2());
                read_line(stream); // ignore echo back
                // 前180度を
                write(stream, SCIP_Writer.MD(180, 900, 3, 5, 0));

                isTerminate = false;
                thread = new Thread(new ThreadStart(ThreadProc));
                thread.Start();
            }
            catch
            {
                MessageBox.Show("URGが接続されていません．");
            }
 
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~URG()
        {
        }

        public void Close()
        {
            isTerminate = true;
            if (stream != null)
            {
                Thread.Sleep(300);
                write(stream, SCIP_Writer.QT());    // stop measurement mode
                read_line(stream); // ignore echo back
                stream.Close();
            }
            urg.Close();
        }

        /// <summary>
        /// URGのローデータを戻す
        /// </summary>
        /// <returns>距離データの配列</returns>
        /// エラーの場合は，最大距離を戻す
        public float[] measureData()
        {
            long time_stamp = 0;
            float[] res = new float[0];
            List<long> distances = new List<long>();

            string receive_data = read_line(stream);
            if (SCIP_Reader.MD(receive_data, ref time_stamp, ref distances))
            {
                res = new float[distances.Count()];
                for (int i = 0; i < distances.Count(); i++)
                {
                    if (distances[i] > 20)
                    {
                        res[i] = (float)distances[distances.Count() - i - 1] / 1000.0f;
                    }
                    else
                    {
                        res[i] = 0;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 敵のx座標を取得(ロボット座標が基準)
        /// </summary>
        /// <returns>x座標(m)</returns>
        public float getEnemyX()
        {
            return enemyX;
        }

        public float getEnemyY()
        {
            return enemyY;
        }

        /// <summary>
        /// URGにデータを送る
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        static bool write(NetworkStream stream, string data)
        {
            if (stream.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                stream.Write(buffer, 0, buffer.Length);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Read to "\n\n" from NetworkStream
        /// </summary>
        /// <returns>receive data</returns>
        static string read_line(NetworkStream stream)
        {
            if (stream.CanRead)
            {
                StringBuilder sb = new StringBuilder();
                bool is_NL2 = false;
                bool is_NL = false;
                do
                {
                    char buf = (char)stream.ReadByte();
                    if (buf == '\n')
                    {
                        if (is_NL)
                        {
                            is_NL2 = true;
                        }
                        else
                        {
                            is_NL = true;
                        }
                    }
                    else
                    {
                        is_NL = false;
                    }
                    sb.Append(buf);
                } while (!is_NL2);

                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 処理ループ
        /// </summary>
        private void ThreadProc()
        {
            while(!isTerminate)
            {
                data = measureData();
                analyzeData();
            }
        }

        public void analyzeData()
        {
            int count = -1000;
            float min_width = 0.4f;
            float max_width = 1.5f;
            float max_len = 4.0f;
            float min_len = 0.5f;
            float thre = 1;
            float sum = 0;

            List<double> angle = new List<double>();
            List<double> length = new List<double>();
            for (int i = 0; i < (data.Count() - 1); i++)
            {
                if (Math.Abs(data[i + 1] - data[i]) < thre)
                {
                    sum += data[i+1];
                    count ++;
                }
                else
                {
                    float len = sum / count;
                    float width = (float)(count * len / 76.4);
                    if ((width < max_width) && (width > min_width) &&
                        (len < max_len) && (len > min_len))
                    {
                        angle.Add(Math.PI * (i - count / 2) / 240);
                        length.Add(len);
//                        float angle = (float)(Math.PI * (i - count / 2) / 240);
//                        enemyX = (float)(len * Math.Sin(angle));
//                        enemyY = (float)(len * Math.Cos(angle));
                    }
                    count = 0;
                    sum = 0;
                }
            }
            if (angle.Count > 0)
            {
                int min = 0;
                double min_ang = Math.PI / 2;
                for (int i = 0; i < angle.Count; i++)
                {
                    if (Math.Abs(angle[i] - Math.PI / 2) < min_ang)
                    {
                        min = i;
                        min_ang = (float)Math.Abs(angle[i] - Math.PI / 2);
                    }
                }
                enemyX = (float)(length[min] * Math.Sin(angle[min]));
                enemyY = (float)(length[min] * Math.Cos(angle[min]));
            }
        }

        public float[] getData()
        {
            return data;
        }
    }
}
