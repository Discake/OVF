using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public static class Task5Math
    {
        public class LagrangianPolynomial
        {
            double[] xs;
            int n;
            private double[] ys;

            public double[] Xs
            {
                set
                {
                    xs = value;
                    n = value.Length - 1;
                }
                get
                {
                    return xs;
                }
            }

            public double[] Ys
            {
                set
                {
                    ys = value;
                    n = value.Length - 1;
                }
                get
                {
                    return xs;
                }
            }

            double[] lFactors;

            public void CalculateLFactors()
            {
                lFactors = new double[n + 1];
                for (int i = 0; i <= n; i++)
                {
                    lFactors[i] = LagrangianFactor(i, xs[i]);
                }
            }

            double LagrangianFactor(int i, double x)
            {
                double result = 1;
                for (int j = 0; j <= n; j++)
                {
                    if (i == j)
                        continue;
                    result *= (x - xs[j]);
                }
                return result;
            }

            public double Evaluate(double x)
            {
                if (lFactors == null)
                {
                    CalculateLFactors();
                }
                double result = 0;
                for (int i = 0; i <= n; i++)
                {
                    result += ys[i] * LagrangianFactor(i, x) / lFactors[i];
                }
                return result;
            }
        }



    }
}
