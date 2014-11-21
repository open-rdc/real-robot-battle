using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace real_robot_battle
{
    /// <summary>
    /// UDP/IPで文字列を送受信するクラス
    /// </summary>
    /// 主にコマンドを送受信する．
    public class Network
    {
        string remoteHost;                  //! リモートホストの名前
        int localPort;                      //! ローカルのポート番号
        int remotePort;                     //! リモートのポート番号
        UdpClient udp = null;               //! UDP通信を行うクラス
        Encoding enc = Encoding.ASCII;      //! エンコード用クラス
        private Thread thread = null;       //! スレッド用クラス
        string recvMessage;                 //! 受信したメッセージ
        bool finish = false;                //! 終了フラグ（スレッドを終了させるため）
        bool isBinary = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Network()
        {
            Initialize();
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~Network()
        {
            finish = true;
            if (udp != null)
            {
                udp.Close();
            }
            if (thread != null)
            {
                thread.Abort();
            }
        }

        /// <summary>
        /// ネットワークの初期化
        /// </summary>
        public void Initialize()
        {
            remoteHost = "localhost";
            remotePort = 50000;
            recvMessage = "";
        }
        
        /// <summary>
        /// 通信ポートのオープン
        /// </summary>
        /// <param name="remoteHost">接続先のホスト名</param>
        /// <param name="localPort">ローカルのポート番号</param>
        /// <param name="remotePort">接続先のポート番号</param>
        public void Open(string remoteHost, int localPort, int remotePort)
        {
            udp = new UdpClient(localPort);
            if (!isBinary)
            {
                thread = new Thread(new ThreadStart(ThreadProc));
                thread.Start();
            }
            this.remoteHost = remoteHost;
            this.localPort = localPort;
        }

        /// <summary>
        /// バイナリモードを選択するかどうかを切り替える
        /// </summary>
        /// <param name="isBinary">true:バイナリーモード, false:キャラクターモード</param>
        public void setBinary(bool isBinary)
        {
            this.isBinary = isBinary;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Close()
        {
            udp.Close();
            udp = null;
        }

        /// <summary>
        /// 文字データの送信
        /// </summary>
        /// <param name="msg">送信する文字列</param>
        public void Send(string msg)
        {
            byte[] data = enc.GetBytes(msg);
            udp.Send(data, data.Length, remoteHost, remotePort);
        }

        /// <summary>
        /// バイナリデータの送信
        /// </summary>
        /// <param name="data">バイナリデータ</param>
        public void Send(byte[] data)
        {
            if (udp != null)
            {
                udp.Send(data, 11, remoteHost, remotePort);
            }
        }

        /// <summary>
        /// データの受信
        /// </summary>
        /// <returns>受信した文字列</returns>
        public string Recv()
        {
            string msg = String.Copy(recvMessage);
            recvMessage = "";

            return msg;
        }

        /// <summary>
        /// バイナリ用の受信関数
        /// </summary>
        /// 予めsetBinaryでバイナリモードを選択しておく
        /// 非ブロック,タイムアウト0.1秒
        /// <returns>受信したバイナリデータ</returns>
        public byte[] RecvBinary()
        {
            System.Net.IPEndPoint remoteEP = null;
            byte[] data = new byte[0];

            var timeToWait = TimeSpan.FromSeconds(0.01);  // 直ぐにタイムアウト
            var asyncResult = udp.BeginReceive(null, null);
            asyncResult.AsyncWaitHandle.WaitOne(timeToWait);
            if (asyncResult.IsCompleted)
            {
                try
                {
                    data = udp.Receive(ref remoteEP);
                }
                catch { }
            }
            return data;
        }

        /// <summary>
        /// 受信用のスレッド
        /// </summary>
        private void ThreadProc()
        {
            System.Net.IPEndPoint remoteEP = null;
            while (!finish)
            {
                byte[] data = udp.Receive(ref remoteEP);
                recvMessage += enc.GetString(data);
            }
        }
    }
}
