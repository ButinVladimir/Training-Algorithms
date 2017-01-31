using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_65
{
    class Rectangle
    {
        public static long Solve(long[] heights)
        {
            long[] prev = BuildLeft(heights);
            long[] next = BuildRight(heights);

            long result = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                result = Math.Max(result, heights[i] * (next[i] - prev[i] - 1));
            }

            return result;
        }

        private static long[] BuildLeft(long[] heights)
        {
            int n = heights.Length;

            long[] prev = new long[n];

            long nextPrev;

            for (int i = 0; i < n; i++)
            {
                nextPrev = i - 1;
                while (nextPrev >= 0 && heights[i] <= heights[nextPrev])
                {
                    nextPrev = prev[nextPrev];
                }

                prev[i] = nextPrev;
            }

            return prev;
        }

        private static long[] BuildRight(long[] heights)
        {
            int n = heights.Length;

            long[] next = new long[n];

            long nextNext;

            for (int i = n - 1; i >= 0; i--)
            {
                nextNext = i + 1;
                while (nextNext < n && heights[i] <= heights[nextNext])
                {
                    nextNext = next[nextNext];
                }

                next[i] = nextNext;
            }

            return next;
        }
    }
}
