using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_37
{
    class Dice
    {
        public static long Solve(int n, int m, int x)
        {
            long[,,] tempResult = new long[n + 1, m + 1, x + 1];
            tempResult[0, 0, 0] = 1;

            for (int dices = 0; dices < n; dices++)
            {
                for (int sum = 0; sum < x; sum++)
                {
                    for (int value = 1; value <= m; value++)
                    {
                        tempResult[dices, value, sum] += tempResult[dices, value - 1, sum];
                        if (sum + value <= x)
                        {
                            tempResult[dices + 1, value, sum + value] += tempResult[dices, value, sum];
                        }
                    }
                }
            }

            long result = 0;
            for (int i = 0; i <= m; i++)
            {
                result += tempResult[n, i, x];
            }

            return result;
        }
    }
}
