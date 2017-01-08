using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_47
{
    class Looking
    {
        public static Tuple<int, int> Solve(int[,] a, int value)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            int rowStart = Search(x => x >= 0 && x < n && a[x, m - 1] < value, -1, n) + 1;
            int rowEnd = Search(x => x >= 0 && x < n && a[x, 0] <= value, -1, n);

            for (int row = rowStart; row <= rowEnd; row++)
            {
                int column = Search(x => x >= 0 && x < m && a[row, x] <= value, -1, m);

                if (column >= 0 && column < m && a[row, column] == value)
                {
                    return new Tuple<int, int>(row, column);
                }
            }

            return null;
        }

        private static int Search(Func<int, bool> comparer, int min, int max)
        {
            int current = min;
            int step = max - min;
            int next;
            
            while (step > 0)
            {
                next = current + step;

                if (comparer(next))
                {
                    current = next;
                }

                step /= 2;
            }

            return current;
        }
    }
}
