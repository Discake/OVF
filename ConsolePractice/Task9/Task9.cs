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
        private static double[] Dvector;
        private static double[] Avector;
        private static double[] Bvector;
        private static double[] Cvector;
        public static double a, b, c, d, d0, dnPlus1;

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
            Dvector = new double[N + 1];
            for (int i = 1; i < N; i++)
            {
                Dvector[i] = Math.Cos(xs[i]);
            }

            Dvector[0] = d0;
            Dvector[N] = dnPlus1;
        }

        static void FillOtherVectors()
        {
            Avector = new double[N + 1];
            Bvector = new double[N + 1];
            Cvector = new double[N + 1];
            for (int i = 1; i < N; i++)
            {
                Avector[i] = Cvector[i] = 1 / (h * h);
                Bvector[i] = 2 / (h * h);
            }

            Bvector[0] = a - b / h;
            Cvector[0] = b / h;
            Avector[N] = -d / h;
            Bvector[N] = c + d / h;
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
            equation.ct1 = -1;
            equation.ct2 = 1;
            equation.dt1 = 1;
            equation.dt2 = 1;
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
