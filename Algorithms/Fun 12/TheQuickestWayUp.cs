using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public class TheQuickestWayUp
    {
        private const int N = 100;

        private int[] next = new int[N];

        public TheQuickestWayUp()
        {
            for (int i = 0; i < N; i++)
            {
                this.next[i] = i;
            }
        }

        public void AddTeleport(int start, int end)
        {
            start--;
            end--;
            next[start] = end;
        }

        public int Solve()
        {
            bool[] visited = new bool[N];
            int[] dist = new int[N];
            for (int i = 0; i < N; i++)
            {
                dist[i] = -1;
            }

            dist[0] = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            int from, to;
            while (queue.Count > 0)
            {
                from = queue.Dequeue();
                for (int d = 1; d <= 6 && from + d < N; d++)
                {
                    to = next[from + d];
                    if (!visited[to])
                    {
                        visited[to] = true;
                        dist[to] = dist[from] + 1;
                        queue.Enqueue(to);
                    }
                }
            }

            return dist[N - 1];
        }
    }
}
