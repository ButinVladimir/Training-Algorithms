using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_6
{
    public class PowerSum
    {
        private Dictionary<Tuple<long, long>, long> intermediateResult;

        private long n;

        public long Solve(long x, int n)
        {
            intermediateResult = new Dictionary<Tuple<long, long>, long>();
            this.n = n;

            return this.SolveInternal(x, 1);
        }

        private long SolveInternal(long left, long number)
        {
            var key = new Tuple<long, long>(left, number);
            if (this.intermediateResult.ContainsKey(key))
            {
                return this.intermediateResult[key];
            }

            long poweredNumber = Power(number, this.n);
            if (poweredNumber > left)
            {
                return 0;
            }

            if (poweredNumber == left)
            {
                return 1;
            }

            long value = this.SolveInternal(left, number + 1) + this.SolveInternal(left - poweredNumber, number + 1);
            this.intermediateResult[key] = value;

            return value;
        }

        private static long Power(long value, long power)
        {
            long result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= value;
            }

            return result;
        }
    }
}
