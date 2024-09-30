using OVFProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            task4();
            Console.ReadLine();
        }

        public static void task1()
        {
            Task1.FindULPfloat();
            Task1.FindULPdouble();
            Task1.FindMinFloatValue();
            Task1.FindMaxFloatValue();
            Task1.FindMinDoubleValue();
            Task1.FindMaxDoubleValue();

            //Task1.CompareDouble();
            Task1.CalculateSum();
        }

        public static void task2()
        {
            double U0 = 1, a = Math.Sqrt(3), eps = 1e-12;

            Console.WriteLine($"U0: {U0}, a: {a}, eps: {eps}");

            Task2 task2 = new Task2(U0, a, eps);
            Console.WriteLine($"Dychotomy: {task2.SolveDichotomy()}");
            Console.WriteLine($"Simple itterations: {task2.SolveSimpleItterations()}");
            Console.WriteLine($"Newton's method: {task2.SolveNewtonsMethod()}");
        }

        public static void task4()
        {
            double dx = 1;
            Task4.NIntegral = 64;

            var length = Math.PI * 2;

            double accuracy = 1e-11;
            var h = Math.Sqrt(accuracy * 6);

            Task4.Tolerance = h;

            for(double x = 0; x < Math.PI * 2; x += dx)
            {
                Task4.CheckSumm(x);
            }
            Task4.CheckSumm(2 * Math.PI);
        }
    }
}
