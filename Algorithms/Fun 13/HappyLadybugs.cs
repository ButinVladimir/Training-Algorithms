using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class HappyLadybugs
    {
        public static bool Solve(string s)
        {
            if (s.Length == 1)
            {
                return s[0] == '_';
            }

            bool valid = true;

            for (int i = 0; i < s.Length && valid; i++)
            {
                if (s[i] == '_')
                {
                    continue;
                }

                bool buffer = false;

                if (i > 0 && s[i] == s[i - 1])
                {
                    buffer = true;
                }

                if (i < s.Length - 1 && s[i] == s[i + 1])
                {
                    buffer = true;
                }

                valid = valid && buffer;
            }

            if (valid)
            {
                return true;
            }

            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (char c in s)
            {
                int v;
                if (!count.TryGetValue(c, out v))
                {
                    v = 0;
                }
                v++;

                count[c] = v;
            }

            foreach (var kv in count)
            {
                if (kv.Key == '_')
                {
                    continue;
                }

                if (kv.Value == 1)
                {
                    return false;
                }
            }

            return count.ContainsKey('_');
        }
    }
}
