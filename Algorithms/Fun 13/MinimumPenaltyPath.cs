using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public class MinimumPenaltyPath
    {
        private int n;
        private List<Rib>[] ribs;

        public MinimumPenaltyPath(int n)
        {
            this.n = n;
            this.ribs = new List<Rib>[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<Rib>();
            }
        }

        public void AddRib(int from, int to, int c)
        {
            from--;
            to--;
            this.ribs[from].Add(new Rib() { To = to, C = c });
            this.ribs[to].Add(new Rib() { To = from, C = c });
        }

        public int Solve(int a, int b)
        {
            a--;
            b--;
            HashSet<int>[] dist = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = new HashSet<int>();
            }

            dist[a].Add(0);
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(a, 0));
            while (queue.Count > 0)
            {
                Tuple<int, int> current = queue.Dequeue();
                int from = current.Item1;
                int currentDist = current.Item2;

                foreach (Rib rib in this.ribs[from])
                {
                    int to = rib.To;
                    int nextDist = currentDist | rib.C;

                    if (!dist[to].Contains(nextDist))
                    {
                        dist[to].Add(nextDist);
                        queue.Enqueue(Tuple.Create(to, nextDist));
                    }
                }
            }

            return dist[b].Count > 0 ? dist[b].Min() : -1;
        }

        private class Rib
        {
            public int To { get; set; }
            public int C { get; set; }
        }
    }
}
