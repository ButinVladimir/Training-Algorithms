using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class EqualStacks
    {
        public static int Solve(int[][] s)
        {
            int n = s.Length;
            int[] heights = new int[n];
            int[] positions = new int[n];
            for (int i = 0;i<n;i++)
            {
                heights[i] = s[i].Sum();
                positions[i] = 0;
            }

            int heightMin = heights.Min();
            int heightMax = heights.Max();
            while (heightMin != heightMax)
            {
                int p = Array.FindIndex(heights, h => h == heightMax);
                heights[p] -= s[p][positions[p]];
                positions[p]++;

                heightMin = heights.Min();
                heightMax = heights.Max();
            }

            return heightMin;
        }
    }
}
