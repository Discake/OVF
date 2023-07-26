using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsolePractice.Task9
{
    public static class Task9
    {
        public static int N { get; set; } = 100;

        private static double h;
        private static List<double> Dvector = new List<double>();
        private static List<double> Avector = new List<double>();
        private static List<double> Bvector = new List<double>();
        private static List<double> Cvector = new List<double>();

        //m1 * y(a) + m2 * y'(a) = m =>
        //m1 y0 + m2 (y1 - y0)/h = m =>
        //BVector[0] = m1 - m2 / h, Cvector[0] = m2 / h, Dvector[0] = m

        //n1 * y(b) + n2 * y'(b) = n
        //n1 yn + n2 (yn - y(n-1)) / h = n
        //Avector[N] = -n2 / h, Bvector[N] = n1 + n2 / h, Dvector[N] = n

        public static double m1, m2, m, n1, n2, n;

        public static bool condition1, condition2;

        static double Solution(double x, double A, double B)
        {
            return A * x + B - Math.Cos(x);
        }

        public static double[] CreateUniformMesh()
        {
            h = Math.PI / N;

            condition1 = Math.Abs(m1 - m2 / h) > Math.Abs(m2 / h);
            condition2 = Math.Abs(n1 + n2 / h) > Math.Abs(-n2 / h);

            double[] xs = new double[N + 1];

            for (int i = 0; i < N + 1; i++)
            {
                xs[i] = -Math.PI * 0.5 + i * h;
            }

            return xs;
        }

        static void FillDvector()
        {
            var xs = CreateUniformMesh();

            //Dvector.Add(m);
            Dvector.Add(m*h/(m1*h-m2));

            for (int i = 1; i < N; i++)
            {
                Dvector.Add(Math.Cos(xs[i]));
            }

            Dvector.Add(n*h/n2);
            //Dvector.Add(n);
        }

        static void FillOtherVectors()
        {
            /*Avector.Add(0);
            Bvector.Add(m1 - m2 / h);
            Cvector.Add(m2 / h);*/

            Avector.Add(0);
            Bvector.Add(1);
            Cvector.Add(m2/(m1*h - m2));

            for (int i = 1; i < N; i++)
            {
                Avector.Add(1 / (h * h));
                Cvector.Add(1 / (h * h));
                Bvector.Add(-2 / (h * h));
            }

            Avector.Add(1);
            Bvector.Add(-(n1*h+n2)/n2);
            Cvector.Add(0);

            /*Avector.Add(-n2 / h);
            Bvector.Add(n1 + n2 / h);
            Cvector.Add(0);*/
        }

        public static double[] Solve()
        {
            FillDvector();
            FillOtherVectors();

            //Прямой ход
            for (int i = 1; i < Dvector.Count - 1; i++)
            {
                double ksi = Avector[i] / Bvector[i - 1];
                Avector[i] = 0;
                Bvector[i] = Bvector[i] - ksi * Cvector[i - 1];
                Dvector[i] = Dvector[i] - ksi * Dvector[i - 1];
            }

            List<double> solution = new List<double>();
            solution.Add(Dvector.Last() / Bvector.Last());

            //Обратный ход
            for (int i = Dvector.Count - 2; i >= 0; i--)
            {
                var temp = (1 / Bvector[i]) * (Dvector[i] - Cvector[i] * solution.Last());
                solution.Add(temp);
            }

            solution.Reverse();
            return solution.ToArray();
        }

        public static double[] ExactSolution(double[] xs)
        {
            double k1 = m1 / (m2 - Math.PI * m1 / 2);
            double k2 = n1 / (n2 + Math.PI * n1 / 2);
            double k3 = (m + m2) / (m2 - Math.PI * m1 / 2);
            double k4 = (n - n2) / (n2 + Math.PI * n1 / 2);

            double B = (k4 - k3) / (k2 - k1);
            double A = k3 - k1 * B;

            double[] ys = new double[xs.Length];
            for (int i = 0; i < xs.Length; i++)
            {
                ys[i] = Solution(xs[i], A, B);
            }

            return ys;
        }
    }
}
