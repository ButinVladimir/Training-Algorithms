using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algorithms.Fun_11
{
    public class CubeSummation
    {
        private int n;

        private long[,,] values;
        private FenvickTree fenvickTree;

        public CubeSummation(int n)
        {
            this.n = n;
            this.fenvickTree = new FenvickTree(this.n);
            this.values = new long[n + 1, n + 1, n + 1];
        }

        public void Update(int x, int y, int z, long w)
        {
            this.fenvickTree.Update(x, y, z, w - this.values[x, y, z]);
            this.values[x, y, z] = w;
        }

        public long Query(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            return this.fenvickTree.Query(x2, y2, z2)
                    - this.fenvickTree.Query(x1 - 1, y2, z2)
                    - this.fenvickTree.Query(x2, y1 - 1, z2)
                    - this.fenvickTree.Query(x2, y2, z1 - 1)
                    + this.fenvickTree.Query(x1 - 1, y1 - 1, z2)
                    + this.fenvickTree.Query(x1 - 1, y2, z1 - 1)
                    + this.fenvickTree.Query(x2, y1 - 1, z1 - 1)
                    - this.fenvickTree.Query(x1 - 1, y1 - 1, z1 - 1);
        }

        private class FenvickTree
        {
            private int n;
            private long[,,] tree;

            public FenvickTree(int n)
            {
                this.n = n + 1;
                this.tree = new long[this.n, this.n, this.n];
            }

            public void Update(int x, int y, int z, long w)
            {
                for (int i = x; i < this.n; i = (i | (i + 1)))
                {
                    for (int j = y; j < this.n; j = (j | (j + 1)))
                    {
                        for (int k = z; k < this.n; k = (k | (k + 1)))
                        {
                            tree[i, j, k] += w;
                        }
                    }
                }
            }

            public long Query(int x, int y, int z)
            {
                long result = 0;

                for (int i = x; i >= 0; i = (i & (i + 1)) - 1)
                {
                    for (int j = y; j >= 0; j = (j & (j + 1)) - 1)
                    {
                        for (int k = z; k >= 0; k = (k & (k + 1)) - 1)
                        {
                            result += tree[i, j, k];
                        }
                    }
                }

                return result;
            }
        }
    }
}
