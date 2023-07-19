using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public static class Task5
    {
        public static int N = 4;
        public static Task5Math.LagrangianPolynomial lp = new Task5Math.LagrangianPolynomial();

        static double Func(double x)
        {
            return 1 / (1 + x * x);
        }

        public static void PointsForInterpolation(out double[] xs, out double[] ys)
        {
            xs = new double[N + 1];
            ys = new double[N + 1];
            for (int k = 0; k <= N; k++)
            {
                xs[k] = -5 + k * 10.0 / N;
                ys[k] = Func(xs[k]);
            }
        }

        public static void InterpolatedPoints(out double[] xs, out double[] ys, int n = 100)
        {
            double[] pfiX, pfiY;
            PointsForInterpolation(out pfiX,out pfiY);
            lp.Xs = pfiX;
            lp.Ys = pfiY;

            xs = new double[n + 1];
            ys = new double[n + 1];
            double step = (pfiX.Last() - pfiX[0]) / n;
            for (int i = 0; i <= n; i++)
            {
                double x = i * step + pfiX[0];
                xs[i] = x;
                ys[i] = lp.Evaluate(x);
            }
        }

        public static void lpMinusYk(int k, ref double[] xs, ref double[] ys)
        {
            double xk = -5 + k * 10.0 / N;
            int n = xs.Length;
            double[] xsNew = new double[n + 1];
            double[] ysNew = new double[n + 1];
            double fk = Func(xk);

            for (int i = 0; i < n; i++)
            {
                xsNew[i] = xs[i];
                ysNew[i] = ys[i] - fk;
            }
            xsNew[n] = xk;
            ysNew[n] = lp.Evaluate(xk) - fk;
            xs = xsNew;
            ys = ysNew;
        }
    }
}
