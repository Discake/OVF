using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task7
{
    public class Vector2
    {
        public double X;
        public double Y;

        public static Vector2 operator *(double left, Vector2 right)
        {
            return new Vector2
            {
                X = left * right.X,
                Y = left * right.Y,
            };
        }
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2
            {
                X = left.X + right.X,
                Y = left.Y + right.Y,
            };
        }
    }
    public static class Task7Math
    {


        public static Func<double, Vector2, Vector2> Func { get; set; }

        public static Vector2 StartV { get; set; }
        public static double StartT { get; set; }
        public static double Step { get; set; }
        public static int N { get; set; }

        public static void GeneralRK2Order(out double[] ts, out Vector2[] vs)
        {
            ts = new double[N + 1];
            vs = new Vector2[N + 1];

            vs[0] = StartV;
            ts[0] = StartT;
            double alpha = 3.0 / 4;
            double oneMinusAlpha = 1 - alpha;
            double hMod = Step / (2 * alpha);

            for (int i = 1; i <= N; i++)
            {
                ts[i] = ts[i - 1] + Step;
                vs[i] = vs[i - 1] + Step * (oneMinusAlpha * Func(ts[i - 1], vs[i - 1]) +
                                            alpha * Func(ts[i - 1] + hMod, vs[i - 1] + hMod * Func(ts[i - 1], vs[i - 1])));
            }
        }
    }
}
