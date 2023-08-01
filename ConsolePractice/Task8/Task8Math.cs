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

        public static double DerrivativeStep = 1e-5;

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

        private static double[] CalculateInversedJacobian(Func<double, double, (double, double)> newFunc, double u, double v)
        {
            double[] jacobian = new double[4];

            (double, double) tuple1 = newFunc(u + DerrivativeStep, v);
            (double, double) tuple2 = newFunc(u, v + DerrivativeStep);
            (double, double) tupleStart = newFunc(u, v);

            jacobian[0] = (tuple1.Item1 - tupleStart.Item1) / DerrivativeStep;
            jacobian[1] = (tuple2.Item1 - tupleStart.Item1) / DerrivativeStep;
            jacobian[2] = (tuple1.Item2 - tupleStart.Item2) / DerrivativeStep;
            jacobian[3] = (tuple2.Item2 - tupleStart.Item2) / DerrivativeStep;

            double determinant = jacobian[0] * jacobian[3] - jacobian[1] * jacobian[2];

            double[] inversedJacobian = new double[4];
            inversedJacobian[0] = jacobian[0] / determinant;
            inversedJacobian[3] = jacobian[3] / determinant;
            inversedJacobian[1] = jacobian[2] / determinant;
            inversedJacobian[2] = jacobian[1] / determinant;

            return inversedJacobian;
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

                Func<double, double, (double, double)> newFunc = (u_, v_) =>
                {
                    var tupleF = Func(u[i - 1], v[i - 1]);
                    var tupleFnew = Func(u_, v_);
                    double newU = u[i - 1] + h * tupleF.Item1 / 2 + h * tupleF.Item1 - u_;
                    double newV = v[i - 1] + h * tupleF.Item2 / 2 + h * tupleF.Item2 - v_;

                    return (newU, newV);
                };

                var invJac = CalculateInversedJacobian(newFunc, u[i - 1], v[i - 1]);

                var newFuncCurrent = newFunc(u[i - 1], v[i - 1]);

                u[i] = u[i - 1] - invJac[0] * newFuncCurrent.Item1 - invJac[1] * newFuncCurrent.Item2;
                v[i] = v[i - 1] - invJac[2] * newFuncCurrent.Item1 - invJac[3] * newFuncCurrent.Item2;
            }

            return (u, v, t);
        }
    }
}
