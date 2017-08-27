using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_19
{
    public static class RearrangeArray
    {
        public static string Solve(string s)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!counts.ContainsKey(s[i]))
                {
                    counts[s[i]] = 0;
                }

                counts[s[i]]++;
            }

            Queue<Tuple<char, int>> queue = new Queue<Tuple<char, int>>();
            foreach (var letter in counts)
            {
                queue.Enqueue(new Tuple<char, int>(letter.Key, letter.Value));
            }

            StringBuilder sb = new StringBuilder();

            while (queue.Count > 1)
            {
                var pair1 = queue.Dequeue();
                var pair2 = queue.Dequeue();

                if (pair1.Item2 < pair2.Item2)
                {
                    var buffer = pair1;
                    pair1 = pair2;
                    pair2 = buffer;
                }

                int count = pair2.Item2;
                for (int i = 0; i < count; i++)
                {
                    sb.Append(pair1.Item1);
                    sb.Append(pair2.Item1);
                }

                if (pair1.Item2 > count)
                {
                    queue.Enqueue(new Tuple<char, int>(pair1.Item1, pair1.Item2 - count));
                }
            }

            if (queue.Count == 1)
            {
                var pair = queue.Dequeue();
                if (pair.Item2 == 1)
                {
                    sb.Append(pair.Item1);
                }
                else
                {
                    return null;
                }
            }

            return sb.ToString();
        }
    }
}
