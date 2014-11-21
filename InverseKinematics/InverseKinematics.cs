using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using real_robot_battle;

namespace real_robot_battle
{
    class InverseKinematics
    {
        public enum ID
        {        
            WAIST = 5,
            LEFT_SHOULDER_PITCH,
            LEFT_SHOULDER_ROLL,
            LEFT_ELBOW_PITCH,
            RIGHT_SHOULDER_PITCH,
            RIGHT_SHOULDER_ROLL,
            RIGHT_ELBOW_PITCH,
            LIFT_LEFT,
            LIFT_RIGHT,
        };

        const double l1 = 0.5;
        const double l2 = 0.4;
        const double l3 = 0.4;

        Matrix t1 = new Matrix();
        Matrix t2 = new Matrix();
        Matrix t3 = new Matrix();
        Matrix t4 = new Matrix();
        Matrix t5 = new Matrix();
        Matrix hand = new Matrix();
        Matrix transWaist = new Matrix();
        Matrix handFromWaist = new Matrix();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InverseKinematics()
        {
        }

        /// <summary>
        /// 運動学．角度から位置を計算する．原点は腰軸，角度は脚前を0degとする．
        /// </summary>
        /// <param name="angle">角度(deg)</param>
        /// <returns>手先の位置(m) (x:前＋, y:左＋, z:)</returns>
        public double[] getRightHandPosition(double[] angle)
        {
            double[] pos = new double[3];
            t1.translate(Axis.Z, radian(angle[ID.WAIST - ID.WAIST]), 0, 0, 0);
            t2.translate(Axis.Y, -radian(angle[ID.RIGHT_SHOULDER_PITCH - ID.WAIST]), 0, -l1, 0);
            t3.translate(Axis.X, radian(angle[ID.RIGHT_SHOULDER_ROLL - ID.WAIST]), 0, 0, 0);
            t4.translate(Axis.Y, -radian(angle[ID.RIGHT_ELBOW_PITCH - ID.WAIST]), 0, 0, -l2);
            t5.translate(Axis.X, 0, 0, 0, -l3);
            t2 = t1 * t2;
            t3 = t2 * t3;
            t4 = t3 * t4;
            Matrix res = t4 * t5;
            pos[0] = res[0, 3];
            pos[1] = res[1, 3];
            pos[2] = res[2, 3];
            return pos;
        }

        /// <summary>
        /// 運動学．角度から位置を計算する．原点は腰軸，角度は脚前を0degとする．
        /// </summary>
        /// <param name="angle">角度(deg)</param>
        /// <returns>手先の位置(m) (x:前＋, y:左＋, z:)</returns>
        public double[] getLeftHandPosition(double[] angle)
        {
            double[] pos = new double[3];
            t1.translate(Axis.Z, radian(angle[(int)ID.WAIST - (int)ID.WAIST]), 0, 0, 0);
            t2.translate(Axis.Y, -radian(angle[ID.LEFT_SHOULDER_PITCH - ID.WAIST]), 0, l1, 0);
            t3.translate(Axis.X, radian(angle[ID.LEFT_SHOULDER_ROLL - ID.WAIST]), 0, 0, 0);
            t4.translate(Axis.Y, -radian(angle[ID.LEFT_ELBOW_PITCH - ID.WAIST]), 0, 0, -l2);
            t5.translate(Axis.X, 0, 0, 0, -l3);
            t2 = t1 * t2;
            t3 = t2 * t3;
            t4 = t3 * t4;
            Matrix res = t4 * t5;
            pos[0] = res[0, 3];
            pos[1] = res[1, 3];
            pos[2] = res[2, 3];
            return pos;
        }

        public double[] getPartPosition(int part)
        {
            double[] pos = new double[3];
            switch (part)
            {
                case 0:
                    pos[0] = t2[0, 3];
                    pos[1] = t2[1, 3];
                    pos[2] = t2[2, 3];
                    break;
                case 1:
                    pos[0] = t4[0, 3];
                    pos[1] = t4[1, 3];
                    pos[2] = t4[2, 3];
                    break;
            }
            
            return pos;
        }

        /// <summary>
        /// 左腕の逆運動学を計算．腰の角度は指定
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="waist_angle">腰の角度</param>
        /// <returns>左腕の関節角度（左肩ピッチ，左肩ロール，左肘ピッチ）</returns>
        double q3 = 0;
        public double[] getLeftArmAngle(double[] pos, double waist_angle)
        {
            double[] angle = new double[3];
            double x, y, z;

            // 手先の位置を腰中心に変換する
            transWaist.translate(Axis.Z, -radian(waist_angle), 0, 0, 0);
            hand.translate(Axis.X, 0, pos[0], pos[1], pos[2]);

            handFromWaist = transWaist * hand;
            x = handFromWaist[0, 3];
            y = handFromWaist[1, 3] - l1;
            z = handFromWaist[2, 3];
            if (y < 0) y = 0;

            // 逆運動学の計算
            double l = Math.Sqrt(x * x + y * y + z * z);
            if (l > (l2 + l3)) l = l2 + l3;     // 長い場合は制限を入れる
            double q4 = Math.PI - Math.Acos((l * l - l2 * l2 - l3 * l3) / (-2.0 * l2 * l3));
            double z0 = -l2 + l3 * Math.Cos(Math.PI - q4);
            if (z0 != 0)    // z0 = 0の場合は，前の角度を維持
            {
                if (y > -z0) y = -z0;
                q3 = -Math.Asin(y / z0);
            }
            double x1 = l3 * Math.Sin(q4);
            double z1 = z0 * Math.Cos(q3);
            double the1 = Math.Atan2(x1, z1);
            double the = Math.Atan2(x, z);
            double q2 = - (the - the1);

            angle[ID.LEFT_SHOULDER_PITCH - ID.LEFT_SHOULDER_PITCH] = degree(q2);
            angle[ID.LEFT_SHOULDER_ROLL - ID.LEFT_SHOULDER_PITCH] = degree(q3);
            angle[ID.LEFT_ELBOW_PITCH - ID.LEFT_SHOULDER_PITCH] = degree(q4);

            return angle;
        }

        /// <summary>
        /// 右腕の逆運動学を計算．腰の角度は指定
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="waist_angle">腰の角度</param>
        /// <returns>右腕の関節角度（右肩ピッチ，右肩ロール，右肘ピッチ）</returns>
        public double[] getRightArmAngle(double[] pos, double waist_angle)
        {
            double[] angle = new double[3];
            double x, y, z;

            // 手先の位置を腰中心に変換する
            transWaist.translate(Axis.Z, -radian(waist_angle), 0, 0, 0);
            hand.translate(Axis.X, 0, pos[0], pos[1], pos[2]);
            handFromWaist = transWaist * hand;
            x = handFromWaist[0, 3];
            y = handFromWaist[1, 3] + l1;
            z = handFromWaist[2, 3];
            if (y > 0) y = 0;

            // 逆運動学の計算
            double l = Math.Sqrt(x * x + y * y + z * z);
            if (l > (l2 + l3)) l = l2 + l3;     // 長い場合は制限を入れる
            double q4 = Math.PI - Math.Acos((l * l - l2 * l2 - l3 * l3) / (-2.0 * l2 * l3));
            double z0 = -l2 + l3 * Math.Cos(Math.PI - q4);
            if (z0 != 0)    // z0 = 0の場合は，前の角度を維持
            {
                if (y < z0) y = z0;
                q3 = -Math.Asin(y / z0);
            }
            double x1 = l3 * Math.Sin(q4);
            double z1 = z0 * Math.Cos(q3);
            double the1 = Math.Atan2(x1, z1);
            double the = Math.Atan2(x, z);
            double q2 = -(the - the1);
            
            
/*            
            // 逆運動学の計算
            double l = Math.Sqrt(x * x + y * y + z * z);
            if (l > (l2 + l3)) l = l2 + l3;
            double q4 = Math.PI - Math.Acos((l * l - l2 * l2 - l3 * l3) / (-2.0 * l2 * l3));
            double q3 = Math.Atan2(y, -z);
            double q2d = Math.Acos((l3 * l3 - l * l - l2 * l2) / (-2.0 * l * l2));
            double q2a = Math.Atan2(x, Math.Sqrt(y * y + z * z));
            double q2 = q2a - q2d;
*/

            angle[ID.RIGHT_SHOULDER_PITCH - ID.RIGHT_SHOULDER_PITCH] = degree(q2);
            angle[ID.RIGHT_SHOULDER_ROLL - ID.RIGHT_SHOULDER_PITCH] = degree(q3);
            angle[ID.RIGHT_ELBOW_PITCH - ID.RIGHT_SHOULDER_PITCH] = degree(q4);

            return angle;
        }

        private double radian(double deg)
        {
            while(deg >  180) deg -= 360;
            while(deg < -180) deg += 360;
            return ((double)(deg / 180.0 * Math.PI));
        }

        private double degree(double rad)
        {
            while (rad > Math.PI) rad -= (float)(Math.PI * 2.0);
            while (rad < -Math.PI) rad += (float)(Math.PI * 2.0);
            return ((double)(rad / Math.PI * 180.0));
        }
    }
}
