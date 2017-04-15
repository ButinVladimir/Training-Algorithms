using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_25
{
    public class EvenDistance
    {
        private int n;
        private List<int>[] ribs;

        public EvenDistance(int n)
        {
            this.n = n;
            this.ribs = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }
        }

        public void AddRib(int x, int y)
        {
            x--;
            y--;
            this.ribs[x].Add(y);
            this.ribs[y].Add(x);
        }

        public long Solve()
        {
            int[] queue = new int[this.n];
            int[] pred = new int[this.n];

            this.BFS(queue, pred);

            long[] even = new long[this.n];
            long[] odd = new long[this.n];

            this.Build(queue, pred, even, odd);

            return this.Calculate(queue, pred, even, odd);
        }

        private void BFS(int[] queue, int[] pred)
        {
            bool[] visited = new bool[this.n];

            int left = 0;
            int right = 0;
            queue[0] = 0;
            pred[0] = -1;
            visited[0] = true;

            int from;

            while (left <= right)
            {
                from = queue[left];
                left++;

                foreach (int to in this.ribs[from])
                {
                    if (visited[to])
                    {
                        continue;
                    }

                    right++;
                    queue[right] = to;
                    visited[to] = true;
                    pred[to] = from;
                }
            }
        }

        private void Build(int[] queue, int[] pred, long[] even, long[] odd)
        {
            int from;
            for (int i = n - 1; i >= 0; i--)
            {
                from = queue[i];
                even[from] = 1;
                odd[from] = 0;

                foreach(int to in this.ribs[from])
                {
                    if (pred[from] == to)
                    {
                        continue;
                    }

                    even[from] += odd[to];
                    odd[from] += even[to];
                }
            }
        }

        private long Calculate(int[] queue, int[] pred, long[] even, long[] odd)
        {
            int from;
            long result = 0;
            long e, o;

            for (int i = n - 1; i >= 0; i--)
            {
                from = queue[i];
                e = even[from];
                o = odd[from];

                foreach (int to in this.ribs[from])
                {
                    if (pred[from] == to)
                    {
                        continue;
                    }

                    e -= odd[to];
                    o -= even[to];

                    result += e * odd[to] + o * even[to];
                }
            }

            return result;
        }
    }
}
