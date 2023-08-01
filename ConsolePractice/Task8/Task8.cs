using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsolePractice.Task8
{
    public class Task8
    {
        public double Min, Max;
        public int N;
        public double U0, V0;

        public (double[] u, double[] v, double[] t) GetExplicit1Solution()
        {
            Task8Math.Min = Min;
            Task8Math.Max = Max;
            Task8Math.N = N;
            Task8Math.U0 = U0;
            Task8Math.V0 = V0;
            Task8Math.Func = (u, v) =>
            {
                double fu = 998 * u + 1998 * v;
                double fv = -999 * u - 1999 * v;
                return (fu, fv);
            };

            return Task8Math.ExplicitScheme1();
        }

        public (double[] u, double[] v, double[] t) GetImplicit1Solution()
        {
            Task8Math.Min = Min;
            Task8Math.Max = Max;
            Task8Math.N = N;
            Task8Math.U0 = U0;
            Task8Math.V0 = V0;
            Task8Math.Func = (u, v) =>
            {
                double fu = 998 * u + 1998 * v;
                double fv = -999 * u - 1999 * v;
                return (fu, fv);
            };

            return Task8Math.ImplicitScheme1();
        }
    }
}
