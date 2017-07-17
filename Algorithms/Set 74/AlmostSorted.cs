using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_74
{
    public static class AlmostSorted
    {
        public static String Solve(int[] array)
        {
            int n = array.Length;

            int[] sortedArray = new int[n];
            array.CopyTo(sortedArray, 0);

            Array.Sort(sortedArray);

            int wrongPlaces = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] != sortedArray[i])
                {
                    wrongPlaces++;
                }
            }

            if (wrongPlaces == 0)
            {
                return "yes";
            }

            StringBuilder sb = new StringBuilder();

            if (wrongPlaces == 2)
            {
                sb.AppendLine("yes");

                sb.Append("swap");
                for (int i = 0; i < n; i++)
                {
                    if (array[i] != sortedArray[i])
                    {
                        sb.Append(' ');
                        sb.Append(i + 1);
                    }
                }

                return sb.ToString();
            }

            int left = 0;
            int right = n - 1;

            while (left < n && array[left] == sortedArray[left])
            {
                left++;
            }

            while (right >= 0 && array[right] == sortedArray[right])
            {
                right--;
            }

            int k = right - left;
            for (int i = 0; i <= k; i++)
            {
                if (array[right - i] != sortedArray[left + i])
                {
                    return "no";
                }
            }

            sb.AppendLine("yes");

            sb.Append("reverse ");
            sb.Append(left + 1);
            sb.Append(' ');
            sb.Append(right + 1);

            return sb.ToString();
        }
    }
}
