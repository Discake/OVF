using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    public class Task2Math
    {
        public static Func<double, double> Func { get; set; }
        public static double Dychotomy(double min, double max, double eps)
        {
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
            }
            return middle;
        }
    }
}
