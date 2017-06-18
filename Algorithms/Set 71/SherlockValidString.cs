using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class SherlockValidString
    {
        public static bool Solve(string input)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();

            int value;
            for (int i = 0; i < input.Length; i++)
            {
                if (!chars.TryGetValue(input[i], out value))
                {
                    value = 0;
                }

                value++;
                chars[input[i]] = value;
            }

            return Check(chars, chars[input[0]]) || Check(chars, chars[input[0]] - 1);
        }

        private static bool Check(Dictionary<char, int> chars, int val)
        {
            if (val == 0)
            {
                return false;
            }

            bool odd = false;

            foreach (var kv in chars)
            {
                if (kv.Value == val + 1 || val > 1 && kv.Value == 1)
                {
                    if (odd)
                    {
                        return false;
                    }

                    odd = true;
                }
                else
                if (kv.Value != val)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
