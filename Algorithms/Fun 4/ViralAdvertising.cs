using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class ViralAdvertising
    {
        public static long Solve(int n)
        {
            long result = 0;
            long p = 5;

            for (int i=0;i<n;i++)
            {
                result += p / 2;
                p = p / 2 * 3;
            }

            return result;
        }
    }
}
