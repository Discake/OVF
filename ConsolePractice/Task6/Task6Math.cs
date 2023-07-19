using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task6
{
     static class Task6Math
    {
        public static double Min { get; set; }
        public static double Max { get; set; }
        public static int N { get; set; }

        public static double Y0 { get; set; }

        public static Func<double, double, double> Func { get; set; }

        public static void EulerMethod(out double[] xs, out double[] ys)
        {
            double step = (Max - Min) / N;
            xs = new double[N + 1];
            ys = new double[N + 1];
            ys[0] = Y0;
            xs[0] = Min;
            for (int i = 1; i <= N; i++)
            {
                xs[i] = xs[i - 1] + step;
                ys[i] = ys[i - 1] + step * Func(xs[i], ys[i - 1]);
            }
        }

        public static void RK2Order(out double[] xs, out double[] ys)
        {
            double step = (Max - Min) / N;
            xs = new double[N + 1];
            ys = new double[N + 1];
            ys[0] = Y0;
            xs[0] = Min;
            double alpha = 3.0 / 4;
            double oneMinusAlpha = 1 - alpha;
            double hMod = step / (2 * alpha);

            for (int i = 1; i <= N; i++)
            {
                xs[i] = xs[i - 1] + step;
                ys[i] = ys[i - 1] + step * (oneMinusAlpha * Func(xs[i - 1], ys[i - 1]) +
                                            alpha * Func(xs[i - 1] + hMod, ys[i - 1] + hMod * Func(xs[i - 1], ys[i - 1])));
            }
        }

        public static void RK4Order(out double[] xs, out double[] ys)
        {
            double step = (Max - Min) / N;
            xs = new double[N + 1];
            ys = new double[N + 1];
            ys[0] = Y0;
            xs[0] = Min;

            for (int i = 1; i <= N; i++)
            {
                double k1 = Func(xs[i - 1], ys[i - 1]);
                double k2 = Func(xs[i - 1] + step / 2, ys[i - 1] + step * k1 / 2);
                double k3 = Func(xs[i - 1] + step / 2, ys[i - 1] + step * k2 / 2);
                double k4 = Func(xs[i - 1] + step, ys[i - 1] + step * k3);

                xs[i] = xs[i - 1] + step;
                ys[i] = ys[i - 1] + step * (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            }
        }
    }
}
