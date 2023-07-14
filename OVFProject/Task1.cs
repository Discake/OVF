using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVFProject
{
    internal static class Task1
    {
        public static int Ndouble = 0;
        public static double ULPdouble = 1;
        public static int Nfloat = 0;
        public static float ULPfloat = 1;

        public static void FindULPdouble()
        {
            while (1 + ULPdouble / 2 != 1)
            {
                ULPdouble /= 2;
                Ndouble++;
            }
            if (1 + ULPdouble != 1 && 1 + ULPdouble / 2 == 1)
                return;
            else
                throw new ArgumentException("ULP isn't found");
        }
        public static void FindULPfloat()
        {
            while (1 + ULPfloat / 2 != 1)
            {
                ULPfloat /= 2;
                Nfloat++;
            }
            if (1 + ULPfloat != 1 && 1 + ULPfloat / 2 == 1)
                return;
            else
                throw new ArgumentException("ULP isn't found");
        }
    }
}
