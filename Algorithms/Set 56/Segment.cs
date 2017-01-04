using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_56
{
    class Segment
    {
        public static int Solve(string[] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            return Math.Max(GetMaxFromRow(matrix, n, m), GetMaxFromColumn(matrix, n, m));
        }

        private static int GetMaxFromRow(string[] matrix, int n, int m)
        {
            int result = 1;
            int prevLength = 0, currentLength = 0;
            bool oneZero = false;

            for (int row = 0; row < n; row++)
            {
                StartIteration(matrix[row][0], ref prevLength, ref currentLength, ref oneZero, ref result);

                for (int column = 1; column < m; column++)
                {
                    IterateCharacter(matrix[row][column], ref prevLength, ref currentLength, ref oneZero, ref result);
                }
            }

            return result;
        }

        private static int GetMaxFromColumn(string[] matrix, int n, int m)
        {
            int result = 1;
            int prevLength = 0, currentLength = 0;
            bool oneZero = false;

            for (int column = 0; column < m; column++)
            {
                StartIteration(matrix[0][column], ref prevLength, ref currentLength, ref oneZero, ref result);

                for (int row = 1; row < n; row++)
                {
                    IterateCharacter(matrix[row][column], ref prevLength, ref currentLength, ref oneZero, ref result);
                }
            }

            return result;
        }

        private static void StartIteration(char c, ref int prevLength, ref int currentLength, ref bool oneZero, ref int result)
        {
            prevLength = 0;

            if (c == '0')
            {
                oneZero = true;
                currentLength = 0;
            }
            else
            {
                oneZero = false;
                currentLength = 1;
            }
        }

        private static void IterateCharacter(char c, ref int prevLength, ref int currentLength, ref bool oneZero, ref int result)
        {
            if (c == '1')
            {
                currentLength++;
            }
            else
            {
                oneZero = true;
                prevLength = currentLength;
                currentLength = 0;
            }

            if (oneZero)
            {
                result = Math.Max(result, prevLength + 1 + currentLength);
            }
            else
            {
                result = Math.Max(result, currentLength);
            }
        }
    }
}
