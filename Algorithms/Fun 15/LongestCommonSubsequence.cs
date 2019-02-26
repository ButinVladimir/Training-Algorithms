using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_15
{
    public static class LongestCommonSubsequence
    {
        public static List<int> Solve(int[] a, int[] b)
        {
            int n = a.Length;
            int m = b.Length;

            int[,] length = new int[n + 1, m + 1];
            Operation[,] operations = new Operation[n + 1, m + 1];
            for (int i = n; i >= 0; i--)
            {
                for (int j = m; j >= 0; j--)
                {
                    if (i == n || j == m)
                    {
                        operations[i, j] = Operation.Stop;
                        continue;
                    }

                    operations[i, j] = Operation.Down;
                    length[i, j] = length[i + 1, j];

                    if (length[i, j + 1] > length[i, j])
                    {
                        operations[i, j] = Operation.Right;
                        length[i, j] = length[i, j + 1];
                    }

                    if (a[i] == b[j] && length[i + 1, j + 1] + 1 > length[i, j])
                    {
                        operations[i, j] = Operation.Take;
                        length[i, j] = length[i + 1, j + 1] + 1;
                    }
                }
            }

            List<int> result = new List<int>();
            int x = 0;
            int y = 0;
            while (operations[x, y] != Operation.Stop)
            {
                switch (operations[x, y])
                {
                    case Operation.Down:
                        x++;
                        break;
                    case Operation.Right:
                        y++;
                        break;
                    case Operation.Take:
                        result.Add(a[x]);
                        x++;
                        y++;
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        private enum Operation
        {
            Down,
            Right,
            Take,
            Stop
        }
    }
}
