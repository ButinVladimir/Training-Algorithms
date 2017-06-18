using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class FlippingBits
    {
        private const long Mask = (1L << 32) - 1;

        public static long Solve(long number)
        {
            return Mask ^ number;
        }
    }
}
