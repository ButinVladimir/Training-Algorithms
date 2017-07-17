using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_74
{
    public class XoringNinja
    {
        private const int N = 100001;
        private const long Mod = 1000000000 + 7;

        private long[] pwr2;

        public XoringNinja()
        {
            this.pwr2 = new long[N];
            this.pwr2[0] = 1;

            for (int i = 1; i < N; i++)
            {
                this.pwr2[i] = (this.pwr2[i - 1] * 2) % Mod;
            }
        }

        public long Solve(int[] array)
        {
            long result = 0;

            for (int bit = 0; bit < 32; bit++)
            {
                long mask = 1 << bit;
                int count = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if ((array[i] & mask) > 0)
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    result = (result + mask * (this.pwr2[count - 1] * this.pwr2[array.Length - count] % Mod) % Mod) % Mod;
                }
            }

            return result;
        }
    }
}
