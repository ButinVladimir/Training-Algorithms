using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public class WeightedUniformStrings
    {
        private HashSet<int> substrings = new HashSet<int>();

        public WeightedUniformStrings(string s)
        {
            int l = 0;
            int r;
            while (l < s.Length)
            {
                r = l;

                while (r < s.Length && s[l] == s[r])
                {
                    substrings.Add(((int)s[l] - 'a' + 1) * (r - l + 1));
                    r++;
                }

                l = r;
            }
        }

        public bool IsIn(int value)
        {
            return this.substrings.Contains(value);
        }
    }
}
