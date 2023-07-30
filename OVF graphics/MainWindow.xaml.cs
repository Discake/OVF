using ConsolePractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsolePractice.Task10;
using ConsolePractice.Task11;
using ConsolePractice.Task12;
using ConsolePractice.Task6;
using ConsolePractice.Task7;
using ConsolePractice.Task9;

namespace OVF_graphics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            task12();
        }

        void task3()
        {
            int N = 8;
            var trapezoidResults = Task3.CalculateTrapezoid(-1, 1, N, Task3.FuncName.I3a);
            var simpsonsResults = Task3.CalculateSimpsonsMethod(-1, 1, N, Task3.FuncName.I3a);

            double[] x = new double[N - 2];
            for (int i = 2; i < N; i++)
            {
                x[i - 2] = (int)Math.Pow(2, i);
                trapezoidResults[i - 2] = Math.Abs(Math.PI / 2 - trapezoidResults[i - 2]);
                simpsonsResults[i - 2] = Math.Abs(Math.PI / 2 - simpsonsResults[i - 2]);
            }

            WpfPlot1.Plot.AddScatter(x, trapezoidResults);
            WpfPlot1.Plot.AddScatter(x, simpsonsResults);
            WpfPlot1.Refresh();
        }

        void task5()
        {
            int N = 16;
            Task5.N = N;
            double[] pfiX, pfiY, xs, ys;
            Task5.PointsForInterpolation(out pfiX, out pfiY);
            Task5.InterpolatedPoints(out xs, out ys, 1000);

            WpfPlot1.Plot.AddScatter(pfiX, pfiY, markerSize: 10);
            WpfPlot1.Plot.AddScatter(xs, ys);

            Task5.lpMinusYk(2, ref xs, ref ys);

            WpfPlot1.Plot.AddScatter(xs, ys);
            /*WpfPlot1.Plot.AddScatter(new double[] {-1e2, 1e2}, new double[] { 0, 0 }, color: System.Drawing.Color.DarkRed);*/
            WpfPlot1.Refresh();
        }

        void task6()
        {
            int N = 10;
            Task6.N = N;
            double[] xs, ys, eulerxs, eulerys, rk2x, rk2y, rk4x, rk4y;
            Task6.GetEulersMethodSolution(out eulerxs, out eulerys);
            Task6.GetRK2MethodSolution(out rk2x, out rk2y);
            Task6.GetRK4MethodSolution(out rk4x, out rk4y);
            Task6.N = 100;
            Task6.GetSolution(out xs, out ys);
            

            WpfPlot1.Plot.AddScatter(xs, ys, label: "Solution");
            WpfPlot1.Plot.AddScatter(eulerxs, eulerys, label: "Euler's method");
            WpfPlot1.Plot.AddScatter(rk2x, rk2y, label: "R-K 2nd Order");
            WpfPlot1.Plot.AddScatter(rk4x, rk4y, label: "R-K 4th Order");

            WpfPlot1.Plot.Legend();

            WpfPlot1.Refresh();
        }

        void task7()
        {
            Task7.N = 250;
            Task7.GetGeneralRK2Solution(out var xs, out var ys);
            WpfPlot1.Plot.AddScatter(xs, ys);

            WpfPlot1.Refresh();
        }

        void task9(int N = 10)
        {
            
            Task9.N = N;
            Task9.m1 = 1;
            Task9.n1 = 1;
            Task9.n2 = 1;
            Task9.m2 = 1;
            Task9.m = 0;
            Task9.n = 0;
            Task9.Fill = true;



            //Task9.GetSolution(out var xs, out var ys);
            var xs = Task9.CreateUniformMesh();
            var cond1 = Task9.condition1;
            var cond2 = Task9.condition2;

            var ys = Task9.Solve();

            var exact = Task9.ExactSolution(xs);

            WpfPlot1.Plot.AddScatter(xs, ys);
            WpfPlot1.Plot.AddScatter(xs, exact);

            WpfPlot1.Refresh();
        }

        void task10()
        {
            Task10 task10 = new Task10();
            task10.Nt = 100;
            task10.Nx = 100;
            task10.T = 0.5;
            task10.Solve();
            var result = task10.Map;

            var plt = new ScottPlot.Plot(1000, 1000);

            plt.AddHeatmap(result);

            plt.SaveFig("map.png");

            task10.GetMax(out var xs, out var ys);

            double a = ys[0];
            double b = (1 / xs[20]) * Math.Log(a / ys[20]);

            double[] exp = new double[xs.Length];
            for (int i = 0; i < exp.Length; i++)
            {
                exp[i] = a * Math.Exp(-b * xs[i]);
            }

            WpfPlot1.Plot.AddScatter(xs, ys, label: "Solution");
            WpfPlot1.Plot.AddScatter(xs, exp, label: "Exponent");

            WpfPlot1.Plot.Legend();

            WpfPlot1.Refresh();
        }

        void task11()
        {
            Task11 task11 = new Task11();
            task11.Eps = 1e-3;
            task11.N = 100;
            task11.U = x => { return 0.5 * x * x; };
            task11.leftBoundary = -5;
            task11.rightBoundary = 5;

            task11.Solve(out var xs, out var ys, out var energy);
            task11.GetExactSolution(out var exact);


            WpfPlot1.Plot.AddScatter(xs, ys, label: "Solution");
            WpfPlot1.Plot.AddScatter(xs, exact, label: "Exact solution");

            WpfPlot1.Plot.Legend();

            WpfPlot1.Refresh();
        }

        void task12()
        {
            Task12 task12 = new Task12();
            task12.N = 400;

            var freqLength = task12.N / (Math.PI * 4);

            var sig = task12.GetSignal(Task12.WindowType.Hann);

            var ft = task12.GetFourierTransform();

            WpfPlot1.Plot.AddScatter(ft.freq, ft.magnitude);
            //WpfPlot1.Plot.AddScatter(sig.time, sig.signal);

            WpfPlot1.Refresh();
        }
    }
}
