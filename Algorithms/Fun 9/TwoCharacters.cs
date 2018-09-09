using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class TwoCharacters
    {
        public static int Solve(string s)
        {
            int result = 0;

            for (char c1 = 'a'; c1 <= 'z'; c1++)
            {
                for (char c2 = 'a'; c2 <= 'z'; c2++)
                {
                    if (c1 != c2)
                    {
                        result = Math.Max(result, SolveInternal(s, c1, c2));
                    }
                }
            }

            return result;
        }

        private static int SolveInternal(string s, char c1, char c2)
        {
            int p = 0;
            while (p < s.Length && s[p] != c1)
            {
                if (s[p] == c2)
                {
                    return 0;
                }
                p++;
            }
            if (p == s.Length)
            {
                return 0;
            }
            p++;

            int result = 1;
            bool second = true;
            while (p < s.Length)
            {
                if (second)
                {
                    if (s[p] == c2)
                    {
                        second = false;
                        result++;
                    }
                    else if (s[p] == c1)
                    {
                        return 0;
                    }
                }
                else
                {
                    if (s[p] == c1)
                    {
                        second = true;
                        result++;
                    }
                    else if (s[p] == c2)
                    {
                        return 0;
                    }
                }

                p++;
            }

            return result > 1 ? result : 0;
        }
    }
}
