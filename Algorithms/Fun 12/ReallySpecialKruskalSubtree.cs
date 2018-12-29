using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public class ReallySpecialKruskalSubtree
    {
        private int n;
        private Rib[] ribs;

        public ReallySpecialKruskalSubtree(int n, int m)
        {
            this.n = n;
            this.ribs = new Rib[m];
        }

        public void AddRib(int from, int to, int len, int num)
        {
            this.ribs[num] = new Rib(from - 1, to - 1, len, num);
        }

        public long Solve()
        {
            Array.Sort(this.ribs);
            int result = 0;

            Dsu dsu = new Dsu(this.n);
            foreach (Rib rib in this.ribs)
            {
                if (dsu.Merge(rib.From, rib.To))
                {
                    result += rib.Len;
                }
            }

            return result;
        }

        private class Dsu
        {
            private int[] ancestor;
            private int[] rank;

            public Dsu(int n)
            {
                this.ancestor = new int[n];
                this.rank = new int[n];

                for (int i = 0; i < n; i++)
                {
                    this.ancestor[i] = i;
                    this.rank[i] = 1;
                }
            }

            public bool Merge(int a, int b)
            {
                a = this.GetAncestor(a);
                b = this.GetAncestor(b);

                if (a == b)
                {
                    return false;
                }

                if (this.rank[b] > this.rank[a])
                {
                    int buffer = a;
                    a = b;
                    b = buffer;
                }

                this.ancestor[b] = a;
                this.rank[a] += this.rank[b];

                return true;
            }

            private int GetAncestor(int pos)
            {
                if (this.ancestor[pos] != pos)
                {
                    this.ancestor[pos] = GetAncestor(this.ancestor[pos]);
                }

                return this.ancestor[pos];
            }
        }

        private class Rib : IComparable<Rib>
        {
            public int From { get; private set; }
            public int To { get; private set; }
            public int Len { get; private set; }
            public int Sum { get; private set; }
            public int Num { get; private set; }

            public Rib(int from, int to, int len, int num)
            {
                this.From = from;
                this.To = to;
                this.Len = len;
                this.Sum = this.From + this.To + this.Len;
                this.Num = num;
            }

            public int CompareTo(Rib other)
            {
                if (this.Len != other.Len)
                {
                    return this.Len.CompareTo(other.Len);
                }

                if (this.Sum != other.Sum)
                {
                    return this.Sum.CompareTo(other.Sum);
                }

                return this.Num.CompareTo(other.Num);
            }
        }
    }
}

