using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public class CircularArrayRotation
    {
        private int[] a;

        public CircularArrayRotation(int[] a, int k)
        {
            this.a = new int[a.Length];

            k = k % a.Length;
            for (int i =0;i<a.Length;i++)
            {
                this.a[(i + k) % a.Length] = a[i];
            }
        }

        public int AtIndex(int position)
        {
            return a[position];
        }
    }
}
