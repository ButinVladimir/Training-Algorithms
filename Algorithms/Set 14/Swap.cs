using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_14
{
    public static class Swap0
    {
        public static List<Tuple<int, int>> Solve(int[] source, int[] target)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            int n = source.Length;
            int[] map = new int[n];
            for (int i = 0; i < n; i++)
            {
                map[source[i]] = i;
            }


            for (int i = 0; i < n; i++)
            {
                if (source[i] == target[i])
                {
                    continue;
                }

                if (source[i] == 0)
                {
                    Swap(map, source, map[0], map[target[i]], result);
                }
                else
                if (target[i] == 0)
                {
                    Swap(map, source, map[0], map[source[i]], result);
                }
                else
                {
                    int v1 = source[i];
                    int v2 = target[i];

                    Swap(map, source, map[v1], map[0], result);
                    Swap(map, source, map[0], map[v2], result);
                }
            }

            return result;
        }

        private static void Swap(int[] map, int[] array, int p1, int p2, List<Tuple<int, int>> result)
        {
            int v1 = array[p1];
            int v2 = array[p2];

            map[v1] = p2;
            map[v2] = p1;

            array[p1] = v2;
            array[p2] = v1;

            result.Add(new Tuple<int, int>(p1, p2));
        }
    }
}
