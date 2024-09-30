using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public class Task3
    {
        public enum FuncName
        {
            I3a,
            I3b
        }

        public enum Method
        {
            Trapezoid,
            Simpson
        }

        static double Func1(double x)
        {
            return 1 / (1 + x * x);
        }
        static double Func2(double x)
        {
            //return Math.Pow(x, 1 / 3) * Math.Exp(Math.Sin(x));
            return 2 / Math.Sqrt(Math.PI) * Math.Exp(-x * x);
        }

        public static double CalculateErrFuncAt(double x, int N, Method method)
        {
            Task3Math.Func = Func2;

            switch (method)
            {
                case Method.Trapezoid:
                    return Task3Math.TrapezoidMethod(0, x, N);
                case Method.Simpson:
                    return Task3Math.SimpsonsMethod(0, x, N);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static double[] CalculateRightRect(double min, double max, int N, FuncName name)
        {
            switch (name)
            {
                case FuncName.I3a:
                    Task3Math.Func = Func1;
                    break;
                case FuncName.I3b:
                    Task3Math.Func = Func2;
                    break;
            }

            double[] results = new double[N - 2];
            for (int i = 2; i < N; i++)
            {
                results[i - 2] = Task3Math.RightRectangle(min, max, (int)Math.Pow(2, i));
            }

            return results;
        }

        public static double[] CalculateLeftRect(double min, double max, int N, FuncName name)
        {
            switch (name)
            {
                case FuncName.I3a:
                    Task3Math.Func = Func1;
                    break;
                case FuncName.I3b:
                    Task3Math.Func = Func2;
                    break;
            }

            double[] results = new double[N - 2];
            for (int i = 2; i < N; i++)
            {
                results[i - 2] = Task3Math.LeftRectangle(min, max, (int)Math.Pow(2, i));
            }

            return results;
        }

        public static double[] CalculateMiddle(double min, double max, int N, FuncName name)
        {
            switch (name)
            {
                case FuncName.I3a:
                    Task3Math.Func = Func1;
                    break;
                case FuncName.I3b:
                    Task3Math.Func = Func2;
                    break;
            }

            double[] results = new double[N - 2];
            for (int i = 2; i < N; i++)
            {
                results[i - 2] = Task3Math.Middle(min, max, (int)Math.Pow(2, i));
            }

            return results;
        }

        public static double[] CalculateTrapezoid(double min, double max, int N, FuncName name)
        {
            switch (name)
            {
                case FuncName.I3a:
                    Task3Math.Func = Func1;
                    break;
                case FuncName.I3b:
                    Task3Math.Func = Func2;
                    break;
            }

            double[] results = new double[N - 2];
            for (int i = 2; i < N; i++)
            {
                results[i - 2] = Task3Math.TrapezoidMethod(min, max, (int)Math.Pow(2, i));
            }

            return results;
        }

        public static double[] CalculateSimpsonsMethod(double min, double max, int N, FuncName name)
        {
            switch (name)
            {
                case FuncName.I3a:
                    Task3Math.Func = Func1;
                    break;
                case FuncName.I3b:
                    Task3Math.Func = Func2;
                    break;
            }

            double[] results = new double[N - 2];
            for (int i = 2; i < N; i++)
            {
                results[i - 2] = Task3Math.SimpsonsMethod(min, max, (int)Math.Pow(2, i));
            }

            return results;
        }
    }
}
