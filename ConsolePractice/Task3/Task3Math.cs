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

        public static double LeftRectangle(double min, double max, int N)
        {
            double step = (max - min) / N;
            double result = 0;

            for (int i = 0; i < N; i++)
            {
                result += Func(min + i * step) * step;
            }

            return result;
        }

        public static double RightRectangle(double min, double max, int N)
        {
            double step = (max - min) / N;
            double result = 0;

            for (int i = 0; i < N; i++)
            {
                result += Func(min + (i + 1) * step) * step;
            }

            return result;
        }

        public static double Middle(double min, double max, int N)
        {
            double step = (max - min) / N;
            double result = 0;

            double argument = step / 2;
            for (int i = 0; i < N; i++)
            {
                result += Func(min + argument) * step;
                argument += step;
            }

            return result;
        }

        public static double TrapezoidMethod(double min, double max, int N)
        {
            double step = (max - min) / (N);
            double result = 0;
            double factor;
            for (int i = 0; i < N; i++)
            {
                /*if (i == 0 || (i == N))
                    factor = 0.5;
                else
                    factor = 1;
                result += factor * step * Func(min + i * step);*/

                result += (Func(min + i * step) + Func(min + (i + 1) * step)) * step / 2;
            }

            return result;
        }

        public static double SimpsonsMethod(double min, double max, int N)
        {
            double step = (max - min) / (N);
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

