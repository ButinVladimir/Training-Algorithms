using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_74
{
    public static class SherlockMinimax
    {
        public static long Solve(int[] a, int p, int q)
        {
            int currentMin = p;
            int currentDistance = Distance(a, p, p, q);

            Update(a, q, p, q, ref currentMin, ref currentDistance);

            Array.Sort(a);

            for (int i = 0; i < a.Length - 1; i++)
            {
                int m = (a[i] + a[i + 1]) / 2;

                for (int j = -2; j <= 2; j++)
                {
                    Update(a, m + j, p, q, ref currentMin, ref currentDistance);
                }
            }

            return currentMin;
        }

        private static void Update(int[] a, int v, int p, int q, ref int currentMin, ref int currentDistance)
        {
            int distance = Distance(a, v, p, q);
            if (distance == -1)
            {
                return;
            }

            if (distance > currentDistance || distance == currentDistance && v < currentMin)
            {
                currentMin = v;
                currentDistance = distance;
            }
        }

        private static int Distance(int[] a, int v, int p, int q)
        {
            if (v < p || v > q)
            {
                return -1;
            }

            int distance = Math.Abs(a[0] - v);
            for (int i = 0; i < a.Length; i++)
            {
                distance = Math.Min(Math.Abs(a[i] - v), distance);
            }

            return distance;
        }
    }
}
