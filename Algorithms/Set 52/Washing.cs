using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_52
{
    class Washing
    {
        public int N { get; set; }
        
        public int K { get; set; }
        
        public long[] P { get; set; }

        public long[] D { get; set; }

        public long Solve()
        {
            long[] a = new long[this.N];
            long result = 0;

            for (int i = 0; i < this.N; i++)
            {
                a[i] = this.P[i] + this.D[i];
                result -= this.D[i];
            }

            Array.Sort(a);

            for (int i = this.N - 1; i >= 0 && i >= this.N - this.K; i--)
            {
                result += a[i];
            }

            return result < 0 ? 0 : result;
        }
    }
}
