using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_62
{
    class Pigbank
    {
        public static ulong? Solve(int weight, int n, int[] coinsWeight, ulong[] coinsValue)
        {
            ulong[] result = new ulong[weight + 1];

            for (int i = 1; i <= weight; i++)
            {
                result[i] = ulong.MaxValue;
            }
            result[0] = 0;

            int nextWeight;
            ulong nextValue;

            for (int currentWeight = 0; currentWeight < weight; currentWeight++)
            {
                if (result[currentWeight] == ulong.MaxValue)
                {
                    continue;
                }

                for (int i = 0; i < n; i++)
                {
                    nextWeight = currentWeight + coinsWeight[i];
                    nextValue = result[currentWeight] + coinsValue[i];

                    if (nextWeight > weight || result[nextWeight] < nextValue)
                    {
                        continue;
                    }

                    result[nextWeight] = nextValue;
                }
            }

            if (result[weight] == ulong.MaxValue)
            {
                return null;
            }
            else
            {
                return result[weight];
            }
        }
    }
}
