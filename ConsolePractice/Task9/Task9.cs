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

        public static double[] CreateUniformMesh()
        {
            h = Math.PI / N;
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

            Dvector.Add(m);

            for (int i = 1; i < N; i++)
            {
                Dvector.Add(Math.Cos(xs[i]));
            }

            Dvector.Add(n);
        }

        static void FillOtherVectors()
        {
            Avector.Add(0);
            Bvector.Add(m1 - m2 / h);
            Cvector.Add(m2 / h);
            for (int i = 1; i < N; i++)
            {
                Avector.Add(1 / (h * h));
                Cvector.Add(1 / (h * h));
                Bvector.Add(-2 / (h * h));
            }
            Avector.Add(-n2 / h);
            Bvector.Add(n1 + n2 / h);
            Cvector.Add(0);
        }

        public static double[] Solve()
        {
            FillDvector();
            FillOtherVectors();

            for (int i = 1; i < Dvector.Count - 1; i++)
            {
                double ksi = Avector[i] / Bvector[i - 1];
                Avector[i] = 0;
                Bvector[i] = Bvector[i] - ksi * Cvector[i - 1];
                Dvector[i] = Dvector[i] - ksi * Dvector[i - 1];
            }

            List<double> solution = new List<double>();
            solution.Add(Dvector.Last() / Bvector.Last());
            for (int i = Dvector.Count - 2; i >= 0; i--)
            {
                var temp = (1 / Bvector[i]) * (Dvector[i] - Cvector[i] * solution.Last());
                solution.Add(temp);
            }

            //solution.Reverse();
            return solution.ToArray();
        }

        public static void GetSolution(out double[] xs, out double[] ys)
        {
            /*FillDvector();
            FillOtherVectors();
            Task9Math.Avector = Avector;
            Task9Math.Bvector = Bvector;
            Task9Math.Cvector = Cvector;
            Task9Math.Dvector = Dvector;
            Task9Math.N = N + 1;
            Task9Math.StraightStroke();
            Task9Math.ReverseStroke(out var solution);*/

            SecondOrderEquation equation = new SecondOrderEquation();
            equation.a = -Math.PI * 0.5;
            equation.b = Math.PI * 0.5;
            equation.ct1 = 1;
            equation.dt1 = 1;
            equation.rx = x => Math.Cos(x);

            RunnerSolver runner = new RunnerSolver();
            var sol = runner.solve(equation);
            xs = new double[sol.Count];
            ys = new double[sol.Count];
            for (int i = 0; i < sol.Count; i++)
            {
                xs[i] = sol[i].X;
                ys[i] = sol[i].Y;
            }
        }
    }
}
