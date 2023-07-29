using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task11
{
    public class Task11
    {
        public Func<double, double> U;
        public double leftBoundary, rightBoundary;
        public int N;
        public double Eps = 1e-5;

        private double h, eigenValue;
        private double[] Uvector;
        private double[] Psivector;
        private Random rand = new Random();
        private double[] A, B, C, D, eigenVector;
        private double[] newEigenVector;
        private double newEigenValue;
        private double[] xs;

        void Init()
        {
            SetUvector();

            A = new double[N + 1];
            B = new double[N + 1];
            C = new double[N + 1];
            D = new double[N + 1];

            eigenValue = Uvector.Min();


            for (int i = 0; i <= N; i++)
            {
                if (i == 0 || i == N)
                {
                    A[i] = 0;
                    B[i] = 1 - eigenValue;
                    C[i] = 0;
                    D[i] = 0;
                }
                else
                {
                    A[i] = C[i] = -1 / (2 * h * h);
                    B[i] = Uvector[i] + 1 / (h * h) - eigenValue;
                    D[i] = rand.NextDouble();
                }
            }

            eigenVector = D;
            Task9.Task9.Avector = new List<double>(A);
            Task9.Task9.Bvector = new List<double>(B);
            Task9.Task9.Cvector = new List<double>(C);
            Task9.Task9.Dvector = new List<double>(D);
        }

        public double CalcNorm(double[] vector)
        {
            double res = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                res += Math.Pow(vector[i], 2);
            }

            return Math.Sqrt(res);
        }

        public void NextItteration()
        {
            
            newEigenVector = Task9.Task9.Solve();
            newEigenValue = eigenValue + CalcNorm(D) / CalcNorm(newEigenVector);

            for (int i = 0; i <= N; i++)
            {
                if (i == 0 || i == N)
                {
                    A[i] = 0;
                    B[i] = 1 - newEigenValue;
                    C[i] = 0;
                    D[i] = 0;
                }
                else
                {
                    A[i] = C[i] = -1 / (2 * h * h);
                    B[i] = Uvector[i] + 1 / (h * h) - newEigenValue;
                }
            }

            D = newEigenVector;
            eigenValue = newEigenValue;
            Task9.Task9.Avector = new List<double>(A);
            Task9.Task9.Bvector = new List<double>(B);
            Task9.Task9.Cvector = new List<double>(C);
            Task9.Task9.Dvector = new List<double>(D);
        }

        void SetUvector()
        {
            h = (rightBoundary - leftBoundary) / N;
            Uvector = new double[N + 1];
            xs = new double[N + 1];
            for (int i = 0; i <= N; i++)
            {
                xs[i] = leftBoundary + i * h;
                Uvector[i] = U(xs[i]);
            }
        }

        public void Solve(out double[] xs, out double[] ys, out double eigenVal)
        {
            Init();

            var counter = 0;
            do
            {
                NextItteration();
                counter++;
            } while (counter < 10/*Math.Abs(newEigenValue - eigenValue) > Eps*/);
            
            xs = this.xs;
            ys = newEigenVector;
            double normCoef = GetNormalizingCoef(ys);

            for (int i = 0; i < xs.Length; i++)
            {
                ys[i] /= Math.Sqrt(normCoef);
            }

            eigenVal = newEigenValue;
        }

        public void GetExactSolution(out double[] ys)
        {
            ys = new double[xs.Length];
            for (int i = 0; i < xs.Length; i++)
            {
                ys[i] = Math.Exp(-0.5 * xs[i] * xs[i]) / Math.Pow(Math.PI, 0.25);
            }

            var normCoef = GetNormalizingCoef(ys);

            for (int i = 0; i < xs.Length; i++)
            {
                ys[i] /= Math.Sqrt(normCoef);
            }
        }

        double GetNormalizingCoef(double[] ys)
        {
            double res = 0;
            for (int i = 1; i < xs.Length; i++)
            {
                res += (ys[i - 1] * ys[i - 1] + ys[i] * ys[i]) * h / 2;
            }

            return res;
        }
    }
}
