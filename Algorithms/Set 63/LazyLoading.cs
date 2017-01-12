namespace Algorithms.Set_63
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Remoting.Messaging;

    public class LazyLoading
    {
        public static int Solve(int[] items)
        {
            int n = items.Length;
            int[] sortedItems = new int[n];
            items.CopyTo(sortedItems, 0);
            Array.Sort(sortedItems);

            int result = 0;
            int left = 0;
            int right = n - 1;
            while (right >= 0 && sortedItems[right] >= 50)
            {
                result++;
                right--;
            }

            int mx, cnt;
            while (left < right)
            {
                mx = sortedItems[right];
                cnt = 1;
                while (cnt * mx < 50 && left < right)
                {
                    left++;
                    cnt++;
                }

                if (cnt * mx >= 50)
                {
                    result++;
                }

                right--;
            }

            return result;
        }

        public static int StressSolve(int[] items)
        {
            int n = items.Length;
            bool[] used = new bool[n];

            int maxResult = 0;
            StressTick(0, n, items, used, ref maxResult);

            return maxResult;
        }

        private static void StressTick(int position, int left, int[] items, bool[] used, ref int maxResult, int currentMax = 0, int currentLength = 0, int currentResult = 0)
        {
            if (currentResult > maxResult)
            {
                maxResult = currentResult;
            }

            if (position == 0 && left == 0)
            {
                return;
            }

            if (position == items.Length)
            {
                if (currentMax * currentLength >= 50)
                {
                    StressTick(0, left, items, used, ref maxResult, 0, 0, currentResult + 1);
                }
                return;
            }

            StressTick(position + 1, left, items, used, ref maxResult, currentMax, currentLength, currentResult);
            if (!used[position])
            {
                used[position] = true;
                StressTick(position + 1, left - 1, items, used, ref maxResult, Math.Max(currentMax, items[position]), currentLength + 1, currentResult);
                used[position] = false;
            }
        }
    }
}