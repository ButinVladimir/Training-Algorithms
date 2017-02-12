using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_67
{
    class HackerString
    {
        private const string Needle = "hackerrank";

        public static bool Solve(string s)
        {
            int position = 0;
            for (int i = 0; i < s.Length && position < Needle.Length; i++)
            {
                if (s[i] == Needle[position])
                {
                    position++;
                }
            }

            return position == Needle.Length;
        }
    }
}
