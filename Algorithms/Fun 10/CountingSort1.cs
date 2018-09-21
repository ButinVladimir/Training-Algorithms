using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class CountingSort1
    {
        public static int[] Solve(int[] a)
        {
            int[] count = new int[100];
            for (int i = 0; i < a.Length; i++)
            {
                count[a[i]]++;
            }

            return count;
        }
    }
}
