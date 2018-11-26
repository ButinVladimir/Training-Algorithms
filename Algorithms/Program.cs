using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_11;

public class Solution
{
    private class Tokenizer
    {
        private string currentString = null;

        private string[] tokens = null;

        private int tokenNumber = 0;

        private static readonly char[] Separators = { ' ' };

        public T NextToken<T>(Func<string, T> parser)
        {
            return parser(this.GetNextToken());
        }

        public string NextToken()
        {
            return this.GetNextToken();
        }

        public int NextInt()
        {
            return this.NextToken(int.Parse);
        }

        public long NextLong()
        {
            return this.NextToken(long.Parse);
        }

        public ulong NextULong()
        {
            return this.NextToken(ulong.Parse);
        }

        public double NextDouble()
        {
            return this.NextToken(double.Parse);
        }

        public decimal NextDecimal()
        {
            return this.NextToken(decimal.Parse);
        }

        public char NextChar()
        {
            return this.NextToken(char.Parse);
        }

        private string GetNextToken()
        {
            if (this.currentString == null || this.tokenNumber == this.tokens.Length)
            {
                this.currentString = this.GetNextString();

                while (this.currentString != null && this.currentString.Equals(string.Empty))
                {
                    this.currentString = this.GetNextString();
                }

                if (this.currentString == null)
                {
                    throw new Exception("End of input");
                }

                this.tokens = this.currentString.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                this.tokenNumber = 0;
            }

            return this.tokens[this.tokenNumber++];
        }

        private string GetNextString()
        {
            string content = Console.ReadLine();
            if (content == null)
            {
                return null;
            }

            return content.Trim();
        }
    }

    public static void Main()
    {
        //using (StreamReader reader = new StreamReader(File.OpenRead("input.txt")))
        //{
        //    Console.SetIn(reader);

        //    using (StreamWriter writer = File.CreateText("output.txt"))
        //    {
        //        Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();
        int tests = tokenizer.NextInt();
        for (; tests > 0; tests--)
        {
            int n = tokenizer.NextInt();
            int m = tokenizer.NextInt();
            int x1, y1, z1, x2, y2, z2;
            long w;
            CubeSummation cs = new CubeSummation(n);

            for (int i = 0; i < m; i++)
            {
                if (tokenizer.NextToken().Equals("UPDATE", StringComparison.OrdinalIgnoreCase))
                {
                    x1 = tokenizer.NextInt();
                    y1 = tokenizer.NextInt();
                    z1 = tokenizer.NextInt();
                    w = tokenizer.NextLong();
                    cs.Update(x1, y1, z1, w);
                }
                else
                {
                    x1 = tokenizer.NextInt();
                    y1 = tokenizer.NextInt();
                    z1 = tokenizer.NextInt();
                    x2 = tokenizer.NextInt();
                    y2 = tokenizer.NextInt();
                    z2 = tokenizer.NextInt();
                    Console.WriteLine(cs.Query(x1, y1, z1, x2, y2, z2));
                }
            }
        }
        //    }
        //}
    }

    public class CubeSummation
    {
        private int n;

        private long[,,] values;
        private FenvickTree fenvickTree;

        public CubeSummation(int n)
        {
            this.n = n;
            this.fenvickTree = new FenvickTree(this.n);
            this.values = new long[n + 1, n + 1, n + 1];
        }

        public void Update(int x, int y, int z, long w)
        {
            this.fenvickTree.Update(x, y, z, w - this.values[x, y, z]);
            this.values[x, y, z] = w;
        }

        public long Query(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            return this.fenvickTree.Query(x2, y2, z2)
                    - this.fenvickTree.Query(x1 - 1, y2, z2)
                    - this.fenvickTree.Query(x2, y1 - 1, z2)
                    - this.fenvickTree.Query(x2, y2, z1 - 1)
                    + this.fenvickTree.Query(x1 - 1, y1 - 1, z2)
                    + this.fenvickTree.Query(x1 - 1, y2, z1 - 1)
                    + this.fenvickTree.Query(x2, y1 - 1, z1 - 1)
                    - this.fenvickTree.Query(x1 - 1, y1 - 1, z1 - 1);
        }

        private class FenvickTree
        {
            private int n;
            private long[,,] tree;

            public FenvickTree(int n)
            {
                this.n = n + 1;
                this.tree = new long[this.n, this.n, this.n];
            }

            public void Update(int x, int y, int z, long w)
            {
                for (int i = x; i < this.n; i = (i | (i + 1)))
                {
                    for (int j = y; j < this.n; j = (j | (j + 1)))
                    {
                        for (int k = z; k < this.n; k = (k | (k + 1)))
                        {
                            tree[i, j, k] += w;
                        }
                    }
                }
            }

            public long Query(int x, int y, int z)
            {
                long result = 0;

                for (int i = x; i >= 0; i = (i & (i + 1)) - 1)
                {
                    for (int j = y; j >= 0; j = (j & (j + 1)) - 1)
                    {
                        for (int k = z; k >= 0; k = (k & (k + 1)) - 1)
                        {
                            result += tree[i, j, k];
                        }
                    }
                }

                return result;
            }
        }
    }
}
