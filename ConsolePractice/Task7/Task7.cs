using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task7
{
    public static class Task7
    {
        private static double a = 10, b = 2, c = 2, d = 10;

        public static Vector2 StartV { get; set; } = new Vector2 { X = 1, Y = 4 };
        public static double Step { get; set; } = 0.01;

        public static double StartT { get; set; } = 0;
        public static int N { get; set; } = 1000;

        static Vector2 Func(double t, Vector2 v)
        {
            return new Vector2
            {
                X = a * v.X - b * v.X * v.Y,
                Y = c * v.X * v.Y - d * v.Y
            };
        }

        public static void GetGeneralRK2Solution(out double[] xs, out double[] ys)
        {
            Task7Math.Func = Func;
            Task7Math.Step = Step;
            Task7Math.StartT = StartT;
            Task7Math.N = N;
            Task7Math.StartV = StartV;
            Task7Math.GeneralRK2Order(out var ts, out var vs);

            xs = new double[N + 1];
            ys = new double[N + 1];

            for (int i = 0; i < vs.Length; i++)
            {
                xs[i] = vs[i].X;
                ys[i] = vs[i].Y;
            }

        }
    }
}
