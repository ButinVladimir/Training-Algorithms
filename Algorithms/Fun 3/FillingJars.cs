using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public class FillingJars
    {
        public long N { get; set; }

        private long sum = 0;

        public void Add(long from, long to, long amount)
        {
            this.sum += (to - from + 1) * amount;
        }

        public long Get()
        {
            return this.sum / this.N;
        }
    }
}
