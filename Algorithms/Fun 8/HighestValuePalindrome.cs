using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class HighestValuePalindrome
    {
        public static string Solve(string s, int k)
        {
            int n = s.Length;
            char[] input = s.ToCharArray();
            bool[] changed = new bool[n];

            int l = 0;
            int r = n - 1;

            while (l < r)
            {
                if (input[l] > input[r])
                {
                    input[r] = input[l];
                    changed[r] = true;
                    k--;
                }
                else
                if (input[l] < input[r])
                {
                    input[l] = input[r];
                    changed[l] = true;
                    k--;
                }

                l++;
                r--;
            }

            if (k < 0)
            {
                return "-1";
            }

            l = 0;
            r = n - 1;
            while (l < r && k > 0)
            {
                if (input[l] == '9')
                {
                    l++;
                    r--;
                    continue;
                }

                if (changed[l] || changed[r])
                {
                    k--;
                    input[l] = '9';
                    input[r] = '9';
                }
                else if (k > 1)
                {
                    k -= 2;
                    input[l] = '9';
                    input[r] = '9';
                }

                l++;
                r--;
            }

            if (l == r && k > 0)
            {
                input[l] = '9';
            }

            return new string(input);
        }
    }
}
