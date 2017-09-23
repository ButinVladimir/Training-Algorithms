using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class PickingNumbers
    {
        public static int Solve(int[] a)
        {
            Array.Sort(a);
            int currentNumber = a[0];
            int currentCount = 0;
            int pos = 0;

            while (pos < a.Length && currentNumber == a[pos])
            {
                currentCount++;
                pos++;
            }

            if (pos == a.Length)
            {
                return currentCount;
            }

            int result = currentCount;

            int nextCount;
            int nextNumber;
            int nextPos = pos;

            while (pos < a.Length)
            {
                nextNumber = a[pos];
                nextCount = 0;

                while(nextPos < a.Length && nextNumber == a[nextPos])
                {
                    nextPos++;
                    nextCount++;
                }

                result = Math.Max(result, nextCount);
                if (Math.Abs(nextNumber - currentNumber) <= 1)
                {
                    result = Math.Max(result, nextCount + currentCount);
                }

                pos = nextPos;
                currentNumber = nextNumber;
                currentCount = nextCount;
            }

            return result;
        }
    }
}
