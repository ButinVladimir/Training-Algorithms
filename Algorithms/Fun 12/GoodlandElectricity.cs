using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public static class GoodlandElectricity
    {
        public static int Solve(int[] a, int k)
        {
            int result = 0;

            int suitablePlanPos = -1;
            int plantPos = 0;
            int cityPos = 0;

            while (plantPos < a.Length && cityPos < a.Length)
            {
                if (plantPos - k >= cityPos)
                {
                    if (suitablePlanPos == -1)
                    {
                        return -1;
                    }

                    result++;
                    cityPos = suitablePlanPos + k;
                    suitablePlanPos = -1;
                }

                if (a[plantPos] == 1)
                {
                    suitablePlanPos = plantPos;                    
                }

                plantPos++;
            }

            if (cityPos < a.Length)
            {
                if (suitablePlanPos == -1)
                {
                    return -1;
                }

                result++;
            }

            return result;
        }
    }
}
