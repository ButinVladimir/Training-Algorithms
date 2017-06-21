using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_2
{
    public static class TwoButtons
    {
        public static int Solve(int n, int m)
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> distance = new Dictionary<int, int> { { n, 0 } };

            queue.Enqueue(n);
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == m)
                {
                    return distance[current];
                }

                if (current < m && !distance.ContainsKey(current * 2))
                {
                    distance[current * 2] = distance[current] + 1;
                    queue.Enqueue(current * 2);
                }

                if (current > 0 && !distance.ContainsKey(current - 1))
                {
                    distance[current - 1] = distance[current] + 1;
                    queue.Enqueue(current - 1);
                }
            }

            return distance[m];
        }
    }
}
