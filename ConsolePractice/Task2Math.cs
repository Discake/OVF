using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public class Task2Math
    {
        static double lambda = -1;
        public static Func<double, double> Func { get; set; }
        public static double Dychotomy(double min, double max, double eps)
        {
            double middle = (max + min) / 2;
            while(max - min > eps)
            {
                if(Func(min) * Func(middle) < 0)
                {
                    max = middle;
                }
                else
                {
                    min = middle;
                }
                middle = (max + min) / 2;
            }
            return middle;
        }

        private static double Phi(double x, double min, double max)
        {
            double result = x - lambda * Func(x);
            if(result < min || result > max)
            {
                lambda /= 10;
                result = Phi(x, min, max);
            }
            /*else
            {
                lambda *= 1.01;
            }*/
            return result;
        }

        public static double SimpleItterations(double min, double max, double eps)
        {
            double x = (min + max) / 2;
            double phi = Phi(x, min, max);

            while(Math.Abs(phi - x) > eps)
            {
                x = phi;
                phi = Phi(x, min, max);
            }
            return phi;
        }
    }
}
