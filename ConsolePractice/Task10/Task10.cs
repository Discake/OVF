using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePractice.Task9;

namespace ConsolePractice.Task10
{
    public class Task10
    {
        public int Nx, Nt;
        public double T;
        protected double h;
        protected double tau;

        protected double[] A, B, C, D;
        public double[,] Map { get; protected set; }

        double InitialTemp(double x)
        {
            return x * (1 - x) * (1 - x);
        }

        public virtual void SetInitialConditions()
        {
            h = 1.0 / Nx;
            tau = T / Nt;
            Map = new double[Nt + 1, Nx + 1];
            for (int i = 0; i < Nx + 1; i++)
            {
                Map[0, i] = InitialTemp(i * h);
            }
        }

        protected virtual void FillVectors(int m)
        {
            A = new double[Nx - 1];
            B = new double[Nx - 1];
            C = new double[Nx - 1];
            D = new double[Nx - 1];



            for (int i = 0; i < Nx - 1; i++)
            {
                
                if (i == 0)
                {
                    double temp = Map[m, i];
                    A[i] = 0;
                    B[i] = 1 + tau / (h * h);
                    C[i] = -0.5 * tau / (h * h);
                    //D[i] = (-2 * Map[m, i] + Map[m, i + 1]) / (h * h);
                    D[i] = temp;
                }
                else if (i == Nx - 2)
                {
                    double temp = Map[m, i];
                    A[i] = -0.5 * tau / (h * h);
                    B[i] = 1 + tau / (h * h);
                    C[i] = 0;
                    //D[i] = (Map[m, i - 1] - 2 * Map[m, i]) / (h * h);
                    D[i] = temp;
                }
                else
                {
                    double temp = Map[m, i] + tau * (Map[m, i - 1] - 2 * Map[m, i] + Map[m, i + 1]) / (2 * h * h);
                    A[i] = -0.5 * tau / (h * h);
                    B[i] = 1 + tau / (h * h);
                    C[i] = -0.5 * tau / (h * h);
                    D[i] = temp;
                }
            }
        }

        public void Solve()
        {
            SetInitialConditions();
            for (int i = 0; i < Nt; i++)
            {
                FillVectors(i);
                Task9.Task9.Avector = new List<double>(A);
                Task9.Task9.Bvector = new List<double>(B);
                Task9.Task9.Cvector = new List<double>(C);
                Task9.Task9.Dvector = new List<double>(D);

                var Vm = Task9.Task9.Solve();
                for (int j = 0; j < Vm.Length; j++)
                {
                    Map[i + 1, j] = Vm[j];
                }

            }
        }

        public virtual void GetMax(out double[] xs, out double[] ys)
        {
            xs = new double[Nt + 1];
            ys = new double[Nt + 1];

            for (int i = 0; i < Nt + 1; i++)
            {
                xs[i] = i * tau;
                ys[i] = Map[i, 0];
                for (int j = 0; j < Nx + 1; j++)
                {
                    if (Map[i, j] > ys[i])
                        ys[i] = Map[i, j];
                }
            }
        }
    }
}
