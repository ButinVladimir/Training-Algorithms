using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_4
{
    public static class MaximumPerimiter
    {
        public static string Solve(int[] l)
        {
            Array.Sort(l);

            for (int i = l.Length - 1; i >= 2; i--)
            {
                if (l[i - 2] + l[i - 1] > l[i])
                {
                    return l[i - 2] + " " + l[i - 1] + " " + l[i];
                }
            }

            return "-1";
        }
    }
}
