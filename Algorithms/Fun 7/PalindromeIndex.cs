using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class PalindromeIndex
    {
        public static int Solve(string s)
        {
            if (IsPalindrome(s, 0, s.Length - 1))
            {
                return -1;
            }

            int start = 0;
            int end = s.Length - 1;
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    if (IsPalindrome(s, start + 1, end))
                    {
                        return start;
                    }

                    if (IsPalindrome(s, start, end - 1))
                    {
                        return end;
                    }

                    return -1;
                }

                start++;
                end--;
            }

            return -1;
        }

        private static bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }
    }
}
