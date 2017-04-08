using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_70
{
    public static class TidyNumbers
    {
        public static long Solve(long input)
        {
            List<long> converted = new List<long>();
            long buffer = input;
            while (buffer > 0)
            {
                converted.Add(buffer % 10);
                buffer /= 10;
            }

            long[] convertedArray = converted.ToArray();
            int l = convertedArray.Length;

            bool isFine = true;
            for (int i = 0; i < l - 1; i++)
            {
                if (convertedArray[i] < convertedArray[i + 1])
                {
                    isFine = false;
                }
            }

            if (isFine)
            {
                return input;
            }

            long[] testArray = new long[l];

            for (int i = 0; i < l; i++)
            {
                if (convertedArray[i] > 0)
                {
                    testArray[i] = convertedArray[i] - 1;
                    for (int j = 0; j < i; j++)
                    {
                        testArray[j] = 9;
                    }

                    for (int j = i + 1; j < l; j++)
                    {
                        testArray[j] = convertedArray[j];
                    }

                    isFine = true;
                    for (int j = 0; j < l - 1; j++)
                    {
                        if (testArray[j] < testArray[j + 1])
                        {
                            isFine = false;
                        }
                    }

                    if (isFine)
                    {
                        long result = 0;
                        for (int j = l-1; j >= 0; j--)
                        {
                            result = result * 10 + testArray[j];
                        }

                        return result;
                    }
                }
            }

            return 0;
        }
    }
}
