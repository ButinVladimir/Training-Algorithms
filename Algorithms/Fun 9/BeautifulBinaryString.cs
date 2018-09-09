using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class BeautifulBinaryString
    {
        public static int Solve(string s)
        {
            int l = 0;
            int r;
            int result = 0;
            while (l < s.Length)
            {
                if (s[l] == '1')
                {
                    l++;
                    continue;
                }

                if (l < s.Length - 2 && s.Substring(l, 3) == "010")
                {
                    result++;
                    l += 3;
                }
                else
                {
                    l++;
                }
            }

            return result;
        }
    }
}
