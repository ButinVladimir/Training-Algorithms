using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_40
{
    class Toys
    {
        private const long Max = 1000000000;

        public int N { get; set; }
        
        public long M { get; set; }
        
        public long[] A { get; set; }

        public List<long> Solve()
        {
            Array.Sort(this.A);

            List<long> result = new List<long>();
            long current = 1;
            int position = 0;

            while (current <= Max && current <= this.M)
            {
                if (position < this.N)
                {
                    if (this.A[position] > current)
                    {
                        this.M -= current;
                        result.Add(current);
                        current++;                        
                    }
                    else if (this.A[position] < current)
                    {
                        position++;
                    }
                    else
                    {
                        position++;
                        current++;
                    }
                }
                else
                {
                    this.M -= current;
                    result.Add(current);
                    current++;
                }
            }

            return result;
        }
    }
}
