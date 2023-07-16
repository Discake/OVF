using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVFProject
{
    internal static class Task1
    {
        public static float FindULPfloat(bool write = true)
        {

            int Nfloat = 0;
            float ULPfloat = 1;
            while (true)
            {
                if (1 + ULPfloat / 2 == 1 && 1 + ULPfloat != 1)
                {
                    if (write)
                        Console.WriteLine($"float ULP: {ULPfloat} Mantissa bit depth: {Nfloat}");
                    return ULPfloat;
                }
                ULPfloat /= 2;
                Nfloat++;
            }
        }
        public static double FindULPdouble(bool write = true)
        {
            int Ndouble = 0;
            double ULPdouble = 1;
            while (true)
            {
                if (1 + ULPdouble / 2 == 1 && 1 + ULPdouble != 1)
                {
                    if (write)
                        Console.WriteLine($"double ULP: {ULPdouble} Mantissa bit depth: {Ndouble}");
                    return ULPdouble;
                }
                ULPdouble /= 2;
                Ndouble++;
            }
        }

        public static void FindMinFloatValue()
        {
            int N = 0;
            float minValue = 1;
            while (true)
            {
                float prev = minValue;
                minValue /= 2;
                N++;
                if (minValue == 0)
                {
                    Console.WriteLine($"float min: {prev} N exp: {N}");
                    break;
                }

            }
        }
        public static void FindMaxFloatValue()
        {
            int N = 0;
            float maxValue = 1;
            while (true)
            {
                float prev = maxValue;
                maxValue *= 2;
                N++;
                if (maxValue == float.PositiveInfinity)
                {
                    Console.WriteLine($"float max: {prev} N exp: {N}");
                    break;
                }

            }
        }

        public static void FindMinDoubleValue()
        {
            int N = 0;
            double minValue = 1;
            while (true)
            {
                double prev = minValue;
                minValue /= 2;
                N++;
                if (minValue == 0)
                {
                    Console.WriteLine($"double min: {prev} N exp: {N}");
                    break;
                }

            }
        }
        public static void FindMaxDoubleValue()
        {
            int N = 0;
            double maxValue = 1;
            while (true)
            {
                double prev = maxValue;
                maxValue *= 2;
                N++;
                if (maxValue == float.PositiveInfinity)
                {
                    Console.WriteLine($"double max: {prev} N exp: {N}");
                    break;
                }

            }
        }

        public static void CompareDouble()
        {
            double ULP = FindULPdouble(write: false);

            Console.WriteLine($"1 == 1 + ULP / 2 : {1 == 1 + ULP / 2}");
            Console.WriteLine($"1 < 1 + ULP : {1 < 1 + ULP}");
            Console.WriteLine($"1 + ULP < 1 + ULP + ULP / 2 : {1 + ULP < 1 + ULP + ULP / 2}");
        }

        public static void CompareFloat()
        {
            float ULP = FindULPfloat(write: false);

            Console.WriteLine($"1 == 1 + ULP / 2 : {1 == 1 + ULP / 2}");
            Console.WriteLine($"1 < 1 + ULP : {1 < 1 + ULP}");
            Console.WriteLine($"1 + ULP < 1 + ULP + ULP / 2 : {1 + ULP < 1 + ULP + ULP / 2}");
        }
    }
}
