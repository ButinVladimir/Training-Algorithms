using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class SherlockCost
    {
        public static int Solve(int[] b)
        {
            int n = b.Length;
            int[] aMin = new int[n];
            int[] aMax = new int[n];

            for (int i = n - 2; i >= 0; i--)
            {
                aMin[i] = Math.Max(aMin[i + 1], b[i + 1] - 1 + aMax[i + 1]);
                aMax[i] = Math.Max(b[i] - 1 + aMin[i + 1], Math.Abs(b[i] - b[i + 1]) + aMax[i + 1]);
            }

            return Math.Max(aMin[0], aMax[0]);
        }
    }
}
