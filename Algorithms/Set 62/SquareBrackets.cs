using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_62
{
    class SquareBrackets
    {
        public int[] OpenedPositions { get; set; }
        public int N { get; set; }


        public int Solve()
        {
            int n2 = N * 2;
            int[,] result = new int[n2 + 1, N + 1];

            for (int i = 1; i <= N; i++)
            {
                result[n2, i] = 0;
            }
            result[n2, 0] = 1;

            for (int position = n2 - 1; position >= 0; position--)
            {
                for (int opened = 0; opened <= N; opened++)
                {
                    result[position, opened] = 0;

                    if (opened > 0 && !OpenedPositions.Contains(position))
                    {
                        result[position, opened] += result[position + 1, opened - 1];
                    }

                    if (opened < N)
                    {
                        result[position, opened] += result[position + 1, opened + 1];
                    }
                }
            }

            return result[0, 0];
        }
    }
}
