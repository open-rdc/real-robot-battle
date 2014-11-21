using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;
using JUNKBOX.IO;

namespace Battle
{
    public partial class FormBattle : Form
    {
        // バトル用のインターフェイス
        Joystick joystick = null;
        Network network;
        const int port = 50000;
        RRBSerial serial;
        Mechanum mechanum;
        MotionControl motionControl;
        Sound sound;
        RealRobotRS405CB realRobotRs405cb;
        RealRobotRelay realRobotRelay;
        URG urg;
        float[] distance = new float[0];
        CaptureDevice camera = null;
        float enemy_x = 1, enemy_y = 0;　// 敵の位置（ロボットからの相対距離，単位はm）
        float enemy_distance;            // 敵までの距離の計測値
        float enemy_direction;           // 敵の正面からの方向の計測値(rad)
        float enemy_direction_dest;      // 敵の正面からの方向の目標値(rad)
        const float enemy_direction_LR = 45;  // 左右の標準的な方向
        const int delta = 200;           // 0.5秒間でトップスピードになる係数
        int mx, my, mz;                  // ロボットの指令値
        bool isTracking;                 // 自動追尾を行うかどうか
        bool isHeadTracking;             // 頭のトラッキングを行うかどうか
        bool isAutoAttack;               // 自動攻撃中かどうか

        /// <summary>
        /// 送信するUDPのデータ 
        /// </summary>
        struct UDPData
        {
            public sbyte x;
            public sbyte y;
            public sbyte z;
            public bool button0;
            public bool button1;
            public bool button2;
            public bool button3;
            public bool button4;
            public bool button5;
            public bool button6;
            public bool button7;
        };
        UDPData controllerData;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormBattle()
        {
            InitializeComponent();

            // クラスの初期化
            joystick = new Joystick();
            network = new Network();
            network.setBinary(true);                // データをバイナリ形式で送信
            network.Open("localhost", port, port);  // 通信ポートのオープン
            serial = new RRBSerial();
            serial.Open();
            mechanum = new Mechanum();
            mechanum.setSerialPort(serial);
            motionControl = new MotionControl();
            motionControl.setSerialPort(serial);
            motionControl.readOffsetAngle();
            sound = new Sound();
            realRobotRs405cb = new RealRobotRS405CB();
            realRobotRelay = new RealRobotRelay();
            urg = new URG();
            float[] distance = new float[0];
            InitVideo();
            controllerData = new UDPData();

            Initialize();

            timer100ms.Start();
        }

        /// <summary>
        /// パラメータの初期化
        /// </summary>
        public void Initialize()
        {
            mx = my = mz = 0;
            enemy_distance = 1000;
            enemy_direction = 0;
            enemy_direction_dest = 0;
            isTracking = false;
            isHeadTracking = false;
            isAutoAttack = false;
        }

        /// <summary>
        /// ビデオの初期化
        /// </summary>
        public void InitVideo()
        {
            VideoCapture capture = new VideoCapture();
            List<CaptureDevice> devices = capture.Devices;
            if (devices != null)
            {
                // 0番目のデバイス名を取得
                camera = devices[0];

                // 0番目のデバイスを 320x240 pixel の Bitmap を出力するように初期化
                camera.Activate(this.previewPanel, 320, 240); // ToDo:元に戻す．
            }
            else
            {
                MessageBox.Show("キャプチャデバイスが見つかりませんでした");
            }
        }

        /// <summary>
        /// フォームを閉じるときの処理
        /// </summary>
        private void FormBattle_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer100ms.Stop();
            joystick.Close();
            motionControl.Close();
            mechanum.Stop();
            mechanum.Close();
            realRobotRs405cb.Close();
            realRobotRelay.Close();
            urg.Close();
            network.Close();
        }

        /// <summary>
        /// フォームの初期化のハンドラ
        /// </summary>
        private void FormBattle_Load(object sender, EventArgs e)
        {
            textBoxLength.Text = trackBarLength.Value.ToString();
            pictureBoxAttackPoint.Initialize();
        }

        /// <summary>
        /// 距離調整用のトラックバーの値を変更した時のハンドラ
        /// </summary>
        private void trackBarLength_Scroll(object sender, EventArgs e)
        {
            textBoxLength.Text = trackBarLength.Value.ToString();
        }

        /// <summary>
        /// 移動のモード
        /// </summary>
        enum Mode {
            normal = 0,
            slow,
            fast,
        };

        /// <summary>
        /// ゲインと不感帯からフィードバック制御の値を計算
        /// </summary>
        /// <param name="error">制御対象の差分</param>
        /// <param name="gain">ゲイン</param>
        /// <param name="deadzone">不感帯</param>
        /// <returns>フィードバック制御の値</returns>
        private double calcGainValue(double err, double gain, double deadzone)
        {
            deadzone /= 2;

            if (err > deadzone) err -= deadzone;
            else if (err < -deadzone) err += deadzone;
            else err = 0;
            return err * gain;
        }

        /// <summary>
        /// ジョイスティックのボタンの番号
        /// </summary>
        enum Button {
            A,
            B,
            X,
            Y,
            L1,
            R1,
        }

        /// <summary>
        /// ジョイスティック関連（外部からの無線を含む）の処理
        /// </summary>
        private void joystickProcess()
        {
            if (joystick.isAvailable)
            {
                controllerData.x       = (sbyte)-joystick.getLY();
                controllerData.y       = (sbyte)joystick.getLX();
                controllerData.z       = (sbyte)joystick.getRX();
                controllerData.button0 = joystick.getButton(0);
                controllerData.button1 = joystick.getButton(1);
                controllerData.button2 = joystick.getButton(2);
                controllerData.button3 = joystick.getButton(3);
                controllerData.button4 = joystick.getButton(4);
                controllerData.button5 = joystick.getButton(5);
                controllerData.button6 = joystick.getButton(6);
                controllerData.button7 = joystick.getButton(7);
            }
            else
            {
                // UDP通信を用いてデータを受信する．
                byte[] data;
                data = network.RecvBinary();
                if (data.Length == 11)
                {
                    controllerData.x = (sbyte)-data[1];
                    controllerData.y = (sbyte)data[0];
                    controllerData.z = (sbyte)data[2];
                    controllerData.button0 = (data[3] == 1) ? true : false;
                    controllerData.button1 = (data[4] == 1) ? true : false;
                    controllerData.button2 = (data[5] == 1) ? true : false;
                    controllerData.button3 = (data[6] == 1) ? true : false;
                    controllerData.button4 = (data[7] == 1) ? true : false;
                    controllerData.button5 = (data[8] == 1) ? true : false;
                    controllerData.button6 = (data[9] == 1) ? true : false;
                    controllerData.button7 = (data[10] == 1) ? true : false;
                }
            }
        }

        /// <summary>
        /// 周期的に実行される移動の処理処理
        /// </summary>
        private void moveProcess()
        {
            const double trackingGainFB = 0.6;          // 前後方向のフィードバックゲイン(1mで速度600)
            const double trackingGainDir = 600.0;       // 回転方向のフィードバックゲイン(1radで600)
            const int maxTrackingSpeed = 1200;          // 最大速度
            const int C = 6;    //ジョイパッド（0~100）* C(1~10)　C:最大出力値（1~100%） 
            const double fast = 1.5;
            const double slow = 0.5;
//            const double trackingGainFB = 1.0;          // 前後方向のフィードバックゲイン(1mで速度600)
//            const double trackingGainDir = 1000.0;       // 回転方向のフィードバックゲイン(1radで600)
//            const int maxTrackingSpeed = 1600;          // 最大速度
//            const int C = 10;    //ジョイパッド（0~100）* C(1~10)　C:最大出力値（1~100%） 
            const double deadzoneTrackingFB = 100;      // 前後方向の不感帯(100mm 前後合わせて)
            const double deadzoneTrackingDir = 0.1;     // 角度の不感帯(0.1rad およそ5.7deg)

            Mode mode;
            int x = controllerData.x;
            int y = controllerData.y;
            int z = controllerData.z;
            const int max = 1200;

            // ジョイスティックの値の表示
            textBoxXValue.Text = controllerData.x.ToString();
            textBoxYValue.Text = controllerData.y.ToString();
            textBoxZValue.Text = controllerData.z.ToString();

            // 低速モードと高速モード
            if (controllerData.button6)             // L2を押した場合
            {
                mode = Mode.slow;
                textBoxAccel.Text = "Slow";
            }
            else if (controllerData.button7)        // R2を押した場合
            {
                mode = Mode.fast;
                textBoxAccel.Text = "Accel";
            }
            else
            {
                mode = Mode.normal;
                textBoxAccel.Text = "";
            }

            if (!checkBoxBrake.Checked)     // ブレーキが外れていれば
            {
                if (mode == Mode.slow)      // 低速モード
                {
                    x = (int)(x * slow);
                    y = (int)(y * slow);
                    z = (int)(z * slow);
                }
                else if (mode == Mode.fast) // 高速モード
                {
                    x = (int)(x * fast);
                    y = (int)(y * fast);
                    z = (int)(z * fast);
                }

                // トラッキングモードの時にはジョイスティックの情報は横方向だけにする．
                // その他はURGのデータを元に，前後回転を行う．
                if (isTracking)
                {
                    double rx = trackBarLength.Value - enemy_distance * 1000;
                    double ry = y / trackingGainFB * C;
                    double rz = radian(enemy_direction_dest) - radian(enemy_direction);

                    double the = radian(enemy_direction);
                    double ex = rx * Math.Cos(the) - ry * Math.Sin(the);
                    double ey = rx * Math.Sin(the) + ry * Math.Cos(the);
                    double ez = rz;

                    x = (int)calcGainValue(ex, trackingGainFB, deadzoneTrackingFB);
                    x = (int)Math.Max(Math.Min(x, maxTrackingSpeed), -maxTrackingSpeed);

                    y = (int)calcGainValue(ey, trackingGainFB, deadzoneTrackingFB);
                    y = (int)Math.Max(Math.Min(y, maxTrackingSpeed), -maxTrackingSpeed);

                    z = (int)calcGainValue(rz, trackingGainDir, deadzoneTrackingDir);
                    z = Math.Max(Math.Min(z, maxTrackingSpeed / 2), -maxTrackingSpeed / 2);
                }
                else
                {   // トラッキングモードで無い場合
                    // ジョイスティック(-100～100)の値に係数をかける
                    x *= C;
                    y *= C;
                    z *= C;
                }

                // 速度の上限(モータの上限は2597pulse/sec)
                x = Math.Max(Math.Min(x, max), -max);
                y = Math.Max(Math.Min(y, max), -max);
                z = Math.Max(Math.Min(z, max), -max);

                // 0.1秒間に最大deltaだけ速度を変更（滑らかに加速するため）
                mx += Math.Sign(x - mx) * Math.Min(Math.Abs(x - mx), delta);
                my += Math.Sign(y - my) * Math.Min(Math.Abs(y - my), delta);
                mz += Math.Sign(z - mz) * Math.Min(Math.Abs(z - mz), delta);

                mechanum.setSpeed(mx, my, mz);        // メカナムホイールは前が+x,左が+y，時計回りに+z
            }
            else
            {
                // モータの停止
                mechanum.Stop();
                mx = my = mz = 0;
            }
        }

        /// <summary>
        /// マニュアルで操作するときの上半身の制御（非常用）
        /// </summary>
        private void motionProcess()
        {
            if (!motionControl.IsMotionPlay())
            {
                comboBoxButtonA.BackColor = Color.White;
                comboBoxButtonB.BackColor = Color.White;
                comboBoxButtonX.BackColor = Color.White;
                comboBoxButtonY.BackColor = Color.White;
            }

            if (controllerData.button0)            // ボタン0に設定された動きの再生
            {
                comboBoxButtonA.BackColor = Color.LightPink;
                if (checkBoxManual.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\" + comboBoxButtonA.Text + ".csv");
                    sound.Play("..\\..\\sound\\" + comboBoxButtonA.Text + ".wav");
                }
            }

            if (controllerData.button1)            // ボタン1に設定された動きの再生
            {
                comboBoxButtonB.BackColor = Color.LightPink;
                if (checkBoxManual.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\" + comboBoxButtonB.Text + ".csv");
                    sound.Play("..\\..\\sound\\" + comboBoxButtonB.Text + ".wav");
                }
            }

            if (controllerData.button2)            // ボタン2に設定された動きの再生
            {
                comboBoxButtonX.BackColor = Color.LightPink;
                if (checkBoxManual.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\" + comboBoxButtonX.Text + ".csv");
                    sound.Play("..\\..\\" + comboBoxButtonX.Text + ".wav");
                }
            }

            if (controllerData.button3)            // ボタン3に設定された動きの再生
            {
                comboBoxButtonY.BackColor = Color.LightPink;
                if (checkBoxManual.Checked && (!motionControl.IsMotionPlay()))
                {
                    motionControl.playMotion("..\\..\\" + comboBoxButtonY.Text + ".csv");
                    sound.Play("..\\..\\" + comboBoxButtonY.Text + ".wav");
                }
            }
        }

        /// <summary>
        /// 周期的に呼び出されるセンサの処理
        /// </summary>
        private void sensorProcess()
        {
            // URGの処理
            distance = urg.getData();
            panelURG.setDistance(distance);
            enemy_x = urg.getEnemyX();
            enemy_y = urg.getEnemyY();
            panelURG.setEnemy(enemy_x, enemy_y);
            panelURG.Invalidate();
            enemy_distance = (float)Math.Sqrt(enemy_x * enemy_x + enemy_y * enemy_y);
            enemy_direction = (float)degree(Math.Atan2(enemy_y, enemy_x));
            panelDistance.setDistance(enemy_distance);
            panelDistance.Invalidate();
        }

        /// <summary>
        /// 頭の制御
        /// </summary>
        int head_angle = 0;
        private void headProcess()
        {
            if (isHeadTracking)             // 頭で敵をトラッキングする場合
            {
                int angle = (int)-enemy_direction;
                int waist_angle = motionControl.getAngle((int)ID.WAIST);
                int head_angle_dest = angle - waist_angle;
                if (Math.Abs(head_angle_dest - head_angle) > 5)   // 10deg以下は動かない（不感帯）
                {
                    realRobotRs405cb.TiltAngle(head_angle_dest, 1);  // 相手を向く
                    head_angle = head_angle_dest;
                }
            }
            else
            {
                int waist_angle = motionControl.getAngle((int)ID.WAIST);
                int head_angle_dest = - waist_angle;
                if (Math.Abs(head_angle_dest - head_angle) > 5)   // 10deg以下は動かない（不感帯）
                {
                    realRobotRs405cb.TiltAngle(head_angle_dest, 1);  // 相手を向く
                    head_angle = head_angle_dest;
                }
            }
        }

        /// <summary>
        /// 100ms周期で定期的に呼び出されるハンドラ
        /// </summary>
        private void timer100ms_Tick(object sender, EventArgs e)
        {
            joystickProcess();
            sensorProcess();
            moveProcess();
            if (checkBoxServo.Checked)          // servoをONにしないと動作しないようにする
            {
                if (isAutoAttack)               // 自動アタックの場合
                {
                    autoMotionProcess(pictureBoxAttackPoint.isNowAttack());
                }
                else
                {
                    motionProcess();
                }
            }
            headProcess();
        }

        /// <summary>
        /// キー割り込みハンドラ
        /// </summary>
        private void FormBattle_KeyDown(object sender, KeyEventArgs e)
        {
            // エスケープを押すと，ロボットが停止する
            if (e.KeyCode == Keys.Escape)
            {
                checkBoxBrake.Checked = true;
                motionControl.stop();
                MessageBox.Show("全てのサーボを停止しました");
            }
            // F1で初期位置調整モード
            if (e.KeyCode == Keys.F1)
            {
                FormConfig formConfig = new FormConfig(motionControl);
                formConfig.ShowDialog(this);
                formConfig.Dispose();
            }
            // F2で初期位置調整モード
            if (e.KeyCode == Keys.F2)
            {
                FormTransform formTransform = new FormTransform(realRobotRelay, realRobotRs405cb, motionControl);
                formTransform.ShowDialog(this);
                formTransform.Dispose();
            }
            // Aキーで間合いを広げる
            if (e.KeyCode == Keys.A)
            {
                trackBarLength.Value = Math.Min(trackBarLength.Value + 100, trackBarLength.Maximum);
                textBoxLength.Text = trackBarLength.Value.ToString();
            }
            // Zキーで間合いを狭める
            if (e.KeyCode == Keys.Z)
            {
                trackBarLength.Value = Math.Max(trackBarLength.Value - 100, trackBarLength.Minimum);
                textBoxLength.Text = trackBarLength.Value.ToString();
            }
            // SキーでTrackingをON/OFF
            if (e.KeyCode == Keys.S)
            {
                checkBoxTracking.Checked ^= true;
            }
            // XキーでAuto AttackをON/OFF
            if (e.KeyCode == Keys.X)
            {
                checkBoxAttack.Checked ^= true;
            }
            // Cキーで右前でバトル
            if (e.KeyCode == Keys.C)
            {
                radioButtonLeft.Checked = false;
                radioButtonRight.Checked = true;
            }
            // Dキーで右前でバトル
            if (e.KeyCode == Keys.D)
            {
                radioButtonLeft.Checked = true;
                radioButtonRight.Checked = false;
            }
            // Eキーで正面でバトル
            if (e.KeyCode == Keys.E)
            {
                radioButtonLeft.Checked = false;
                radioButtonRight.Checked = false;
                enemy_direction_dest = 0;
                initialPose();
            }
        }

        /// <summary>
        /// ビデオを表示するかどうかの選択
        /// </summary>
        private void checkBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVideo.Checked)
            {
                checkBoxVideo.BackColor = Color.Blue;
                checkBoxVideo.ForeColor = Color.White; camera.previewStart();
                previewPanel.Visible = true;
                labelLive.Visible = true;
                labelNoVideo.Visible = false;
            }
            else
            {
                checkBoxVideo.BackColor = Color.White;
                checkBoxVideo.ForeColor = Color.Black;
                if (camera != null) camera.previewStop();
                previewPanel.Visible = false;
                labelLive.Visible = false;
                labelNoVideo.Visible = true;
            }
        }

        /// <summary>
        /// 自動追尾モードの選択
        /// </summary>
        private void checkBoxTracking_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTracking.Checked)
            {
                isTracking = true;
                checkBoxTracking.BackColor = Color.Red;
                checkBoxTracking.ForeColor = Color.White;
            }
            else
            {
                isTracking = false;
                checkBoxTracking.BackColor = Color.White;
                checkBoxTracking.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 自動攻撃モードの選択
        /// </summary>
        private void checkBoxAttack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAttack.Checked)
            {
                isAutoAttack = true;
                checkBoxAttack.BackColor = Color.Red;
                checkBoxAttack.ForeColor = Color.White;
            }
            else
            {
                isAutoAttack = false;
                checkBoxAttack.BackColor = Color.White;
                checkBoxAttack.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 手動攻撃モードを選択
        /// </summary>
        private void checkBoxManual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxManual.Checked)
            {
                checkBoxManual.BackColor = Color.Blue;
                checkBoxManual.ForeColor = Color.White;
            }
            else
            {
                checkBoxManual.BackColor = Color.White;
                checkBoxManual.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// ブレーキを外す
        /// </summary>
        private void checkBoxBrake_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBrake.Checked)
            {
                checkBoxBrake.BackColor = Color.Blue;
                checkBoxBrake.ForeColor = Color.White;
                if (checkBoxServo.Checked == true)
                {
                    motionControl.stop();
                }
            }
            else
            {
                checkBoxBrake.BackColor = Color.White;
                checkBoxBrake.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 必殺技の起動
        /// </summary>
        private void checkBoxSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpecial.Checked)
            {
                checkBoxSpecial.BackColor = Color.Red;
                checkBoxSpecial.ForeColor = Color.White;
                if (comboBoxBoost.Text == "Grenade")
                {
                    Grenade();
                    checkBoxSpecial.Checked = false;
                }
                else if (comboBoxBoost.Text == "Exhaust")
                {
                }
                else if (comboBoxBoost.Text == "Axe")
                {
                }
            }
            else
            {
                checkBoxSpecial.BackColor = Color.White;
                checkBoxSpecial.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 敵に頭を向けるかどうかを選択
        /// </summary>
        private void checkBoxHead_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHead.Checked)
            {
                isHeadTracking = true;
                checkBoxHead.BackColor = Color.Blue;
                checkBoxHead.ForeColor = Color.White;
            }
            else
            {
                isHeadTracking = false;
                checkBoxHead.BackColor = Color.White;
                checkBoxHead.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 煙の出力
        /// </summary>
        private void buttonSteam_Click(object sender, EventArgs e)
        {
            realRobotRelay.setShoulderSmoke(1000, true);
            sound.Play("..\\..\\sound\\06.wav");
        }

        /// <summary>
        /// 音声の出力
        /// </summary>
        private void buttonVoice_Click(object sender, EventArgs e)
        {
            sound.Play("..\\..\\sound\\" + comboBoxVoice.Text + ".wav");
        }

        private void buttonPreset_Click(object sender, EventArgs e)
        {
            sound.Play("..\\..\\sound\\06.wav");
        }

        /// <summary>
        /// グレネードの発射
        /// </summary>
        private void Grenade()
        {
            realRobotRs405cb.Launcher();
        }

        private void Exhaust()
        {
        }

        private void Axe()
        {
        }

        /// <summary>
        /// degreeからradian(-PI～PI)に変換
        /// </summary>
        private double radian(double deg)
        {
            while (deg > 180) deg -= 360;
            while (deg < -180) deg += 360;
            return ((double)(deg / 180.0 * Math.PI));
        }

        /// <summary>
        /// radianからdegree(-180～180)に変換
        /// </summary>
        private double degree(double rad)
        {
            while (rad > Math.PI) rad -= (float)(Math.PI * 2.0);
            while (rad < -Math.PI) rad += (float)(Math.PI * 2.0);
            return ((double)(rad / Math.PI * 180.0));
        }

        /// <summary>
        /// 初期姿勢への移動
        /// </summary>
        private void initialPose()
        {
            const int initialPeriod = 5000;
            motionControl.sendAngleDeg((int)ID.WAIST, 0, initialPeriod);
            motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_PITCH, 20, initialPeriod);
            motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_ROLL, 10, initialPeriod);
            motionControl.sendAngleDeg((int)ID.LEFT_ELBOW_PITCH, -70, initialPeriod);
            motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_PITCH, 20, initialPeriod);
            motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_ROLL, 10, initialPeriod);
            motionControl.sendAngleDeg((int)ID.RIGHT_ELBOW_PITCH, -70, initialPeriod);
        }

        /// <summary>
        /// 上半身のサーボのON/OFF
        /// </summary>
        private void checkBoxServo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxServo.Checked)
            {
                motionControl.servoOn(true);                // サーボを入れる
                initialPose();                              // 初期姿勢に移動
                checkBoxServo.BackColor = Color.Blue;
                checkBoxServo.ForeColor = Color.White;
            }
            else
            {
                motionControl.servoOn(false);
                checkBoxServo.BackColor = Color.White;
                checkBoxServo.ForeColor = Color.Black;
            }
        }

        private void radioButtonLeft_CheckedChanged(object sender, EventArgs e)
        {
            enemy_direction_dest = enemy_direction_LR;
        }

        private void radioButtonRight_CheckedChanged(object sender, EventArgs e)
        {
            enemy_direction_dest = -enemy_direction_LR;
        }
    }
}
