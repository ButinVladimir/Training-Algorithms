using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_32
{
    public class Distance
    {
        private const int Undef = -1;

        public static bool Solve(string s, char a, char b, int distance)
        {
            int pa = Undef;
            int pb = Undef;

            for (int i = 0; i < s.Length; i++)
            {
                if (a == b)
                {
                    pa = pb;
                    pb = i;
                }
                else if (s[i] == a)
                {
                    pa = i;
                }
                else if (s[i] == b)
                {
                    pb = i;
                }

                if (pa != Undef && pb != Undef && Math.Abs(pa - pb) <= distance)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
