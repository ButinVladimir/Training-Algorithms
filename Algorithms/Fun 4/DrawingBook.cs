using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class DrawingBook
    {
        public static int Solve(int n, int p)
        {
            int left = p / 2;
            int right = n / 2 - p / 2;

            return Math.Min(left, right);
        }
    }
}
