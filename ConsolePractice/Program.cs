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
            task2();

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

            Task1.CompareDouble();
        }

        public static void task2()
        {
            double U0 = 1, a = 1, eps = 1e-12;

            Console.WriteLine($"U0: {U0}, a: {a}, eps: {eps}");

            Task2 task2 = new Task2(U0, a, eps);

            Console.WriteLine($"Dychotomy: {task2.SolveDichotomy()}");
        }
    }
}
