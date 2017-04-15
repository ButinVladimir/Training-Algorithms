using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public class Anagrams
    {
        public static int Solve(string a, string b)
        {
            int[] chars = new int[256];

            for (int i = 0; i < a.Length; i++)
            {
                chars[a[i]]++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                chars[b[i]]--;
            }

            int result = 0;
            for (int i = 0; i < 256; i++)
            {
                result += Math.Abs(chars[i]);
            }

            return result;
        }
    }
}
