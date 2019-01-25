using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public class SubstringDiff
    {
        private const int K = 12;
        private const int N = 1500;
        private string s1;
        private string s2;
        private static int[,,] dp = new int[K, N, N];
        private int k;

        public SubstringDiff(int k, string s1, string s2)
        {
            this.s1 = s1;
            this.s2 = s2;
            this.k = k;

            for (int q = 0; q < K; q++)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    for (int j = 0; j < s2.Length; j++)
                    {
                        dp[q, i, j] = 0;
                    }
                }
            }
        }

        public int Solve()
        {
            this.ComputePerfect();
            this.ComputeFirst();
            for (int i = 2; i < K; i++)
            {
                this.ComputeNext(i);
            }

            return this.CalculateResult();
        }

        private void ComputePerfect()
        {
            for (int i = 0; i < this.s1.Length; i++)
            {
                for (int j = 0; j < this.s2.Length; j++)
                {
                    if (this.s1[i] == this.s2[j])
                    {
                        dp[0, i, j] = 1;
                        if (i > 0 && j > 0)
                        {
                            dp[0, i, j] += dp[0, i - 1, j - 1];
                        }
                    }
                }
            }
        }

        private void ComputeFirst()
        {
            int l;
            for (int i = 0; i < this.s1.Length; i++)
            {
                for (int j = 0; j < this.s2.Length; j++)
                {
                    if (this.s1[i] == this.s2[j])
                    {
                        l = dp[0, i, j];

                        dp[1, i, j] = l;
                        if (i - l >= 0 && j - l >= 0)
                        {
                            dp[1, i, j] += 1;
                        }
                    }
                    else
                    {
                        dp[1, i, j] = 1;
                        if (i > 0 && j > 0)
                        {
                            dp[1, i, j] += dp[0, i - 1, j - 1];
                        }
                    }
                }
            }
        }

        private void ComputeNext(int k)
        {
            int l;
            for (int i = 0; i < this.s1.Length; i++)
            {
                for (int j = 0; j < this.s2.Length; j++)
                {
                    l = dp[k - 1, i, j];
                    dp[k, i, j] = l;
                    if (i - l >= 0 && j - l >= 0)
                    {
                        dp[k, i, j] += dp[k - 1, i - l, j - l];
                    }
                }
            }
        }

        private int CalculateResult()
        {
            int result = 0;
            int kleft;
            int kb;
            int buffer;

            for (int i = 0; i < this.s1.Length; i++)
            {
                for (int j = 0; j < this.s2.Length; j++)
                {
                    kleft = this.k;
                    buffer = 0;
                    for (int q = K - 1; q > 0 && i - buffer >= 0 && j - buffer >= 0; q--)
                    {
                        kb = (1 << (q - 1));
                        if (kleft >= kb)
                        {
                            kleft -= kb;
                            buffer += dp[q, i - buffer, j - buffer];
                        }
                    }

                    if (i - buffer >= 0 && j - buffer >= 0)
                    {
                        buffer += dp[0, i - buffer, j - buffer];
                    }

                    result = Math.Max(result, buffer);
                }
            }

            return result;
        }
    }
}
