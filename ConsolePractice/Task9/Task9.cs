using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static double[] CreateUniformMesh()
        {
            h = Math.PI / N;
            double[] xs = new double[N - 1];

            for (int i = 1; i < N; i++)
            {
                xs[i - 1] = -Math.PI * 0.5 + i * h;
            }

            return xs;
        }

        static void FillDvector()
        {
            var xs = CreateUniformMesh();
            Dvector = new double[N - 1];
            for (int i = 0; i < N - 1; i++)
            {
                Dvector[i] = Math.Cos(xs[i]);
            }
        }

        static void FillOtherVectors()
        {
            Avector = new double[N - 1];
            Bvector = new double[N - 1];
            Cvector = new double[N - 1];
            for (int i = 0; i < N - 1; i++)
            {
                Avector[i] = Cvector[i] = 1 / (h * h);
                Bvector[i] = 2 / (h * h);
            }
        }

        public static double[] GetSolution()
        {
            FillDvector();
            FillOtherVectors();
            Task9Math.Avector = Avector;
            Task9Math.Bvector = Bvector;
            Task9Math.Cvector = Cvector;
            Task9Math.Dvector = Dvector;
            Task9Math.N = N - 1;
            Task9Math.StraightStroke();
            Task9Math.ReverseStroke(out var solution);

            return solution;
        }
    }
}
