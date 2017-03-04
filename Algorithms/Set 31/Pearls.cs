using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_31
{
    public class Pearls
    {
        public static List<Tuple<int, int>> Solve(int[] pearls)
        {
            int n = pearls.Length;
            int[] next = new int[n];
            int[] length = new int[n];

            next[n - 1] = -1;
            length[n - 1] = 0;

            int np;

            Dictionary<int, int> pred = new Dictionary<int, int>()
            {
                { pearls[n - 1], n - 1 }
            };

            for (int position = n - 2; position >= 0; position--)
            {
                next[position] = next[position + 1];
                length[position] = length[position + 1];

                if (pred.ContainsKey(pearls[position]))
                {
                    np = pred[pearls[position]] + 1;

                    if (np < n && length[np] != 0 && length[np] + 1 > length[position])
                    {
                        next[position] = np;
                        length[position] = length[np] + 1;
                    }
                    else if (1 > length[position])
                    {
                        next[position] = -1;
                        length[position] = 1;
                    }
                }

                pred[pearls[position]] = position;
            }

            if (length[0] == 0)
            {
                return null;
            }

            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            int current = 0;
            while (current != -1)
            {
                np = next[current];
                if (np == -1)
                {
                    result.Add(new Tuple<int, int>(current + 1, n));
                    break;
                }

                result.Add(new Tuple<int, int>(current + 1, np));
                current = np;
            }

            return result;
        }
    }
}
