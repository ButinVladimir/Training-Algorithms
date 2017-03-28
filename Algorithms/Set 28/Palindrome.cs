using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public static class Palindrome
    {
        private const char Separator = '#';

        public static string Solve(string input)
        {
            int n = input.Length;
            int n2 = 2 * n - 1;
            char[] chars = new char[n2];

            for (int i = 0; i < n; i++)
            {
                chars[2 * i] = input[i];
                if (2 * i + 1 < n2)
                {
                    chars[2 * i + 1] = Separator;
                }
            }

            int[] length = new int[n2];
            int pos = -1;
            int right = -1;
            int nextRight;

            for (int i = 0; i < n2; i++)
            {
                if (i > right)
                {
                    length[i] = 0;
                }
                else
                {
                    length[i] = length[pos - (i - pos)];
                    if (i + length[i] - 1 > right)
                    {
                        length[i] -= (i + length[i] - 1 - right);
                    }
                }

                while (i - length[i] >= 0 && i + length[i] < n2 && chars[i - length[i]] == chars[i + length[i]])
                {
                    length[i]++;
                }

                nextRight = i + length[i] - 1;
                if (nextRight > right)
                {
                    pos = i;
                    right = nextRight;
                }

                if (nextRight == n2 - 1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(input.Substring(0, i / 2 + 1));

                    int next = i / 2;
                    if (chars[i] == Separator)
                    {
                        next = i / 2 + 1;
                    }

                    sb.Append(input.Substring(0, next).Reverse().ToArray());

                    return sb.ToString();
                }
            }

            return "";
        }
    }
}
