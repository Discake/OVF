using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public class Task3Math
    {
        public static Func<double, double> Func { get; set; }

        public static double TrapezoidMethod(double min, double max, int N)
        {
            double step = (max - min) / N;
            double result = 0;
            double factor;
            for (int i = 0; i <= N; i++)
            {
                if (i == 0 || (i == N))
                    factor = 0.5;
                else
                    factor = 1;
                result += factor * step * Func(min + i * step);
            }

            return result;
        }

        public static double SimpsonsMethod(double min, double max, int N)
        {
            double step = (max - min) / N;
            double result = 0;
            double factor;
            for (int i = 0; i <= N; i++)
            {
                if (i % 2 == 1)
                    factor = 4;
                else
                    factor = 2;
                if (i == 0 || (i == N))
                    factor = 1;
                result += (step / 3) * factor * Func(min + i * step);
            }

            return result;
        }
    }
}

