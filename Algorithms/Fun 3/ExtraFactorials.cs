using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algorithms.Fun_3
{
    public static class ExtraFactorials
    {
        public static string Solve(int value)
        {
            BigInteger current = 1;

            for (int i = 1; i <= value; i++)
            {
                current *= i;
            }

            return current.ToString();
        }
    }
}
