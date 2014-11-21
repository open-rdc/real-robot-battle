using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using real_robot_battle;

namespace Battle
{
    public partial class FormBattle : Form
    {
        int timer = 100000;
        enum PunchProcess
        {
            elbow,
            extend,
            keep,
            finish,
        }
        PunchProcess punchProcess = PunchProcess.extend;
        bool isNowMotion = false;

        /// <summary>
        /// 周期的(100ms)に呼び出される上半身の制御
        /// </summary>
        private void autoMotionProcess(bool nowMotion)
        {
            const int period = 15000;                    // 動きの周期(ms)
            const int elbowPeriod = 2000;               // パンチを出す時間，戻す時間(ms)
            const int punchPeriod = 1000;               // パンチを出す時間，戻す時間(ms)
            const int holdPeriod = 1500;                // 手を伸ばしている時間(ms)
            const int returnPeriod = 2000;               // パンチを出す時間，戻す時間(ms)
            const int sideAngle = 45;                   // 10deg(チェック用の値）
            const double shoulder_height = 1605;        // 地面から肩ピッチ軸の高さ(mm)
            const double shoulder_elbow = 448;          // 肩ロール軸から肩軸の距離(mm)
            const double elbow_hand = 540;              // 肩軸から手先までの距離(mm)
            const double shoulder_width = 627;          // 中心軸から肩ロール軸までの距離(mm)
            double center_to_hand = shoulder_width + shoulder_elbow + elbow_hand; // 中心軸からハンドまでの距離(mm)
            const double back_angle = 15;               // パンチの前に下る角度

            // タッチした場所の取得
            int targetY = pictureBoxAttackPoint.getAttackX();
            int targetZ = pictureBoxAttackPoint.getAttackY();
            // 肩のロール軸の角度の計算
            double roll_angle = degree(Math.Acos(-(targetZ - shoulder_height) / (shoulder_elbow + elbow_hand)));
            // 腰のヨー軸の角度の計算
            double yaw_angle = degree(Math.Asin(targetY / center_to_hand));
            
            // モーションを再生していない時にタッチをするとパンチを再生
            if (nowMotion)
            {
                if (!isNowMotion)
                {
                    timer = period;     // 次の動きを発生させる時間を代入する
                    if (nowMotion){
                        timer = elbowPeriod + punchPeriod;
                        punchProcess = PunchProcess.extend;
                    }
                }
            }

            // 1周期の時間が経過した場合，再度パンチを再生
            if (timer >= period)
            {
                timer = 0;
                punchProcess = PunchProcess.elbow;
                nowMotion = true;
            }
            // 保持時間(elbowPeriod)後に元に戻る
            if (timer > (elbowPeriod))
            {
                punchProcess = PunchProcess.extend;
            }
            // 保持時間(elbowPeriod)後に元に戻る
            if (timer > (elbowPeriod+punchPeriod+holdPeriod))
            {
                punchProcess = PunchProcess.finish;
            }
            // パンチが終了した時の設定
            if (timer > (elbowPeriod + punchPeriod + holdPeriod + punchPeriod))
            {
                nowMotion = false;
            }
            timer += 100;                                   // 100msec毎に呼び出すため，timerに100を加算する

            if (radioButtonLeft.Checked)                    // 左前に敵がいる場合
            {
                if (punchProcess == PunchProcess.elbow)    // 手を伸ばしているときの挙動
                {
                    motionControl.sendAngleDeg((int)ID.WAIST, (int)yaw_angle + sideAngle, elbowPeriod);        // 右に体を向ける
                    motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_PITCH, 0, elbowPeriod);       // 左手を伸ばす
                    motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_ROLL, (int)roll_angle, elbowPeriod);
                    motionControl.sendAngleDeg((int)ID.LEFT_ELBOW_PITCH, -60, elbowPeriod);
                }
                else if (punchProcess == PunchProcess.extend)                                       // 手を縮めているときの挙動
                {
                    motionControl.sendAngleDeg((int)ID.WAIST, (int)yaw_angle + sideAngle, punchPeriod);        // 右に体を向ける
                    motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_PITCH, 0, punchPeriod);       // 左手を伸ばす
                    motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_ROLL, (int)roll_angle, punchPeriod);
                    motionControl.sendAngleDeg((int)ID.LEFT_ELBOW_PITCH, -2, punchPeriod);
                }
                else
                {
                    motionControl.sendAngleDeg((int)ID.WAIST, (int)(yaw_angle + sideAngle - back_angle), returnPeriod);     // 右に体を向ける
                    motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_PITCH, 0, returnPeriod);       // 左手を伸ばす
                    motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_ROLL, 15, returnPeriod);
                    motionControl.sendAngleDeg((int)ID.LEFT_ELBOW_PITCH, -70, returnPeriod);
                }
                motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_PITCH, 0, punchPeriod);    // 右手はファイティングポース
                motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_ROLL, 15, punchPeriod);
                motionControl.sendAngleDeg((int)ID.RIGHT_ELBOW_PITCH, -70, punchPeriod);
            }
            else if (radioButtonRight.Checked)              // 右前に敵がいる場合
            {
                if (punchProcess == PunchProcess.elbow)    // 手を伸ばしているときの挙動
                {
                    motionControl.sendAngleDeg((int)ID.WAIST, (int)yaw_angle - sideAngle, elbowPeriod);       // 左に体を向ける
                    motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_PITCH, 0, elbowPeriod);      // 右手を伸ばす．
                    motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_ROLL, (int)roll_angle, elbowPeriod);
                    motionControl.sendAngleDeg((int)ID.RIGHT_ELBOW_PITCH, -60, elbowPeriod);
                }
                else if (punchProcess == PunchProcess.extend)    // 手を伸ばしている時の挙動
                {
                    motionControl.sendAngleDeg((int)ID.WAIST, (int)yaw_angle - sideAngle, punchPeriod);       // 左に体を向ける
                    motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_PITCH, 0, punchPeriod);      // 右手を伸ばす．
                    motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_ROLL, (int)roll_angle, punchPeriod);
                    motionControl.sendAngleDeg((int)ID.RIGHT_ELBOW_PITCH, -2, punchPeriod);
                }
                else                                        // 手を縮めている時の挙動
                {
                    motionControl.sendAngleDeg((int)ID.WAIST, (int)(yaw_angle - sideAngle + back_angle), returnPeriod);    // 左に体を向ける
                    motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_PITCH, 0, returnPeriod);      // 右手を伸ばす．
                    motionControl.sendAngleDeg((int)ID.RIGHT_SHOULDER_ROLL, 15, returnPeriod);
                    motionControl.sendAngleDeg((int)ID.RIGHT_ELBOW_PITCH, -70, returnPeriod);
                }
                motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_PITCH, 0, punchPeriod);           // 左手はファイティングポース
                motionControl.sendAngleDeg((int)ID.LEFT_SHOULDER_ROLL, 15, punchPeriod);
                motionControl.sendAngleDeg((int)ID.LEFT_ELBOW_PITCH, -70, punchPeriod);
            }
            else
            {
                initialPose();                                                                      // 初期位置に戻す
            }
        }
    }
}
