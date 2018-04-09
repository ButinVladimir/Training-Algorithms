using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class Kangaroo
    {
        public static bool Solve(int x1, int v1, int x2, int v2)
        {
            if (v2 >= v1)
            {
                return false;
            }

            return (x2 - x1) % (v1 - v2) == 0;
        }
    }
}
