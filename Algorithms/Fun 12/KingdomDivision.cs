using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public class KingdomDivisionNaive
    {
        private long mod = 1000000000 + 7;
        private List<int>[] ribs;
        private bool[] colors;
        private int n;
        private long result;

        public KingdomDivisionNaive(int n)
        {
            this.n = n;
            this.ribs = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }

            this.colors = new bool[n];
        }

        public void AddRib(int a, int b)
        {
            a--;
            b--;
            this.ribs[a].Add(b);
            this.ribs[b].Add(a);
        }

        public long Solve()
        {
            this.result = 0;

            this.colors[0] = true;
            this.Solve(1);

            return this.result * 2;
        }

        private void Solve(int pos)
        {
            if (pos == this.n)
            {
                bool correct = true;
                bool same;

                for (int from = 0; from < this.n; from++)
                {
                    same = false;
                    foreach (int to in this.ribs[from])
                    {
                        same |= this.colors[from] == this.colors[to];
                    }

                    correct &= same;
                }

                if (correct)
                {
                    this.result++;
                }

                return;
            }

            this.colors[pos] = false;
            this.Solve(pos + 1);
            this.colors[pos] = true;
            this.Solve(pos + 1);
        }
    }

    public class KingdomDivision
    {
        private long mod = 1000000000 + 7;
        private List<int>[] ribs;
        private int[] previous;
        private int[] queue;
        private long[] asRoot;
        private long[] asInnerNode;

        public KingdomDivision(int n)
        {
            this.ribs = new List<int>[n];
            this.previous = new int[n];
            this.queue = new int[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }

            asRoot = new long[n];
            asInnerNode = new long[n];
        }

        public void AddRib(int a, int b)
        {
            a--;
            b--;
            this.ribs[a].Add(b);
            this.ribs[b].Add(a);
        }

        public long Solve()
        {
            this.previous[0] = -1;
            this.queue[0] = 0;

            int left = 0;
            int right = 1;
            int from;
            while (left < right)
            {
                from = this.queue[left];
                left++;

                foreach (var to in this.ribs[from])
                {
                    if (to == this.previous[from])
                    {
                        continue;
                    }

                    this.queue[right] = to;
                    this.previous[to] = from;
                    right++;
                }
            }

            left = right - 1;
            bool isLeaf;
            long[] suffixes = new long[100001];
            long sumRoot;

            while (left >= 0)
            {
                from = this.queue[left];
                left--;
                isLeaf = from != 0 && this.ribs[from].Count == 1;

                this.asInnerNode[from] = 1;
                sumRoot = 1;
                foreach (int to in this.ribs[from])
                {
                    if (to == this.previous[from])
                    {
                        continue;
                    }

                    sumRoot = (sumRoot * this.asRoot[to]) % mod;
                    this.asInnerNode[from] = this.asInnerNode[from] * ((this.asInnerNode[to] + this.asRoot[to]) % mod) % mod;
                }
                this.asRoot[from] = (this.asInnerNode[from] - sumRoot + mod) % mod;
            }

            return (this.asRoot[0] * 2) % mod;
        }
    }
}
