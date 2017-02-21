using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_38
{
    public class Connecting
    {
        private List<int>[] ribs;

        public Connecting(int n)
        {
            this.ribs = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }

            this.N = n;
        }

        public int N { get; private set; }

        public void AddRib(int a, int b)
        {
            this.ribs[a].Add(b);
            this.ribs[b].Add(a);
        }

        public int Components()
        {
            bool[] visited = new bool[this.N];

            int result = 0;

            for (int i = 0; i < this.N; i++)
            {
                if (!visited[i])
                {
                    this.Visit(i, visited);
                    result++;
                }
            }

            return result - 1;
        }

        private void Visit(int start, bool[] visited)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            int current;
            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                foreach (int next in this.ribs[current])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
        }
    }
}
