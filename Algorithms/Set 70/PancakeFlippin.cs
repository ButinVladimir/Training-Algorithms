using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_70
{
    public static class PancakeFlippin
    {
        public static int Solve(string s, int k)
        {
            bool flip = false;
            int result = 0;
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < s.Length - k + 1; i++)
            {
                if (queue.Count > 0 && queue.Peek() == i)
                {
                    flip = !flip;
                    queue.Dequeue();
                }

                if (!flip && s[i] == '-' || flip && s[i] == '+')
                {
                    result++;
                    flip = !flip;
                    queue.Enqueue(i + k);
                }
            }

            for (int i = s.Length - k + 1; i < s.Length; i++)
            {
                if (queue.Count > 0 && queue.Peek() == i)
                {
                    flip = !flip;
                    queue.Dequeue();
                }

                if (!flip && s[i] == '-' || flip && s[i] == '+')
                {
                    return -1;
                }
            }

            return result;
        }
    }
}
