using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public class EvenTree
    {
        private int n;

        private List<int>[] ribs;

        public EvenTree(int n)
        {
            this.n = n;
            this.ribs = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }
        }

        public void AddRib(int from, int to)
        {
            from--;
            to--;
            this.ribs[from].Add(to);
            this.ribs[to].Add(from);
        }

        public int Solve()
        {
            bool[] visited = new bool[this.n];
            int[] previous = new int[this.n];
            int[] count = new int[this.n];

            for (int i = 0; i < this.n; i++)
            {
                visited[i] = false;
                previous[i] = -1;
                count[i] = 1;
            }

            int[] queue = new int[this.n];
            int left = 0;
            int right = 0;
            queue[left] = 0;
            visited[0] = true;

            while (left <= right)
            {
                int from = queue[left];
                left++;

                foreach (int to in this.ribs[from])
                {
                    if (previous[from] == to)
                    {
                        continue;
                    }

                    right++;
                    queue[right] = to;
                    previous[to] = from;
                    visited[to] = true;
                }
            }

            int result = 0;

            left = n - 1;
            while (left >= 0)
            {
                int from = queue[left];
                left--;

                foreach (int to in this.ribs[from])
                {
                    if (previous[from] == to)
                    {
                        continue;
                    }

                    if (count[to] % 2 == 1)
                    {
                        count[from] += count[to];
                    }
                    else
                    {
                        result++;
                    }
                }                
            }

            return result;
        }
    }
}
