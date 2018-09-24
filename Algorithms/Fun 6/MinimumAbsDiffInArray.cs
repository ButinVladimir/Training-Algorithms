using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_6
{
    public static class MinimumAbsDiffInArray
    {
        public static int Solve(int[] a)
        {
            Array.Sort(a);
            int length = a.Length - 1;
            int result = Math.Abs(a[0] - a[1]);

            for (int i = 0; i < length; i++)
            {
                result = Math.Min(result, Math.Abs(a[i] - a[i + 1]));
            }

            return result;
        }
    }
}
