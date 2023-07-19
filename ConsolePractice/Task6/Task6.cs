using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task6
{
    public static class Task6
    {
        public static int N { get; set; }

        private static double min = 0;
        private static double max = 3;
        private static double y0 = 1;
        public static double Function(double t, double x)
        {
            return -x;
        }

        public static double Solution(double t)
        {
            return Math.Exp(-t);
        }

        public static void GetSolution(out double[] xs, out double[] ys)
        {
            double step = (max - min) / N;
            xs = new double[N + 1];
            ys = new double[N + 1];
            for (int i = 0; i <= N; i++)
            {
                xs[i] = min + step * i;
                ys[i] = Solution(xs[i]);
            }
        }

        public static void GetEulersMethodSolution(out double[] xs, out double[] ys)
        {
            Task6Math.Func = Function;
            Task6Math.Max = max;
            Task6Math.Min = min;
            Task6Math.N = N;
            Task6Math.Y0 = y0;
            Task6Math.EulerMethod(out xs, out ys);
        }

        public static void GetRK2MethodSolution(out double[] xs, out double[] ys)
        {
            Task6Math.Func = Function;
            Task6Math.Max = max;
            Task6Math.Min = min;
            Task6Math.N = N;
            Task6Math.Y0 = y0;
            Task6Math.RK2Order(out xs, out ys);
        }

        public static void GetRK4MethodSolution(out double[] xs, out double[] ys)
        {
            Task6Math.Func = Function;
            Task6Math.Max = max;
            Task6Math.Min = min;
            Task6Math.N = N;
            Task6Math.Y0 = y0;
            Task6Math.RK4Order(out xs, out ys);
        }
    }
}
