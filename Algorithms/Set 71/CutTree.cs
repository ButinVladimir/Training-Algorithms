using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public class CutTree
    {
        public int N { get; private set; }
        public int[] Data { get; private set; }

        private List<int>[] ribs;

        public CutTree(int n)
        {
            this.N = n;
            this.Data = new int[n];
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
            int sum = 0;
            for (int i = 0; i < this.N; i++)
            {
                sum += this.Data[i];
            }

            int result = sum;
            int[] subtreeSum = new int[this.N];
            int[] pred = new int[this.N];

            int[] queue = new int[this.N];
            pred[0] = -1;

            int left = 0;
            int right = 0;
            while (left <= right)
            {
                int from = queue[left++];

                foreach (int to in this.ribs[from])
                {
                    if (to != pred[from])
                    {
                        queue[++right] = to;
                        pred[to] = from;
                    }
                }
            }

            for (int i = this.N - 1; i >= 0; i--)
            {
                int from = queue[i];
                subtreeSum[from] = this.Data[from];

                foreach (int to in this.ribs[from])
                {
                    if (to != pred[from])
                    {
                        subtreeSum[from] += subtreeSum[to];
                    }
                }

                result = Math.Min(result, Math.Abs(sum - 2 * subtreeSum[from]));
            }

            return result;
        }
    }
}
