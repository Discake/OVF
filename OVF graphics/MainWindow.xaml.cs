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

            task3();
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
    }
}
