using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public class JackGoesToRapture
    {
        private const long MaxRibValue = 10000000;
        private int n;
        private bool[] visited;
        private Queue<int> queue;

        private List<Rib>[] ribs;

        public JackGoesToRapture(int n)
        {
            this.n = n;

            this.ribs = new List<Rib>[this.n];
            for (int i = 0; i < this.n; i++)
            {
                this.ribs[i] = new List<Rib>();
            }

            this.visited = new bool[this.n];
            this.queue = new Queue<int>();
        }

        public void AddRib(int a, int b, long v)
        {
            a--;
            b--;
            this.ribs[a].Add(new Rib() { To = b, Value = v });
            this.ribs[b].Add(new Rib() { To = a, Value = v });
        }

        public long Solve()
        {
            if (!this.IsReachable(MaxRibValue))
            {
                return -1;
            }

            long value = 0;
            long step = MaxRibValue;
            long nextValue;

            while (step > 0)
            {
                nextValue = value + step;
                if (this.IsReachable(nextValue))
                {
                    step /= 2;
                }
                else
                {
                    value = nextValue;
                }
            }

            return value + 1;
        }

        private bool IsReachable(long value)
        {
            for (int i = 0; i < this.n; i++)
            {
                this.visited[i] = false;
            }
            this.queue.Clear();
            this.queue.Enqueue(0);
            this.visited[0] = true;
            int from;

            while (this.queue.Count > 0)
            {
                from = this.queue.Dequeue();
                foreach (Rib rib in this.ribs[from])
                {
                    if (!this.visited[rib.To] && rib.Value <= value)
                    {
                        this.visited[rib.To] = true;
                        this.queue.Enqueue(rib.To);
                    }
                }
            }

            return this.visited[this.n - 1];
        }

        private class Rib
        {
            public int To { get; set; }
            public long Value { get; set; }
        }
    }
}
