using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;
using System.Threading;

namespace motionControl
{
    /// <summary>
    /// モーションを作成するクラス
    /// </summary>
    public partial class Form1 : Form
    {
        const int dataNum = 9;
        RRBSerial serial;
        MotionControl motionControl;
        //        private Timer t_angle;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            serial = new RRBSerial();
            serial.Open("COM1");
            motionControl = new MotionControl();
            motionControl.setSerialPort(serial);
            motionControl.readOffsetAngle();

            //            t_angle = new Timer();
            //            t_angle.Tick += new EventHandler(recv_angle);
            //            t_angle.Interval = 1000; // ミリ秒単位で指定
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            getOffsetAngle();
        }

        /// <summary>
        /// 終了処理
        /// </summary>        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            motionControl.Close();
        }

        /// <summary>
        /// オフセット角度を読み込んでGUIに反映させる
        /// </summary>
        private void getOffsetAngle()
        {
            numericUpDownOffsetWaist.Value = motionControl.getOffsetAngle((int)ID.WAIST);
            numericUpDownOffsetLeftShoulderPitch.Value = motionControl.getOffsetAngle((int)ID.LEFT_SHOULDER_PITCH);
            numericUpDownOffsetLeftShoulderRoll.Value = motionControl.getOffsetAngle((int)ID.LEFT_SHOULDER_ROLL);
            numericUpDownOffsetLeftElbowPitch.Value = motionControl.getOffsetAngle((int)ID.LEFT_ELBOW_PITCH);
            numericUpDownOffsetRightShoulderPitch.Value = motionControl.getOffsetAngle((int)ID.RIGHT_SHOULDER_PITCH);
            numericUpDownOffsetRightShoulderRoll.Value = motionControl.getOffsetAngle((int)ID.RIGHT_SHOULDER_ROLL);
            numericUpDownOffsetRightElbowPitch.Value = motionControl.getOffsetAngle((int)ID.RIGHT_ELBOW_PITCH);
            numericUpDownWaist.Minimum = -(int)numericUpDownOffsetWaist.Value;
            numericUpDownLeftShoulderPitch.Minimum = -(int)numericUpDownOffsetLeftShoulderPitch.Value;
            numericUpDownLeftShoulderRoll.Minimum = -(int)numericUpDownOffsetLeftShoulderRoll.Value;
            numericUpDownLeftElbowPitch.Minimum = -(int)numericUpDownOffsetLeftElbowPitch.Value;
            numericUpDownRightShoulderPitch.Minimum = -(int)numericUpDownOffsetRightShoulderPitch.Value;
            numericUpDownRightShoulderRoll.Minimum = -(int)numericUpDownOffsetRightShoulderRoll.Value;
            numericUpDownRightElbowPitch.Minimum = -(int)numericUpDownOffsetRightElbowPitch.Value;
        }

        /// <summary>
        /// サーボONのボタンをおした時の処理
        /// </summary>
        private void buttonServoOn_Click(object sender, EventArgs e)
        {
            checkBoxWaist.Checked = true;
            checkBoxRightShoulderPitch.Checked = true;
            checkBoxRightShoulderRoll.Checked = true;
            checkBoxRightElbowPitch.Checked = true;
            checkBoxLeftShoulderPitch.Checked = true;
            checkBoxLeftShoulderRoll.Checked = true;
            checkBoxLeftElbowPitch.Checked = true;
            //            t_angle.Start();
            checkBoxTestMode.Checked = true;

        }

        /*
        private void recv_angle(object sender, EventArgs e)
        {
            t_angle.Stop();
            numericUpDownWaist.Value = motionControl.getAngle((int)ID.WAIST) - numericUpDownOffsetWaist.Value;
            numericUpDownLeftShoulderPitch.Value = motionControl.getAngle((int)ID.LEFT_SHOULDER_PITCH) - numericUpDownOffsetLeftShoulderPitch.Value;
            numericUpDownLeftShoulderRoll.Value = motionControl.getAngle((int)ID.LEFT_SHOULDER_ROLL) - numericUpDownOffsetLeftShoulderRoll.Value;
            numericUpDownLeftElbowPitch.Value = motionControl.getAngle((int)ID.LEFT_ELBOW_PITCH) - numericUpDownOffsetLeftElbowPitch.Value;
            numericUpDownRightShoulderPitch.Value = motionControl.getAngle((int)ID.RIGHT_SHOULDER_PITCH) - numericUpDownOffsetRightShoulderPitch.Value;
            numericUpDownRightShoulderRoll.Value = motionControl.getAngle((int)ID.RIGHT_SHOULDER_ROLL) - numericUpDownOffsetRightShoulderRoll.Value;
            numericUpDownRightElbowPitch.Value = motionControl.getAngle((int)ID.RIGHT_ELBOW_PITCH) - numericUpDownOffsetRightElbowPitch.Value;
        }
         * */

        /// <summary>
        /// サーボOFFのボタンをおした時の処理
        /// </summary>
        private void buttonServoOff_Click(object sender, EventArgs e)
        {
            checkBoxWaist.Checked = false;
            checkBoxRightShoulderPitch.Checked = false;
            checkBoxRightShoulderRoll.Checked = false;
            checkBoxRightElbowPitch.Checked = false;
            checkBoxLeftShoulderPitch.Checked = false;
            checkBoxLeftShoulderRoll.Checked = false;
            checkBoxLeftElbowPitch.Checked = false;
        }

        /// <summary>
        /// 保存ボタンをおした時の処理
        /// </summary>
        private void buttonWriteOffsetAngle_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("本当に保存しますか", "警告", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                motionControl.writeOffsetAngle();
            }
        }

        /// <summary>
        /// オフセット角度を変更した時の処理
        /// </summary>
        private void numericUpDownOffsetWaist_ValueChanged(object sender, EventArgs e)
        {
            motionControl.setOffsetAngle((int)ID.WAIST, (int)numericUpDownOffsetWaist.Value);
            numericUpDownWaist.Minimum = -(int)numericUpDownOffsetWaist.Value;
            numericUpDownWaist_ValueChanged(sender, e);
        }

        /// <summary>
        /// オフセット角度を変更した時の処理
        /// </summary>
        private void numericUpDownOffsetLeftShoulderPitch_ValueChanged(object sender, EventArgs e)
        {
            motionControl.setOffsetAngle((int)ID.LEFT_SHOULDER_PITCH, (int)numericUpDownOffsetLeftShoulderPitch.Value);
            numericUpDownLeftShoulderPitch.Minimum = -(int)numericUpDownOffsetLeftShoulderPitch.Value;
            numericUpDownLeftShoulderPitch_ValueChanged(sender, e);
        }

        /// <summary>
        /// オフセット角度を変更した時の処理
        /// </summary>
        private void numericUpDownOffsetLeftShoulderRoll_ValueChanged(object sender, EventArgs e)
        {
            motionControl.setOffsetAngle((int)ID.LEFT_SHOULDER_ROLL, (int)numericUpDownOffsetLeftShoulderRoll.Value);
            numericUpDownLeftShoulderRoll.Minimum = -(int)numericUpDownOffsetLeftShoulderRoll.Value;
            numericUpDownLeftShoulderRoll_ValueChanged(sender, e);
        }

        /// <summary>
        /// オフセット角度を変更した時の処理
        /// </summary>
        private void numericUpDownOffsetLeftElbowPitch_ValueChanged(object sender, EventArgs e)
        {
            motionControl.setOffsetAngle((int)ID.LEFT_ELBOW_PITCH, (int)numericUpDownOffsetLeftElbowPitch.Value);
            numericUpDownLeftElbowPitch.Minimum = -(int)numericUpDownOffsetLeftElbowPitch.Value;
            numericUpDownLeftElbowPitch_ValueChanged(sender, e);
        }

        /// <summary>
        /// オフセット角度を変更した時の処理
        /// </summary>
        private void numericUpDownOffsetRightShoulderPitch_ValueChanged(object sender, EventArgs e)
        {
            motionControl.setOffsetAngle((int)ID.RIGHT_SHOULDER_PITCH, (int)numericUpDownOffsetRightShoulderPitch.Value);
            numericUpDownRightShoulderPitch.Minimum = -(int)numericUpDownOffsetRightShoulderPitch.Value;
            numericUpDownRightShoulderPitch_ValueChanged(sender, e);
        }

        /// <summary>
        /// オフセット角度を変更した時の処理
        /// </summary>
        private void numericUpDownOffsetRightShoulderRoll_ValueChanged(object sender, EventArgs e)
        {
            motionControl.setOffsetAngle((int)ID.RIGHT_SHOULDER_ROLL, (int)numericUpDownOffsetRightShoulderRoll.Value);
            numericUpDownRightShoulderRoll.Minimum = -(int)numericUpDownOffsetRightShoulderRoll.Value;
            numericUpDownRightShoulderRoll_ValueChanged(sender, e);
        }

        /// <summary>
        /// オフセット角度を変更した時の処理
        /// </summary>
        private void numericUpDownOffsetRightElbowPitch_ValueChanged(object sender, EventArgs e)
        {
            motionControl.setOffsetAngle((int)ID.RIGHT_ELBOW_PITCH, (int)numericUpDownOffsetRightElbowPitch.Value);
            numericUpDownRightElbowPitch.Minimum = -(int)numericUpDownOffsetRightElbowPitch.Value;
            numericUpDownRightElbowPitch_ValueChanged(sender, e);
        }

        /// <summary>
        /// モーションデータの読み込み
        /// </summary>
        private void buttonFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MOTIONファイル(*.csv) | *.csv";
            ofd.Title = "開く MOTIONファイルを選択して下さい";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                motionControl.readMotionData(ofd.FileName);
                getMotionData();
            }
        }

        /// <summary>
        /// モーションデータの保存
        /// </summary>
        private void buttonFileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "MOTIONファイル(*.csv) | *.csv";
            sfd.Title = "保存する";
            sfd.InitialDirectory = Application.StartupPath;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                motionControl.writeMotionData(sfd.FileName);
            }
        }

        /// <summary>
        /// GUIで表示されているデータを配列に入れて取得
        /// </summary>
        /// <returns>GUIに表示されているモーションデータ(int[])</returns>
        private int[] getData()
        {
            int[] data = new int[dataNum];
            data[0] = 0;
            data[1] = (int)numericUpDownPeriod.Value;
            data[2] = (int)numericUpDownWaist.Value;
            data[3] = (int)numericUpDownLeftShoulderPitch.Value;
            data[4] = (int)numericUpDownLeftShoulderRoll.Value;
            data[5] = (int)numericUpDownLeftElbowPitch.Value;
            data[6] = (int)numericUpDownRightShoulderPitch.Value;
            data[7] = (int)numericUpDownRightShoulderRoll.Value;
            data[8] = (int)numericUpDownRightElbowPitch.Value;
            return data;
        }

        /// <summary>
        /// 追加のボタンが押された時の処理
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int[] data = getData();
            motionControl.addMotionData(data);
            getMotionData();
        }

        /// <summary>
        /// GUIのモーションデータをMotionControlクラスにセットする
        /// </summary>
        private void setMotionData()
        {
            bool isValid = true;

            motionControl.clearMotionData();
            for (int i = 0; i < dataGridViewMotion.Rows.Count - 1; i++)
            {
                int[] data = new int[dataNum];
                isValid = true;
                for (int j = 0; j < dataNum; j++)
                {
                    if (dataGridViewMotion.Rows[i].Cells[j + 1].Value != null)
                    {
                        data[j] = int.Parse(dataGridViewMotion.Rows[i].Cells[j + 1].Value.ToString());
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                if (isValid) motionControl.addMotionData(data);
            }
        }

        /// <summary>
        /// モーションデータをMotionControlクラスからGUIにセットする
        /// </summary>
        private void getMotionData()
        {
            int[] data;
            string[] stData = new string[dataNum];

            dataGridViewMotion.Rows.Clear();
            for (int i = 0; i < motionControl.getMotionCount(); i++)
            {
                data = motionControl.getMotionData(i);
                for (int j = 0; j < data.Count(); j++)
                {
                    stData[j] = data[j].ToString();
                }
                dataGridViewMotion.Rows.Add(i.ToString(), stData[0], stData[1], stData[2], stData[3], stData[4], stData[5], stData[6], stData[7], stData[8]);
            }
        }

        /// <summary>
        /// dataGridViewを変更した時に呼び出されるハンドラ
        /// </summary>
        private void dataGridViewMotion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (motionControl != null) setMotionData();
        }

        /// <summary>
        /// モーションデータの挿入
        /// </summary>
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            int[] data = getData();
            int r = -1;

            foreach (DataGridViewRow row in dataGridViewMotion.SelectedRows)
            {
                r = row.Index;
                motionControl.insertMotionData(row.Index, data);
                break;
            }
            getMotionData();
            if (r != -1)
            {
                dataGridViewMotion.ClearSelection();
                dataGridViewMotion.Rows[r].Selected = true;
            }
        }

        /// <summary>
        /// 腰軸のサーボをON/OFFする
        /// </summary>
        private void checkBoxWaist_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.WAIST, checkBoxWaist.Checked);
        }

        /// <summary>
        /// 左肩ピッチ軸のサーボをON/OFFする
        /// </summary>
        private void checkBoxLeftShoulderPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.LEFT_SHOULDER_PITCH, checkBoxLeftShoulderPitch.Checked);
        }

        /// <summary>
        /// 左肩ロール軸のサーボをON/OFFする
        /// </summary>
        private void checkBoxLeftShoulderRoll_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.LEFT_SHOULDER_ROLL, checkBoxLeftShoulderRoll.Checked);
        }

        /// <summary>
        /// 左肘ピッチ軸のサーボをON/OFFする
        /// </summary>
        private void checkBoxLeftElbowPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.LEFT_ELBOW_PITCH, checkBoxLeftElbowPitch.Checked);
        }

        /// <summary>
        /// 右肩ピッチ軸のサーボをON/OFFする
        /// </summary>
        private void checkBoxRightShoulderPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.RIGHT_SHOULDER_PITCH, checkBoxRightShoulderPitch.Checked);
        }

        /// <summary>
        /// 右肩ロール軸のサーボをON/OFFする
        /// </summary>
        private void checkBoxRightShoulderRoll_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.RIGHT_SHOULDER_ROLL, checkBoxRightShoulderRoll.Checked);
        }

        /// <summary>
        /// 右肘ピッチ軸のサーボをON/OFFする
        /// </summary>
        private void checkBoxRightElbowPitch_CheckedChanged(object sender, EventArgs e)
        {
            motionControl.servoOn((int)ID.RIGHT_ELBOW_PITCH, checkBoxRightElbowPitch.Checked);
        }

        /// <summary>
        /// 削除ボタンを押した時のハンドラ
        /// </summary>
        private void buttonErase_Click(object sender, EventArgs e)
        {
            int r = -1;
            foreach (DataGridViewRow row in dataGridViewMotion.SelectedRows)
            {
                r = row.Index;
                motionControl.deleteMotionData(row.Index);
            }
            getMotionData();
            if (r != -1)
            {
                dataGridViewMotion.ClearSelection();
                dataGridViewMotion.Rows[r].Selected = true;
            }
        }

        /// <summary>
        /// 指定した行の角度まで移動する
        /// </summary>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewMotion.SelectedRows)
            {
                int r = row.Index;
                int[] data = motionControl.getMotionData(r);

                if (!checkBoxTestMode.Checked)
                {
                    for (int i = (int)ID.WAIST; i <= (int)ID.RIGHT_ELBOW_PITCH; i++)
                    {
                        motionControl.sendPeriod((byte)i, (short)data[1]);
                    }
                }

                numericUpDownWaist.Value = data[(int)ID.WAIST - (int)ID.WAIST + 2];
                numericUpDownLeftShoulderPitch.Value = data[(int)ID.LEFT_SHOULDER_PITCH - (int)ID.WAIST + 2];
                numericUpDownLeftShoulderRoll.Value = data[(int)ID.LEFT_SHOULDER_ROLL - (int)ID.WAIST + 2];
                numericUpDownLeftElbowPitch.Value = data[(int)ID.LEFT_ELBOW_PITCH - (int)ID.WAIST + 2];
                numericUpDownRightShoulderPitch.Value = data[(int)ID.RIGHT_SHOULDER_PITCH - (int)ID.WAIST + 2];
                numericUpDownRightShoulderRoll.Value = data[(int)ID.RIGHT_SHOULDER_ROLL - (int)ID.WAIST + 2];
                numericUpDownRightElbowPitch.Value = data[(int)ID.RIGHT_ELBOW_PITCH - (int)ID.WAIST + 2];
                break;
            }
        }

        /// <summary>
        /// モーションの再生
        /// </summary>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            motionControl.playMotion();
        }

        /// <summary>
        /// ESCAPEキーを受け付ける
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                motionControl.stop();
                MessageBox.Show("全てのサーボを停止しました");
            }
        }

        /// <summary>
        /// 腰軸のサーボの角度を変更する
        /// </summary>
        private void numericUpDownWaist_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxWaist.Checked)
            {
                if (numericUpDownWaist.Value > 32767) numericUpDownWaist.Value = 32767;
                motionControl.sendAngle((byte)ID.WAIST, (short)(numericUpDownWaist.Value + numericUpDownOffsetWaist.Value));
            }
        }

        /// <summary>
        /// 左肩ピッチ軸のサーボの角度を変更する
        /// </summary>
        private void numericUpDownLeftShoulderPitch_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxLeftShoulderPitch.Checked)
            {
                if (numericUpDownLeftShoulderPitch.Value > 32767) numericUpDownLeftShoulderPitch.Value = 32767;
                motionControl.sendAngle((byte)ID.LEFT_SHOULDER_PITCH, (short)(numericUpDownLeftShoulderPitch.Value + numericUpDownOffsetLeftShoulderPitch.Value));
            }
        }

        /// <summary>
        /// 左肩ロール軸のサーボの角度を変更する
        /// </summary>
        private void numericUpDownLeftShoulderRoll_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxLeftShoulderRoll.Checked)
            {
                if (numericUpDownLeftShoulderRoll.Value > 32767) numericUpDownLeftShoulderRoll.Value = 32767;
                motionControl.sendAngle((byte)ID.LEFT_SHOULDER_ROLL, (short)(numericUpDownLeftShoulderRoll.Value + numericUpDownOffsetLeftShoulderRoll.Value));
            }
        }

        /// <summary>
        /// 左肘ピッチ軸のサーボの角度を変更する
        /// </summary>
        private void numericUpDownLeftElbowPitch_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxLeftElbowPitch.Checked)
            {
                if (numericUpDownLeftElbowPitch.Value > 32767) numericUpDownLeftElbowPitch.Value = 32767;
                motionControl.sendAngle((byte)ID.LEFT_ELBOW_PITCH, (short)(numericUpDownLeftElbowPitch.Value + numericUpDownOffsetLeftElbowPitch.Value));
            }
        }

        /// <summary>
        /// 右肩ピッチ軸のサーボの角度を変更する
        /// </summary>
        private void numericUpDownRightShoulderPitch_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxRightShoulderPitch.Checked)
            {
                if (numericUpDownRightShoulderPitch.Value > 32767) numericUpDownRightShoulderPitch.Value = 32767;
                motionControl.sendAngle((byte)ID.RIGHT_SHOULDER_PITCH, (short)(numericUpDownRightShoulderPitch.Value + numericUpDownOffsetRightShoulderPitch.Value));
            }
        }

        /// <summary>
        /// 右肩ロール軸のサーボの角度を変更する
        /// </summary>
        private void numericUpDownRightShoulderRoll_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxRightShoulderRoll.Checked)
            {
                if (numericUpDownRightShoulderRoll.Value > 32767) numericUpDownRightShoulderRoll.Value = 32767;
                motionControl.sendAngle((byte)ID.RIGHT_SHOULDER_ROLL, (short)(numericUpDownRightShoulderRoll.Value + numericUpDownOffsetRightShoulderRoll.Value));
            }
        }

        /// <summary>
        /// 右肘ピッチ軸のサーボの角度を変更する
        /// </summary>
        private void numericUpDownRightElbowPitch_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxRightElbowPitch.Checked)
            {
                if (numericUpDownRightElbowPitch.Value > 32767) numericUpDownRightElbowPitch.Value = 32767;
                motionControl.sendAngle((byte)ID.RIGHT_ELBOW_PITCH, (short)(numericUpDownRightElbowPitch.Value + numericUpDownOffsetRightElbowPitch.Value));
            }
        }

        /// <summary>
        /// テストモードをチェックした時に呼び出されるハンドラ
        /// </summary>
        private void checkBoxTestMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTestMode.Checked)
            {
                motionControl.setTestMode(true);
            }
            else
            {
                motionControl.setTestMode(false);
                motionControl.sendPeriod(0xff, (short)numericUpDownPeriod.Value);
            }
        }

        /// <summary>
        /// 周期的(1s毎)に呼び出されるハンドラ
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (motionControl == null) return;
            if (!checkBoxWaist.Checked)
            {
                motionControl.readAngle((int)ID.WAIST);
                if (motionControl.getAngle((int)ID.WAIST) != -1)
                {
                    numericUpDownWaist.Value = motionControl.getAngle((int)ID.WAIST) - numericUpDownOffsetWaist.Value;
                }
                else
                {
                    numericUpDownWaist.Enabled = false;
                }
            }
            if (!checkBoxLeftShoulderPitch.Checked)
            {
                motionControl.readAngle((int)ID.LEFT_SHOULDER_PITCH);
                if (motionControl.getAngle((int)ID.LEFT_SHOULDER_PITCH) != -1)
                {
                    numericUpDownLeftShoulderPitch.Value = motionControl.getAngle((int)ID.LEFT_SHOULDER_PITCH) - numericUpDownOffsetLeftShoulderPitch.Value;
                }
                else
                {
                    numericUpDownLeftShoulderPitch.Enabled = false;
                }
            }
            if (!checkBoxLeftShoulderRoll.Checked)
            {
                motionControl.readAngle((int)ID.LEFT_SHOULDER_ROLL);
                if (motionControl.getAngle((int)ID.LEFT_SHOULDER_ROLL) != -1)
                {
                    numericUpDownLeftShoulderRoll.Value = motionControl.getAngle((int)ID.LEFT_SHOULDER_ROLL) - numericUpDownOffsetLeftShoulderRoll.Value;
                }
                else
                {
                    numericUpDownLeftShoulderRoll.Enabled = false;
                }
            }
            if (!checkBoxLeftElbowPitch.Checked)
            {
                motionControl.readAngle((int)ID.LEFT_ELBOW_PITCH);
                if (motionControl.getAngle((int)ID.LEFT_ELBOW_PITCH) != -1)
                {
                    numericUpDownLeftElbowPitch.Value = motionControl.getAngle((int)ID.LEFT_ELBOW_PITCH) - numericUpDownOffsetLeftElbowPitch.Value;
                }
                else
                {
                    numericUpDownLeftElbowPitch.Enabled = false;
                }
            }
            if (!checkBoxRightShoulderPitch.Checked)
            {
                motionControl.readAngle((int)ID.RIGHT_SHOULDER_PITCH);
                if (motionControl.getAngle((int)ID.RIGHT_SHOULDER_PITCH) != -1)
                {
                    numericUpDownRightShoulderPitch.Value = motionControl.getAngle((int)ID.RIGHT_SHOULDER_PITCH) - numericUpDownOffsetRightShoulderPitch.Value;
                }
                else
                {
                    numericUpDownRightShoulderPitch.Enabled = false;
                }
            }
            if (!checkBoxRightShoulderRoll.Checked)
            {
                motionControl.readAngle((int)ID.RIGHT_SHOULDER_ROLL);
                if (motionControl.getAngle((int)ID.RIGHT_SHOULDER_ROLL) != -1)
                {
                    numericUpDownRightShoulderRoll.Value = motionControl.getAngle((int)ID.RIGHT_SHOULDER_ROLL) - numericUpDownOffsetRightShoulderRoll.Value;
                }
                else
                {
                    numericUpDownRightShoulderRoll.Enabled = false;
                }
            }
            if (!checkBoxRightElbowPitch.Checked)
            {
                motionControl.readAngle((int)ID.RIGHT_ELBOW_PITCH);
                if (motionControl.getAngle((int)ID.RIGHT_ELBOW_PITCH) != -1)
                {
                    numericUpDownRightElbowPitch.Value = motionControl.getAngle((int)ID.RIGHT_ELBOW_PITCH) - numericUpDownOffsetRightElbowPitch.Value;
                }
                else
                {
                    numericUpDownRightElbowPitch.Enabled = false;
                }

            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewMotion.SelectedRows)
            {
                int r = row.Index;
                if (r > 0)
                {
                    dataGridViewMotion.ClearSelection();
                    dataGridViewMotion.Rows[r - 1].Selected = true;
                }
                buttonMove_Click(sender, e);
                break;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewMotion.SelectedRows)
            {
                int r = row.Index;
                if (r < (dataGridViewMotion.Rows.Count - 2))
                {
                    dataGridViewMotion.ClearSelection();
                    dataGridViewMotion.Rows[r + 1].Selected = true;
                }
                buttonMove_Click(sender, e);
                break;
            }
        }

        private void buttonLiftUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (!checkBoxLiftBrake.Checked)
            {
                motionControl.Lift(-(int)numericUpDownLift.Value);
            }
        }

        private void buttonLiftUp_MouseUp(object sender, MouseEventArgs e)
        {
            motionControl.Lift(0);
        }

        private void buttonLiftDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (!checkBoxLiftBrake.Checked)
            {
                motionControl.Lift((int)numericUpDownLift.Value);
            }
        }

        private void buttonLiftDown_MouseUp(object sender, MouseEventArgs e)
        {
            motionControl.Lift(0);
        }
    }
}
