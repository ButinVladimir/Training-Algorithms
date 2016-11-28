using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class Pond2
    {
        static public int Find(int[] a)
        {
            if (a.Length == 0)
            {
                return 0;
            }
            int result = 0, maxHeight = a[0], maxPos = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= maxHeight)
                {
                    maxHeight = a[i];
                    maxPos = i;
                }
            }

            int currentHeight = a[0];
            for (int i = 0; i < maxPos; i++)
            {
                if (a[i] < currentHeight)
                {
                    result += currentHeight - a[i];
                }
                else
                {
                    currentHeight = a[i];
                }
            }

            currentHeight = a[a.Length - 1];
            for (int i = a.Length - 1; i > maxPos; i--)
            {
                if (a[i] < currentHeight)
                {
                    result += currentHeight - a[i];
                }
                else
                {
                    currentHeight = a[i];
                }
            }

            return result;
        }
    }
}
