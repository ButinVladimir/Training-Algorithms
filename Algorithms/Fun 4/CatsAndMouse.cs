using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class CatsAndMouse
    {
        public static string Solve(int x, int y, int z)
        {
            int a = Math.Abs(z - x);
            int b = Math.Abs(z - y);

            if (a < b)
            {
                return "Cat A";
            }
            if (a > b)
            {
                return "Cat B";
            }

            return "Mouse C";
        }
    }
}
