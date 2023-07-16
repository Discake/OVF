using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    internal class Task2
    {
        public double U0, a, eps;
        private double min, max;
        public Task2(double U0, double a, double eps)
        {
            this.U0 = U0;
            this.a = a;
            this.eps = eps;
            double temp = Math.Pow(Math.PI, 2) / (8 * a * a * U0);
            if (temp > 1)
                min = eps;
            else
                min = 1 - temp;
            max = 1 - eps;
        }

        public double Func(double ksi)
        {
            double result = Math.Tan(Math.Sqrt(2 * a * a * U0 * (1 - ksi))) - Math.Sqrt(ksi / (1 - ksi));
            return result;
        }

        public double SolveDichotomy()
        {
            Task2Math.Func = Func;
            return Task2Math.Dychotomy(min, max, eps);
        }

        public double SolveSimpleItterations()
        {
            Task2Math.Func = Func;
            return Task2Math.SimpleItterations(min, max, eps);
        }
    }
}
