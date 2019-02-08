using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class ArithmeticExpressions
    {
        private const int Mod = 101;
        private enum Operation { NoOp, Start, Minus, Plus, Multiply };

        public static string Solve(int[] values)
        {
            int n = values.Length;
            Operation[,] ops = new Operation[n, Mod];
            int[,] prev = new int[n, Mod];
            ops[0, values[0]] = Operation.Start;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < Mod; j++)
                {
                    if (ops[i - 1, j] == Operation.NoOp)
                    {
                        continue;
                    }

                    ops[i, (j + values[i]) % Mod] = Operation.Plus;
                    prev[i, (j + values[i]) % Mod] = j;

                    ops[i, (j - values[i] + Mod) % Mod] = Operation.Minus;
                    prev[i, (j - values[i] + Mod) % Mod] = j;

                    ops[i, (j * values[i]) % Mod] = Operation.Multiply;
                    prev[i, (j * values[i]) % Mod] = j;
                }
            }

            LinkedList<string> operations = new LinkedList<string>();

            int value = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                operations.AddFirst(values[i].ToString());

                switch (ops[i, value])
                {
                    case Operation.Plus: operations.AddFirst("+"); break;
                    case Operation.Minus: operations.AddFirst("-"); break;
                    case Operation.Multiply: operations.AddFirst("*"); break;
                }

                value = prev[i, value];
            }

            return string.Join("", operations);
        }
    }
}
