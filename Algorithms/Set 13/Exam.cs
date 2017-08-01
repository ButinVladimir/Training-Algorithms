using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_13
{
    public static class Exam
    {
        public static int[] Solve(int n)
        {
            if (n <= 2)
            {
                return new int[]{ 1 };
            }

            if (n == 3)
            {
                return new int[] { 1, 3};
            }

            if (n == 4)
            {
                return new int[] { 2, 4, 1, 3 };
            }

            int[] result = new int[n];
            int stat = 1;
            int pos = 0;

            while (stat <= n)
            {
                result[pos] = stat;
                stat += 2;
                pos++;
            }
            stat = 2;
            while (stat <= n)
            {
                result[pos] = stat;
                stat += 2;
                pos++;
            }

            return result;
        }
    }
}
