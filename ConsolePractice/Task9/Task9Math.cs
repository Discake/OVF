using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task9
{
    public static class Task9Math
    {
        public static int N { get; set; }

        public static double[] Dvector { get; set; }
        public static double[] Avector { get; set; }

        public static double[] Bvector { get; set; }
        public static double[] Cvector { get; set; }

        public static double Ksi(double ai, double biMinus1)
        {
            return ai / biMinus1;
        }

        public static double GetYn(double dn, double bn)
        {
            return dn / bn;
        }

        public static void StraightItteration(int i)
        {
            var ksi = Ksi(Avector[i], Bvector[i - 1]);
            Bvector[i] -= ksi * Cvector[i - 1];
            Dvector[i] -= ksi * Dvector[i - 1];
        }

        public static double ReverseItteration(int i, double ynPlus1)
        {
            return (Dvector[i] - Cvector[i] * ynPlus1) / Bvector[i];
        }

        public static void StraightStroke()
        {
            for (int i = 1; i < N; i++)
            {
                StraightItteration(i);
            }
        }

        public static void ReverseStroke(out double[] ys)
        {
            ys = new double[N];
            //ys[N - 1] = Dvector[N - 1] / Bvector[N - 1];
            ys[N - 1] = 1;
            for (int i = 0; i < N - 1; i++)
            {
                ys[N - 2 - i] = ReverseItteration(N - 2 - i, ys[N - 1 - i]);
            }
        }
    }
}
