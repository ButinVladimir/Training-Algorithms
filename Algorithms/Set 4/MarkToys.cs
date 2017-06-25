using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_4
{
    public static class MarkToys
    {
        public static int Solve(int k, int[] toys)
        {
            Array.Sort(toys);

            int result;

            for (result = 0; result < toys.Length && k >= toys[result]; result++)
            {
                k -= toys[result];
            }

            return result;
        }
    }
}
