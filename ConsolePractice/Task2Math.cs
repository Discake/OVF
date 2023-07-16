using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public class Task2Math
    {
        static double lambda = -1;
        public static Func<double, double> Func { get; set; }
        public static Func<double, double> Derrivative { get; set; }
        public static double Dychotomy(double min, double max, double eps)
        {
            int counter = 0;
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
                counter++;
            }
            Console.WriteLine($"Dychotomy itterations: {counter}");
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
            double prev;
            double rn;
            int counter = 0;
            do
            {
                prev = x;
                x = phi;
                phi = Phi(x, min, max);
                rn = Math.Pow(phi - x, 2) / Math.Abs(2 * x - phi - prev);
                counter++;
            } while (rn > eps);
            Console.WriteLine($"Simple itterations: {counter}");
            return phi;
        }

        public static double NewtonsMethod(double min, double max, double eps)
        {
            double x = (min + max) / 2;
            double next = x - Func(x) / Derrivative(x);
            int counter = 0;
            while(Math.Abs(next - x) > eps)
            {
                x = next;
                var check = Derrivative(x);
                next = x - Func(x) / Derrivative(x);
                counter++;
            }
            Console.WriteLine($"Newton's method itterations: {counter}");
            return next;
        }
    }
}
