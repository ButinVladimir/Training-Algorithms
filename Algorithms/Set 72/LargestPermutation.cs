using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_72
{
    public static class LargestPermutation
    {
        public static void Solve(int[] a, int k)
        {
            int n = a.Length;
            int[] positions = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                positions[a[i]] = i;
            }

            for (int i = 0; i < n && k > 0; i++)
            {
                if (positions[n-i] != i)
                {
                    int nextValue = a[i];
                    int nextPosition = positions[n - i];

                    positions[n - i] = i;
                    a[i] = n - i;

                    a[nextPosition] = nextValue;
                    positions[nextValue] = nextPosition;

                    k--;
                }
            }
        }
    }
}
