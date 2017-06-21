using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_3
{
    public static class LuckBalance
    {
        public static int Solve(int n, int k, int[] l, int[] t)
        {
            int result = 0;

            List<int> mandatoryList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (t[i] == 0)
                {
                    result += l[i];
                }
                else
                {
                    mandatoryList.Add(l[i]);
                }
            }

            int[] mandatoryArray = mandatoryList.ToArray();
            Array.Sort(mandatoryArray);
            for (int i = mandatoryArray.Length - 1; i >= 0; i--)
            {
                if (k > 0)
                {
                    result += mandatoryArray[i];
                    k--;
                }
                else
                {
                    result -= mandatoryArray[i];
                }
            }

            return result;
        }
    }
}
