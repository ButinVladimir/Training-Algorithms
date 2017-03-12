using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public class Professor
    {
        public static bool Solve(int n, int k, int[] a)
        {
            for (int i=0;i <n;i++)
            {
                if (a[i] <= 0)
                {
                    k--;
                }
            }

            return k > 0;
        }
    }
}
