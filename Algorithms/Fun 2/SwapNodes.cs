using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public class SwapNodes
    {
        private const int End = -2;
        private int n;
        private int[,] ribs;

        public SwapNodes(int n)
        {
            this.n = n;
            this.ribs = new int[n, 2];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    this.ribs[i, j] = End;
                }
            }
        }

        public void AddRibs(int from, int left, int right)
        {
            if (left < 0)
            {
                left = End;
            }

            if (right < 0)
            {
                right = End;
            }
            this.ribs[from, 0] = left;
            this.ribs[from, 1] = right;
        }

        public List<int> StartVisit(int k)
        {
            List<int> result = new List<int>();
            this.Visit(0, k, 1 % k, result);

            return result;
        }

        public void Visit(int node, int k, int height, List<int> result)
        {
            if (node == End)
            {
                return;
            }

            if (height == 0)
            {
                int buffer = this.ribs[node, 0];
                this.ribs[node, 0] = this.ribs[node, 1];
                this.ribs[node, 1] = buffer;
            }

            this.Visit(this.ribs[node, 0], k, (height + 1) % k, result);
            result.Add(node + 1);
            this.Visit(this.ribs[node, 1], k, (height + 1) % k, result);
        }
    }
}
