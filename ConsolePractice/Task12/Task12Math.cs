using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Task12
{
    public static class Task12Math
    {
        private static Complex i = new(0, 1);
        private static double tau;
        private static double[] signal, time;

        public static Func<double, double> WindowFunc;
        public static Func<double, double> SignalFunc;
        public static int N;
        public static double RightBoundary, LeftBoundary;


        public static (double[] time, double[] signal) Initialize()
        {
            tau = (RightBoundary - LeftBoundary) / N;
            signal = new double[N + 1];
            time = new double[N + 1];
            for (int j = 0; j < N + 1; j++)
            {
                time[j] = tau * j;
                signal[j] = SignalFunc(time[j]) * WindowFunc(time[j]);
            }

            return (time, signal);
        }

        static Complex CalculateTransformation(double freqJ)
        {
            Complex res = new Complex(0, 0);

            for (int k = 0; k < N + 1; k++)
            {
                res += signal[k] * Complex.Exp(-Math.PI * 2 *freqJ * i * k / N);
            }

            return res;
        }

        static double GetFreq(int j)
        {
            double omega = 1 / tau;
            if (j < (N + 1) / 2)
                return j * omega / (N);
            return (-1 + (double)j / (N)) * omega;
        }

        public static (double[] freq, double[] magnitude) FourierTransform()
        {
            double[] freq = new double[N + 1];
            double[] magnitude = new double[N + 1];
            for (int j = 0; j < N + 1; j++)
            {
                freq[j] = GetFreq(j);
                magnitude[j] = Math.Log(Math.Pow(CalculateTransformation(freq[j]).Magnitude, 2));
            }

            return (freq, magnitude);
        }
    }
}
