using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_37
{
    class ShortestPath
    {
        private const int Undef = -1;

        private List<Rib>[] ribs;
        private int[] pred;
        private int[] next;
        private int[] weight;
        private int[] queue;

        public ShortestPath(int n)
        {
            this.ribs = new List<Rib>[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<Rib>();
            }

            this.N = n;
        }

        public int N { get; private set; }

        public void AddRib(int from, int to, int weight)
        {
            this.ribs[from].Add(new Rib(to, weight));
            this.ribs[to].Add(new Rib(from, weight));
        }

        public Tuple<int, List<int>> Solve(int root)
        {
            this.pred = new int[this.N];
            this.next = new int[this.N];
            this.weight = new int[this.N];
            this.queue = new int[this.N];
            
            this.CalculatePath(this.BuildQueue(root));

            return new Tuple<int, List<int>>(this.weight[root], this.BuildPath(root));
        }

        private int BuildQueue(int root)
        {
            int leftPointer = 0;
            int rightPointer = 1;
            int from, to;

            this.queue[0] = root;

            for (int i = 0; i < this.N; i++)
            {
                this.pred[i] = Undef;
            }

            while (leftPointer < rightPointer)
            {
                from = this.queue[leftPointer];

                foreach (var rib in this.ribs[from])
                {
                    to = rib.To;
                    if (this.pred[from] == to)
                    {
                        continue;
                    }

                    this.pred[to] = from;
                    this.queue[rightPointer++] = to;
                }

                leftPointer++;
            }

            return rightPointer;
        }

        private void CalculatePath(int rightPointer)
        {
            int from, to;

            for (int i = rightPointer - 1; i >= 0; i--)
            {
                from = this.queue[i];
                this.next[i] = Undef;
                this.weight[i] = 0;

                foreach (var rib in this.ribs[from])
                {
                    to = rib.To;
                    if (this.pred[from] == to)
                    {
                        continue;
                    }

                    if (this.next[from] == Undef || this.weight[from] > this.weight[to] + rib.Weight)
                    {
                        this.next[from] = to;
                        this.weight[from] = this.weight[to] + rib.Weight;
                    }
                }
            }
        }

        private List<int> BuildPath(int root)
        {
            List<int> path = new List<int>();
            int currentNode = root;
            while (currentNode != Undef)
            {
                path.Add(currentNode);
                currentNode = this.next[currentNode];
            }

            return path;
        }

        private class Rib
        {
            public Rib(int to, int weight)
            {
                this.To = to;
                this.Weight = weight;
            }

            public int To { get; private set; }
            public int Weight { get; private set; }
        }
    }
}
