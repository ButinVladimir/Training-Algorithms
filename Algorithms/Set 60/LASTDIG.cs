using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_60
{
    class LASTDIG
    {
        const UInt64 mod = 10;

        public UInt64 Solve(UInt64 a, UInt64 b)
        {
            if (b ==0 )
            {
                return 1;
            }

            if (b == 1)
            {
                return a % mod;
            }

            UInt64 c = Solve(a, b / 2);
            c = (c * c) % mod;
            if (b % 2== 1)
            {
                c = (c * a) % mod;
            }

            return c;
        }
    }
}
