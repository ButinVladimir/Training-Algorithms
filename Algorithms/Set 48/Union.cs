using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_48
{
    class Union
    {
        public static string[] Solve(string[] arrayA, string[] arrayB)
        {
            int n = arrayA.Length;
            int m = arrayB.Length;

            string[] sortedArrayA = new string[n];
            arrayA.CopyTo(sortedArrayA, 0);
            Array.Sort(sortedArrayA);

            string[] sortedArrayB = new string[m];
            arrayB.CopyTo(sortedArrayB, 0);
            Array.Sort(sortedArrayB);

            List<string> resultA = new List<string>();
            List<string> resultB = new List<string>();

            int indexA = 0;
            int indexB = 0;
            while (indexA < n && indexB < m)
            {
                if (sortedArrayA[indexA].CompareTo(sortedArrayB[indexB]) == -1)
                {
                    resultA.Add(sortedArrayA[indexA]);
                    indexA++;
                } else
                if (sortedArrayA[indexA].CompareTo(sortedArrayB[indexB]) == 1)
                {
                    resultB.Add(sortedArrayB[indexB]);
                    indexB++;
                } else
                {
                    indexA++;
                    indexB++;
                }
            }

            while (indexA < n)
            {
                resultA.Add(sortedArrayA[indexA]);
                indexA++;
            }

            while (indexB < m)
            {
                resultB.Add(sortedArrayB[indexB]);
                indexB++;
            }

            resultA.AddRange(resultB);
            return resultA.ToArray();
        }
    }
}
