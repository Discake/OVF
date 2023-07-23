using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsolePractice.Task9
{
    public class SecondOrderEquation
    {
        //y'' + p(x) * y' + q(x) * y = r(x)
        public Func<double, double> px = x => 0.0;
        public Func<double, double> qx = x => 0.0;
        public Func<double, double> rx = x => 0;

        public Func<double, double> exact;
        //ct1 * y(a) + ct2 * y'(a) = ct
        //dt1 * y(b) + dt2 * y'(b) = dt
        public double a;
        public double b;

        public double ct1, ct2, ct;
        public double dt1, dt2, dt;
    }
    public class RunnerSolver
    {
        public int n = 5;

        private double h;

        double ai(SecondOrderEquation equation, double xi)
        {
            return 1.0 / (h * h) - equation.px(xi) / (2.0 * h);
        }

        double bi(SecondOrderEquation equation, double xi)
        {
            return 2.0 / (h * h) - equation.qx(xi);
        }

        double ci(SecondOrderEquation equation, double xi)
        {
            return 1.0 / (h * h) + equation.px(xi) / (2.0 * h);
        }


        double di(SecondOrderEquation equation, double xi)
        {
            return equation.rx(xi);
        }

        public List<Vector> solve(SecondOrderEquation equation)
        {
            h = (equation.b - equation.a) / n;

            double e1 = -equation.ct2 / (equation.ct1 * h - equation.ct2);
            double n1 = equation.ct * h / (equation.ct1 * h - equation.ct2);

            List<double> es = new List<double>();
            List<double> ns = new List<double>();

            es.Add(e1);
            ns.Add(n1);

            for (int i = 1; i <= n - 1; i++)
            {
                double xi = equation.a + (i) * h;
                double lastE = es.Last();
                double lastN = ns.Last();

                double e = ci(equation, xi) / (bi(equation, xi) - ai(equation, xi) * lastE);
                double n = -(lastN * ai(equation, xi) - di(equation, xi)) / (bi(equation, xi) - ai(equation, xi) * lastE);

                es.Add(e);
                ns.Add(n);
            }

            double yn = (equation.dt2 * ns.Last() + equation.dt * h) / (equation.dt2 * (1 - es.Last()) + equation.dt1 * h);
            double[] result = new double[n + 1];
            List<Vector> output = new List<Vector>();

            result[n] = yn;
            output.Add(new Vector(equation.a + (n) * h, yn));

            for (int i = n; i >= 1; --i)
            {
                result[i - 1] = result[i] * es[i - 1] + ns[i - 1];
                double xi = equation.a + (i - 1) * h;

                output.Add(new Vector(xi, result[i - 1]));
            }
            //output.Add(new Vector(a, ct));
            //output.Reverse();
            return output;
        }
    }

}
