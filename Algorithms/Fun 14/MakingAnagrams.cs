using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class MakingAnagrams
    {
        public static int Solve(string a, string b)
        {
            int[] cnt = new int[26];
            for (int i = 0; i < a.Length; i++)
            {
                cnt[a[i] - 'a']++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                cnt[b[i] - 'a']--;
            }

            int result = 0;
            for (int i = 0; i < 26; i++)
            {
                result += Math.Abs(cnt[i]);
            }

            return result;
        }
    }
}
