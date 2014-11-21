using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace real_robot_battle
{
    public enum Axis
    {
        X,
        Y,
        Z,
    }

    class Matrix
    {
        double[,] matrix;

        public Matrix()
        {
            matrix = new double[4,4];
        }

        public Matrix(float[,] mat)
        {
            matrix = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = mat[i, j];
                }
            }
        }

        public double this[int i, int j]
        {
            set { this.matrix[i, j] = value; }
            get { return this.matrix[i, j]; }
        }

        public Matrix translate(Axis axis, double angle, double x, double y, double z)
        {
            switch (axis)
            {
                case Axis.X:
                    matrix = new double[4, 4]
                    {{1,0,0,x},
                    {0,Math.Cos(angle),-Math.Sin(angle),y},
                    {0,Math.Sin(angle),Math.Cos(angle),z},
                    {0,0,0,1}};
                    break;
                case Axis.Y:
                    matrix = new double[4, 4]
                    {{Math.Cos(angle),0,Math.Sin(angle),x},
                    {0,1,0,y},
                    {-Math.Sin(angle),0,Math.Cos(angle),z},
                    {0,0,0,1}};
                    break;
                case Axis.Z:
                    matrix = new double[4, 4]
                    {{Math.Cos(angle),-Math.Sin(angle),0,x},
                    {Math.Sin(angle),Math.Cos(angle),0,y},
                    {0,0,1,z},
                    {0,0,0,1}};
                    break;
            }
            return this;
        }

        public static Matrix operator +(Matrix x, Matrix y)
        {
            Matrix res = new Matrix();

            for(int i = 0; i < 4; i ++){
                for(int j = 0; j < 4; j ++){
                    res[i,j] = x[i,j] + y[i,j];
                }
            }
            return res;
        }

        public static Matrix operator -(Matrix x, Matrix y)
        {
            Matrix res = new Matrix();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = x[i, j] - y[i, j];
                }
            }
            return res;
        }

        public static Matrix operator *(Matrix x, Matrix y)
        {
            Matrix res = new Matrix();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        res[i, j] += x[i, k] * y[k, j];
                    }
                }
            }
            return res;
        }
    }
}
