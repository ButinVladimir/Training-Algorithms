using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class SherlockSquares
    {
        public static long Solve(long a, long b)
        {
            long rootA = 0;
            while (rootA * rootA < a)
            {
                rootA++;
            }

            long rootB = 0;
            while (rootB * rootB <= b)
            {
                rootB++;
            }
            rootB--;

            return rootA > rootB ? 0 : (rootB - rootA + 1);
        }
    }
}
