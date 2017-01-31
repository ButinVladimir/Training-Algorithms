using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_65
{
    class Components
    {
        private List<int>[] ribs;

        private bool[] visited;

        public Components(int n)
        {
            this.N = n;

            this.ribs = new List<int>[this.N];
            for (int i = 0; i < this.N; i++)
            {
                this.ribs[i] = new List<int>();
            }

            this.visited = new bool[this.N];
        }

        public int N { get; private set; }

        public int Min { get; private set; }

        public int Max { get; private set; }

        public void AddRib(int a, int b)
        {
            this.ribs[a].Add(b);
            this.ribs[b].Add(a);
        }

        public void Solve()
        {
            int count;
            this.Min = this.N;
            this.Max = 0;
            
            for (int i = 0; i < this.N; i++)
            {
                count = this.BFS(i);
                if (count > 1)
                {
                    this.Min = Math.Min(this.Min, count);
                    this.Max = Math.Max(this.Max, count);
                }
            }
        }

        private int BFS(int start)
        {
            if (this.visited[start] == true)
            {
                return 0;
            }

            int counter = 0;
            int position = 0;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            this.visited[start] = true;

            while (queue.Count > 0)
            {
                position = queue.Dequeue();
                counter++;

                foreach (int to in this.ribs[position])
                {
                    if (!this.visited[to])
                    {
                        queue.Enqueue(to);
                        this.visited[to] = true;
                    }
                }
            }

            return counter;
        }
    }
}
