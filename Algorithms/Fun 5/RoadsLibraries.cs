using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public class RoadsLibraries
    {
        public int N { get; private set; }

        public long CLib { get; set; }

        public long CRoad { get; set; }

        public RoadsLibraries(int n)
        {
            this.N = n;

            this.ribs = new List<int>[this.N];

            for (int i = 0; i < this.N; i++)
            {
                this.ribs[i] = new List<int>();
            }

            this.visited = new bool[this.N];
            this.queue = new int[this.N];
        }

        private List<int>[] ribs;

        private bool[] visited;

        private int[] queue;

        public void AddRib(int from, int to)
        {
            ribs[from].Add(to);
            ribs[to].Add(from);
        }

        public long Solve()
        {
            long result = 0;

            for (int i = 0; i < this.N; i++)
            {
                if (!this.visited[i])
                {
                    long count = this.Bfs(i);

                    result += Math.Min(count * this.CLib, (count - 1) * this.CRoad + this.CLib);
                }
            }

            return result;
        }

        private long Bfs(int start)
        {
            int queueStart = 0;
            int queueFinish = 0;
            long count = 0;
            this.queue[queueStart] = start;
            this.visited[start] = true;

            while (queueStart <= queueFinish)
            {
                count++;

                foreach (int to in this.ribs[this.queue[queueStart]])
                {
                    if (this.visited[to])
                    {
                        continue;
                    }

                    queueFinish++;
                    this.queue[queueFinish] = to;
                    this.visited[to] = true;
                }

                queueStart++;
            }

            return count;
        }
    }
}
