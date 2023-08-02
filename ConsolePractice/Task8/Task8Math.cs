using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task8
{
    public static class Task8Math
    {
        public static double Min, Max;
        public static double U0, V0;
        public static int N;
        private static double h;
        public static Func<double, double, (double, double)> Func;

        public static double DerrivativeStep = 1e-7;

        public static (double[] u, double[] v, double[] t) ExplicitScheme1()
        {
            h = (Max - Min) / N;

            double[] u = new double[N + 1];
            double[] v = new double[N + 1];
            double[] t = new double[N + 1];
            u[0] = U0;
            v[0] = V0;
            t[0] = Min;

            for (int i = 1; i < N + 1; i++)
            {
                t[i] = t[i - 1] + h;
                (double, double) tuple;
                tuple = Func(u[i - 1], v[i - 1]);
                u[i] = u[i - 1] + tuple.Item1 * h;
                v[i] = v[i - 1] + tuple.Item2 * h;
            }

            return (u, v, t);
        }

        private static double[] CalculateJacobian(Func<double, double, (double, double)> newFunc, double u, double v)
        {
            double[] jacobian = new double[4];

            (double, double) tuple1 = newFunc(u + DerrivativeStep, v);
            (double, double) tuple2 = newFunc(u, v + DerrivativeStep);
            (double, double) tupleStart = newFunc(u, v);

            jacobian[0] = (tuple1.Item1 - tupleStart.Item1) / DerrivativeStep;
            jacobian[1] = (tuple2.Item1 - tupleStart.Item1) / DerrivativeStep;
            jacobian[2] = (tuple1.Item2 - tupleStart.Item2) / DerrivativeStep;
            jacobian[3] = (tuple2.Item2 - tupleStart.Item2) / DerrivativeStep;

            return jacobian;
        }

        private static double[] Inverse(double[] matrix)
        {

            double determinant = matrix[0] * matrix[3] - matrix[1] * matrix[2];

            double[] inversed = new double[4];
            inversed[0] = matrix[3] / determinant;
            inversed[1] = -matrix[1] / determinant;
            inversed[2] = -matrix[2] / determinant;
            inversed[3] = matrix[0] / determinant;

            return inversed;
        }

        public static (double[] u, double[] v, double[] t) ImplicitScheme1()
        {
            h = (Max - Min) / N;

            double[] u = new double[N + 1];
            double[] v = new double[N + 1];
            double[] t = new double[N + 1];
            u[0] = U0;
            v[0] = V0;
            t[0] = Min;
            for (int i = 1; i < N + 1; i++)
            {
                t[i] = t[i - 1] + h;
                var oldu = u[i - 1];
                var oldv = v[i - 1];

                Func<double, double, (double, double)> newFunc = (u_, v_) =>
                {
                    var u1 = u[i - 1];
                    var v1 = v[i - 1];
                    var tupleF = Func(u1, v1);
                    var tupleFnew = Func(u_, v_);
                    double newU = u1 + h * tupleF.Item1 / 2 + h * tupleFnew.Item1 / 2 - u_;
                    double newV = v1 + h * tupleF.Item2 / 2 + h * tupleFnew.Item2 / 2 - v_;

                    return (newU, newV);
                };
                var temp1 = u[i - 1];
                var temp2 = v[i - 1];
                for (int j = 0; j < 3; j++)
                {
                    
                    var invJac = Inverse(CalculateJacobian(newFunc, temp1, temp2));

                    var newFuncCurrent = newFunc(temp1, temp2);


                    temp1 = temp1 - invJac[0] * newFuncCurrent.Item1 - invJac[1] * newFuncCurrent.Item2;
                    temp2 = temp2 - invJac[2] * newFuncCurrent.Item1 - invJac[3] * newFuncCurrent.Item2;
                }

                u[i] = temp1;
                v[i] = temp2;
                u[i - 1] = oldu;
                v[i - 1] = oldv;
            }

            return (u, v, t);
        }

        public static (double[] u, double[] v, double[] t) ImplicitScheme1NewVariant()
        {
            h = (Max - Min) / N;

            double[] u = new double[N + 1];
            double[] v = new double[N + 1];
            double[] t = new double[N + 1];
            u[0] = U0;
            v[0] = V0;
            t[0] = Min;
            for (int i = 1; i < N + 1; i++)
            {
                t[i] = t[i - 1] + h;

                var jac = CalculateJacobian(Func, u[i - 1], v[i - 1]);
                double[] matrix = new double[4];
                matrix[0] = 1 - h * jac[0];
                matrix[1] = -h * jac[1];
                matrix[2] = -h * jac[2];
                matrix[3] = 1 - h * jac[3];

                var inversed = Inverse(matrix);

                var tupleF = Func(u[i - 1], v[i - 1]);

                u[i] = u[i - 1] + h * inversed[0] * tupleF.Item1 + inversed[1] * tupleF.Item2;
                v[i] = v[i - 1] + h * inversed[2] * tupleF.Item1 + inversed[3] * tupleF.Item2;
            }

            return (u, v, t);
        }
    }
}
