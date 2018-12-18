using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public class MaximumPalindromes
    {
        private const int MC = 26;
        private const long mod = 1000000000 + 7;
        private static long[] factorials;
        private static long[] reverses;

        private string s;
        private long[,] charCount;
        private long[] currentCharCount;
        private long maxLen;
        private long middleCnt;

        static MaximumPalindromes()
        {
            const int N = 100001;
            factorials = new long[N];
            reverses = new long[N];

            factorials[0] = 1;
            for (int i = 1; i < N; i++)
            {
                factorials[i] = (factorials[i - 1] * i) % mod;
            }

            for (int i = 0; i < N; i++)
            {
                reverses[i] = Reverse(factorials[i]);
            }
        }

        public MaximumPalindromes(string s)
        {
            this.s = s;
            this.charCount = new long[MC, this.s.Length + 1];
            this.currentCharCount = new long[MC];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < MC; j++)
                {
                    this.charCount[j, i + 1] = this.charCount[j, i];
                }
                this.charCount[s[i] - 'a', i + 1]++;
            }
        }

        public long Query(int l, int r)
        {
            this.maxLen = 0;
            this.middleCnt = 0;
            long result = 1;

            for (int i = 0; i < MC; i++)
            {
                this.currentCharCount[i] = this.charCount[i, r] - this.charCount[i, l - 1];
                if (this.currentCharCount[i] % 2 == 1)
                {
                    this.middleCnt++;
                }
                this.currentCharCount[i] /= 2;
                this.maxLen += this.currentCharCount[i];
            }

            if (this.middleCnt > 0)
            {
                result *= this.middleCnt;
            }
           
            for (int i = 0; i < MC; i++)
            {
                result = (result * factorials[this.maxLen]) % mod;
                result = (result * reverses[this.currentCharCount[i]]) % mod;
                result = (result * reverses[this.maxLen - this.currentCharCount[i]]) % mod;

                this.maxLen -= this.currentCharCount[i];
            }

            return result;
        }

        private static long Reverse(long a)
        {
            long x, y;
            Gcd(a, mod, out x, out y);

            return x;
        }

        private static void Gcd(long a, long b, out long x, out long y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;

                return;
            }

            long x0, y0;
            Gcd(b % a, a, out x0, out y0);
            y = x0;
            x = (mod + y0 - ((b / a) * x0) % mod) % mod;
        }
    }
}
