using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public static class Task4
    {
        class Bessel
        {
            public enum IntegralType
            {
                Trapezoid,
                Simpson
            }
            int m;
            double x;
            IntegralType type;
            public Bessel(int m, IntegralType type)
            {
                this.m = m;
                this.type = type;
            }

            public double Func(double t)
            {
                return Math.Cos(m * t - x * Math.Sin(t)) / Math.PI;
            }

            public double Evaluate(double x)
            {
                this.x = x;
                double result;
                double min = 0, max = Math.PI;
                int N = (int)Math.Pow(2, 15);
                Task3Math.Func = Func;
                switch (type)
                {
                    case IntegralType.Trapezoid:                        
                        result = Task3Math.TrapezoidMethod(min, max, N);
                        break;
                    case IntegralType.Simpson:
                        result = Task3Math.SimpsonsMethod(min, max, N);
                        break;
                    default:
                        throw new Exception();
                }

                return result;
            }
        }

        static Bessel.IntegralType type = Bessel.IntegralType.Simpson;


        static Bessel b0 = new Bessel(0, type), b1 = new Bessel(1, type);

        static double B0Derrivative(double x)
        {
            double dx = 5e-5;
            double check1 = b0.Evaluate(x + dx);
            double check2 = b0.Evaluate(x - dx);
            double result = (check1 - check2) / (2 * dx);
            return result;
        }

        static double CalculateBesselSumm(double x)
        {
            double result = B0Derrivative(x) + b1.Evaluate(x);
            return result;
        }

        public static void CheckSumm(double x)
        {
            Console.WriteLine($"x: {x}, summ: {CalculateBesselSumm(x)}");
        }
    }
}
