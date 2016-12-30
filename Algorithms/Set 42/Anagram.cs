using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_42
{
    class Anagram
    {
        private static string Encode(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Sort(charArray);

            StringBuilder sb = new StringBuilder();
            sb.Append(charArray);

            return sb.ToString();
        }

        public static string[] Solve(string[] input)
        {
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                string key = Encode(input[i]);

                if (!map.ContainsKey(key))
                {
                    map[key] = new List<int>();
                }
                map[key].Add(i);
            }

            List<string> result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string key = Encode(input[i]);

                if (map[key].Count > 1)
                {
                    result.Add(input[i]);
                }
            }

            return result.ToArray();
        }
    }
}
