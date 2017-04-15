using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public class Gemstones
    {
        public static int Solve(string[] rocks)
        {
            int n = rocks.Length;
            bool[,] was = new bool[256, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < rocks[i].Length; j++)
                {
                    was[rocks[i][j], i] = true;
                }
            }

            bool can;
            int result = 0;
            for (int i = 'a'; i <= 'z'; i++)
            {
                can = true;
                for (int j = 0; j < n; j++)
                {
                    can &= was[i, j];
                }

                if (can)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
