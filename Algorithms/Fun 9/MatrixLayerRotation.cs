using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class MatrixLayerRotation
    {
        public static void Solve(int m, int n, int r, int[,] a)
        {
            int[] buffer = new int[m * n];
            int d = Math.Min(m, n) / 2;
            int length, start;

            for (int pos = 0; pos < d; pos++)
            {
                length = 0;
                for (int y = pos; y < m - pos; y++, length++)
                {
                    buffer[length] = a[y, pos];
                }
                for (int x = pos + 1; x < n - pos; x++, length++)
                {
                    buffer[length] = a[m - pos - 1, x];
                }
                for (int y = m - pos - 2; y >= pos; y--, length++)
                {
                    buffer[length] = a[y, n - pos - 1];
                }
                for (int x = n - pos - 2; x > pos; x--, length++)
                {
                    buffer[length] = a[pos, x];
                }

                start = (length - (r % length)) % length;

                for (int y = pos; y < m - pos; y++, start = (start + 1) % length)
                {
                    a[y, pos] = buffer[start];
                }
                for (int x = pos + 1; x < n - pos; x++, start = (start + 1) % length)
                {
                    a[m - pos - 1, x] = buffer[start];
                }
                for (int y = m - pos - 2; y >= pos; y--, start = (start + 1) % length)
                {
                    a[y, n - pos - 1] = buffer[start];
                }
                for (int x = n - pos - 2; x > pos; x--, start = (start + 1) % length)
                {
                    a[pos, x] = buffer[start];
                }
            }
        }
    }
}
