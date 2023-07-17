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

            task5();
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
    }
}
