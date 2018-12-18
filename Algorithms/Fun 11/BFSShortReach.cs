using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public class BFSShortReach
    {
        private int n;
        private List<int>[] ribs;

        public BFSShortReach(int n)
        {
            this.n = n;
            this.ribs = new List<int>[this.n];
            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }
        }

        public void AddRib(int a, int b)
        {
            a--;
            b--;
            this.ribs[a].Add(b);
            this.ribs[b].Add(a);
        }

        public int[] Solve(int start)
        {
            start--;
            bool[] visited = new bool[this.n];
            int[] distance = new int[this.n];
           
            for (int i = 0; i < this.n; i++)
            {
                distance[i] = -1;
            }

            visited[start] = true;
            distance[start] = 0;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int from = queue.Dequeue(); 

                foreach (int to in this.ribs[from])
                {
                    if (!visited[to])
                    {
                        distance[to] = distance[from] + 6;
                        visited[to] = true;

                        queue.Enqueue(to);
                    }
                }
            }

            return distance.Where((value, key) => key != start).ToArray();
        }
    }
}
