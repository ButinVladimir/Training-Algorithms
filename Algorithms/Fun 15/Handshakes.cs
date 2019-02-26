using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_15
{
    public static class Handshakes
    {
        public static long Solve(long a)
        {
            return a * (a - 1) / 2L;
        }
    }
}
