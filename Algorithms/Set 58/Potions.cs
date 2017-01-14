using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_58
{
    class Potions
    {
        public long N { get; set; } // We need to brew N potions
        public int M { get; set; } // Amount of spells of first type
        public int K { get; set; } // Amount of spells of second type
        public long X { get; set; } // Initial brewing speed
        public long S { get; set; } // Mana points

        public long[] A { get; set; } // New brewing speed after first type spell was casted
        public long[] B { get; set; } // Cost of spell of first type

        public long[] C { get; set; } // Amount of potions which will be immediately created
        public long[] D { get; set; } // Cost of spell of second type

        public long Solve()
        {
            long result = Math.Max(0, N - this.FindMaxPotions(S)) * X;

            for (int i = 0; i < M; i++)
            {
                if (S >= B[i])
                {
                    result = Math.Min(result, Math.Max(0, N - this.FindMaxPotions(S - B[i])) * A[i]);
                }
            }

            return result;
        }

        private long FindMaxPotions(long points)
        {
            long result = 0;
            long current = -1;
            long step = K;
            long next;

            while (step > 0)
            {
                next = current + step;

                if (next >= 0 && next < K && C[next] >= result && D[next] <= points)
                {
                    result = C[next];
                    current = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return result;
        }
    }
}
