using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class HackerRankInString
    {
        private const string Needle = "hackerrank";

        public static bool Solve(string hay)
        {
            int posNeedle = 0;
            int posHay = 0;

            while (posHay < hay.Length && posNeedle < Needle.Length)
            {
                if (hay[posHay] == Needle[posNeedle])
                {
                    posNeedle++;
                }

                posHay++;
            }

            return posNeedle == Needle.Length;
        }
    }
}
