using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public class GridSearch
    {
        public const long P1 = 11;
        public const long P2 = 13;

        public const long mod = 1000000000 + 9;

        public string[] Haystack { get; set; }
        public string[] Needle { get; set; }

        private long[,] hash1;
        private long[,] hash2;
        private long v1;
        private long v2;

        public bool Solve()
        {
            this.BuildHash();
            this.FindValues();

            return this.Scan();
        }

        private void BuildHash()
        {
            int haystackRows = this.Haystack.Length;
            int haystackCols = this.Haystack[0].Length;

            this.hash1 = new long[haystackRows, haystackCols];
            this.hash2 = new long[haystackRows, haystackCols];
            long m1 = 1;
            long m2 = 1;

            for (int i = 0; i < haystackRows; i++)
            {
                for (int j = 0; j < haystackCols; j++)
                {
                    this.hash1[i, j] = (this.Haystack[i][j] - '0') * m1 % mod;
                    this.hash2[i, j] = (this.Haystack[i][j] - '0') * m2 % mod;

                    if (i > 0)
                    {
                        this.hash1[i, j] = (this.hash1[i, j] + this.hash1[i - 1, j]) % mod;
                        this.hash2[i, j] = (this.hash2[i, j] + this.hash2[i - 1, j]) % mod;
                    }

                    if (j > 0)
                    {
                        this.hash1[i, j] = (this.hash1[i, j] + this.hash1[i, j - 1]) % mod;
                        this.hash2[i, j] = (this.hash2[i, j] + this.hash2[i, j - 1]) % mod;
                    }

                    if (i > 0 && j > 0)
                    {
                        this.hash1[i, j] = (this.hash1[i, j] - this.hash1[i - 1, j - 1] + mod) % mod;
                        this.hash2[i, j] = (this.hash2[i, j] - this.hash2[i - 1, j - 1] + mod) % mod;
                    }

                    m1 = m1 * P1 % mod;
                    m2 = m2 * P2 % mod;
                }
            }
        }

        private void FindValues()
        {
            this.v1 = 0;
            this.v2 = 0;
            long m1 = 1;
            long m2 = 1;
            long hl = this.Haystack[0].Length;

            for (int i = 0; i < this.Needle.Length; i++)
            {
                for (int j = 0; j < this.Needle[i].Length; j++)
                {
                    this.v1 = (this.v1 + (this.Needle[i][j] - '0') * Power(m1, i * hl + j) % mod) % mod;
                    this.v2 = (this.v2 + (this.Needle[i][j] - '0') * Power(m2, i * hl + j) % mod) % mod;
                }
            }
        }

        private bool Scan()
        {
            int haystackRows = this.Haystack.Length;
            int haystackCols = this.Haystack[0].Length;
            int needleRows = this.Needle.Length;
            int needleCols = this.Needle[0].Length;

            for (int i = needleRows - 1; i < haystackRows; i++)
            {
                for (int j = needleCols - 1; j < haystackCols; j++)
                {
                    long b1 = this.hash1[i, j];
                    long b2 = this.hash2[i, j];

                    if (i >= needleRows)
                    {
                        b1 = (b1 - this.hash1[i - needleRows, j] + mod) % mod;
                        b2 = (b2 - this.hash2[i - needleRows, j] + mod) % mod;
                    }

                    if (j >= needleCols)
                    {
                        b1 = (b1 - this.hash1[i, j - needleCols] + mod) % mod;
                        b2 = (b2 - this.hash2[i, j - needleCols] + mod) % mod;
                    }

                    if (i >= needleRows && j >= needleCols)
                    {
                        b1 = (b1 + this.hash1[i - needleRows, j - needleRows]) % mod;
                        b2 = (b2 + this.hash2[i - needleRows, j - needleRows]) % mod;
                    }

                    b1 = b1 * Power(P1, (i - needleRows + 1) * haystackCols + j - needleCols + 1) % mod;
                    b2 = b2 * Power(P2, (i - needleRows + 1) * haystackCols + j - needleCols + 1) % mod;

                    if (b1 == this.v1 && b2 == this.v2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static long Power(long b, long p)
        {
            if (p == 0)
            {
                return 1;
            }

            long v = Power(b, p / 2);
            v = (v * v) % mod;

            if (p % 2 == 1)
            {
                v = (v * b) % mod;
            }

            return v;
        }
    }
}
