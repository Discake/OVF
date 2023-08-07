using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.ExtraTask
{
    public class ExtraTask : Task10.Task10
    {
        double LeftBoundaryFunc(double t)
        {
            return 0;
        }

        double RightBoundaryFunc(double t)
        {
            return 0;
        }

        double InitialValues(double x)
        {
            return 0;
        }

        double NonlinearFunc(double x, double t)
        {
            return x * (1 - x) * (1 - x);
        }

        public override void SetInitialConditions()
        {
            h = 1.0 / Nx;
            tau = T / Nt;
            Map = new double[Nt + 1, Nx + 1];
            for (int i = 0; i < Nx + 1; i++)
            {
                Map[0, i] = InitialValues(i * h);
            }
        }

        protected override void FillVectors(int m)
        {
            base.FillVectors(m);
            for (int i = 0; i < Nx - 1; i++)
            {
                D[i] += (NonlinearFunc(i * h, i * tau) + NonlinearFunc(i * h, (i + 1) * tau)) * tau * 0.5;
            }
        }

        public override void GetMax(out double[] xs, out double[] ys)
        {
            xs = new double[Nt + 1];
            ys = new double[Nt + 1];

            for (int i = 0; i < Nt + 1; i++)
            {
                ys[i] = Map[i, 0];
                for (int j = 0; j < Nx + 1; j++)
                {
                    if (Map[i, j] > ys[i])
                    {
                        ys[i] = Map[i, j];
                        xs[i] = j * h;
                    }
                        
                }
            }
        }
    }

    public class ExtraTaskGrad1IsZero : ExtraTask
    {
        protected override void FillVectors(int m)
        {
            base.FillVectors(m);
            A[A.Length - 1] = -tau / (3 * h * h);
            //C[0] = -tau / (3 * h * h);
            //B[0] = 1 + tau / (3 * h * h);
            //B[0] = B[B.Length - 1] = 1 + tau / (3 * h * h);
            B[B.Length - 1] = 1 + tau / (3 * h * h);
        }
    }
}
