using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class QueenAttackII
    {
        public static int Solve(int n, int x, int y, int[] xo, int[] yo)
        {
            int k = xo.Length;
            int[] result = {
                n - x,
                x - 1,
                n - y,
                y - 1,
                Math.Min(n - x, n - y),
                Math.Min(n - x, y - 1),
                Math.Min(x - 1, n - y),
                Math.Min(x - 1, y - 1),
            };

            for (int i = 0; i < k; i++)
            {
                CheckHorizontalOrVertical(x, y, xo[i], yo[i], true, ref result[0]);
                CheckHorizontalOrVertical(x, y, xo[i], yo[i], false, ref result[1]);
                CheckHorizontalOrVertical(y, x, yo[i], xo[i], true, ref result[2]);
                CheckHorizontalOrVertical(y, x, yo[i], xo[i], false, ref result[3]);
                CheckDiagonal(x, y, xo[i], yo[i], 1, 1, ref result[4]);
                CheckDiagonal(x, y, xo[i], yo[i], 1, -1, ref result[5]);
                CheckDiagonal(x, y, xo[i], yo[i], -1, 1, ref result[6]);
                CheckDiagonal(x, y, xo[i], yo[i], -1, -1, ref result[7]);
            }

            return result.Sum();
        }

        private static void CheckHorizontalOrVertical(int x, int y, int xo, int yo, bool after, ref int result)
        {
            if (y == yo && (after && xo > x || !after && xo < x))
            {
                result = Math.Min(result, Math.Abs(xo - x) - 1);
            }
        }

        private static void CheckDiagonal(int x, int y, int xo, int yo, int dx, int dy, ref int result)
        {
            if (Math.Abs(xo - x) == Math.Abs(yo - y) && (xo - x) * dx > 0 && (yo - y) * dy > 0)
            {
                result = Math.Min(result, Math.Abs(xo - x) - 1);
            }
        }
    }
}
