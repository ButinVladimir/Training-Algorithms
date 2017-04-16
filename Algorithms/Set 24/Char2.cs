using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_24
{
    public static class Char2
    {
        public const int Alp = 26;

        public static int Solve(string[] input)
        {
            int[] one = new int[Alp];
            int[,] two = new int[Alp, Alp];
            bool[] was = new bool[Alp];
            int count, p1, p2;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < Alp; j++)
                {
                    was[j] = false;
                }
                count = 0;

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (!was[input[i][j] - 'a'])
                    {
                        was[input[i][j] - 'a'] = true;
                        count++;
                    }

                    if (count > 2)
                    {
                        break;
                    }
                }

                if (count == 1)
                {
                    for (int j = 0; j < Alp; j++)
                    {
                        if (was[j])
                        {
                            one[j] += input[i].Length;
                        }
                    }
                }

                if (count == 2)
                {
                    p1 = 0;
                    while (!was[p1])
                    {
                        p1++;
                    }

                    p2 = p1 + 1;
                    while (!was[p2])
                    {
                        p2++;
                    }

                    two[p1, p2] += input[i].Length;
                }
            }

            for (int i = 0; i < Alp; i++)
            {
                for (int j = i + 1; j < Alp; j++)
                {
                    two[i, j] += one[i] + one[j];
                }
            }

            int max = 0;
            for (int i = 0; i < Alp; i++)
            {
                for (int j = i + 1; j < Alp; j++)
                {
                    max = Math.Max(max, two[i, j]);
                }
            }

            return max;
        }
    }
}
