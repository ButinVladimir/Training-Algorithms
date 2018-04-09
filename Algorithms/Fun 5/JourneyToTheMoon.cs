using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public class JourneyToTheMoon
    {
        private long n;

        private int[] component;

        private long[] size;

        public JourneyToTheMoon(long n)
        {
            this.n = n;
            this.component = new int[this.n];
            this.size = new long[this.n];

            for (int i = 0; i < this.n; i++)
            {
                this.component[i] = i;
                this.size[i] = 1;
            }
        }

        public void AddPair(int a, int b)
        {
            a = this.GetComponent(a);
            b = this.GetComponent(b);

            if (a == b)
            {
                return;
            }

            if (this.size[a] > this.size[b])
            {
                MergeComponents(a, b);
            }
            else
            {
                MergeComponents(b, a);
            }
        }

        public long Solve()
        {
            long result = 0;

            for (int i = 0; i < this.n; i++)
            {
                int a = this.GetComponent(i);

                result += this.n - this.size[a];
            }

            return result / 2;
        }

        private int GetComponent(int pos)
        {
            if (this.component[pos] != pos)
            {
                this.component[pos] = GetComponent(this.component[pos]);
            }

            return this.component[pos];
        }

        private void MergeComponents(int a, int b)
        {
            this.component[b] = a;
            this.size[a] += this.size[b];
        }
    }
}
