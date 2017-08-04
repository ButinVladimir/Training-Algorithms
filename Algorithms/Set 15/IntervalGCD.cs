using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_15
{
    public class IntervalGCD
    {
        private int blocksN;
        private int blocksLength;
        private int[] a;
        private int[] blocks;

        public IntervalGCD(int[] a)
        {
            this.a = a;
            this.blocksLength = Sqrt(this.a.Length);
            this.blocksN = this.a.Length / blocksLength;

            if (this.a.Length % this.blocksLength > 0)
            {
                this.blocksN++;
            }

            this.blocks = new int[this.blocksN];

            int left, right;

            for (int block = 0; block < this.blocksN; block++)
            {
                left = block * this.blocksLength;
                right = Math.Min(a.Length - 1, left + this.blocksLength - 1);

                this.blocks[block] = this.a[left];
                for (int i = left; i <= right; i++)
                {
                    this.blocks[block] = Gcd(this.blocks[block], this.a[i]);
                }
            }
        }

        public int Query(int l, int r)
        {
            int left, right;
            int result = 0;

            for (int block = 0; block < this.blocksN; block++)
            {
                left = block * this.blocksLength;
                right = Math.Min(a.Length - 1, left + this.blocksLength - 1);

                if (l <= left && r >= right)
                {
                    result = Gcd(result, this.blocks[block]);
                }
                else
                {
                    left = Math.Max(left, l);
                    right = Math.Min(right, r);

                    for (int i = left; i <= right; i++)
                    {
                        result = Gcd(result, this.a[i]);
                    }
                }
            }

            return result;
        }

        private static int Sqrt(int a)
        {
            int r = 0;
            while (r * r <= a)
            {
                r++;
            }

            return r - 1;
        }

        private static int Gcd(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return a + b;
        }
    }
}
