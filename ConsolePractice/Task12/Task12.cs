using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.Remoting.Messaging;

namespace ConsolePractice.Task12
{
    public class Task12
    {
        public enum WindowType
        {
            None,
            Rectangle,
            Hann
        }

        public int N = 100;
        private double a = 0, b = Math.PI * 2, a0 = 1, a1 = 0.002, omega0 = 5.1, omega1 = 25.5; 
        public double RectWinLeftBoundary = 1, RectWinRightBoundary = 5;

        double RectangleWindow(double x)
        {
            if (x > RectWinLeftBoundary && x < RectWinRightBoundary)
                return 1;
            return 0;
        }

        double HannWindow(double x)
        {
            return 0.5 * (1 - Math.Cos(x));
        }

        double Signal(double x)
        {
            return a0 * Math.Sin(omega0 * x) + a1 * Math.Sin(omega1 * x);
        }

        public (double[] time, double[] signal) GetSignal(WindowType windowType)
        {
            Task12Math.LeftBoundary = a;
            Task12Math.RightBoundary = b;
            Task12Math.N = N;
            Task12Math.SignalFunc = Signal;

            switch (windowType)
            {
                case WindowType.None:
                    Task12Math.WindowFunc = x => { return 1; };
                    break;
                case WindowType.Rectangle:
                    Task12Math.WindowFunc = RectangleWindow;
                    break;
                case WindowType.Hann:
                    Task12Math.WindowFunc = HannWindow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(windowType), windowType, null);
            }

            var res = Task12Math.Initialize();

            return res;
        }

        public (double[] freq, double[] magnitude) GetFourierTransform()
        {
            var res = Task12Math.FourierTransform();
            return res;
        }
    }
}
