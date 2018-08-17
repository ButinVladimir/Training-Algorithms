using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class ClosestNumbers
    {
        public static string Solve(int[] a)
        {
            Array.Sort(a);
            int d = a[1] - a[0];
            for (int i = 1; i < a.Length - 1; i++)
            {
                d = Math.Min(d, a[i + 1] - a[i]);
            }

            List<int> result = new List<int>();
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i + 1] - a[i] == d)
                {
                    result.Add(a[i]);
                    result.Add(a[i + 1]);
                }
            }

            return string.Join(" ", result);
        }
    }
}
