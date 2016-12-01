using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_60
{
    class COINS
    {
        private Dictionary<UInt64, UInt64> calculatedValues;

        public COINS()
        {
            calculatedValues = new Dictionary<ulong, ulong>();
        }

        public UInt64 Solve(UInt64 value)
        {
            if (value == 0)
            {
                return 0;
            }
            if (value == 1)
            {
                return 1;
            }
            if (calculatedValues.ContainsKey(value))
            {
                return calculatedValues[value];
            }

            UInt64 result = Math.Max(value, Solve(value / 2) + Solve(value / 3) + Solve(value / 4));
            calculatedValues[value] = result;

            return result;
        }
    }
}
