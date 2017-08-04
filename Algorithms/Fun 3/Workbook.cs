using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class Workbook
    {
        public static int Solve(int k, int[] t)
        {
            int page = 1;
            int left, right;
            int result = 0;

            for (int chapter = 0; chapter < t.Length; chapter++)
            {
                int blocks = t[chapter] / k;
                if (t[chapter] % k > 0)
                {
                    blocks++;
                }

                for (int block = 0; block < blocks; block++)
                {
                    left = block * k + 1;
                    right = Math.Min(block * k + k, t[chapter]);

                    if (page >= left && page <= right)
                    {
                        result++;
                    }

                    page++;
                }
            }

            return result;
        }
    }
}
