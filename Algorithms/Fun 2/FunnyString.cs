using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class FunnyString
    {
        public static bool Solve(string s)
        {
            int l = s.Length;
            for (int i = 0; i < l - 1; i++)
            {
                if (Math.Abs(s[i] - s[i + 1]) != Math.Abs(s[l - 1 - i] - s[l - 1 - i - 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
