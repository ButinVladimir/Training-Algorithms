using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_10;

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
        //  Console.SetIn(reader);

        //StreamWriter writer = File.CreateText("output.txt");
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        int tests = tokenizer.NextInt();
        long[] a = new long[100000];

        for (int test = 0; test < tests; test++)
        {
            int n = tokenizer.NextInt();
            for (int i = 0; i < n; i++)
            {
                a[i] = tokenizer.NextLong();
            }

            Console.WriteLine(InsertionSortAdvancedAnalysis.SolveFenvick(a, n));
        }

        //writer.Close();
        //}
        //}
    }

    public static class InsertionSortAdvancedAnalysis
    {
        public const int Max = 10000001;
        public static long SolveFenvick(long[] a, int n)
        {
            long result = 0;
            long sum = 0;
            long[] fenvick = new long[Max + 1];

            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (long v = a[i]; v >= 0; v = (v & (v + 1)) - 1)
                {
                    sum += fenvick[v];
                }

                result += i - sum;

                for (long v = a[i]; v < Max; v = v | (v + 1))
                {
                    fenvick[v]++;
                }
            }

            return result;
        }

        public static long Solve(long[] a, int n)
        {
            long result = 0;

            SegmentTree st = new SegmentTree(1, 10000000);
            for (int i = 0; i < n; i++)
            {
                result += st.Get(a[i]);
                st.Add(a[i]);
            }

            return result;
        }

        private class SegmentTree
        {
            private SegmentTreeNode root;

            public int Left { get; private set; }
            public int Right { get; private set; }

            public SegmentTree(int left, int right)
            {
                this.Left = left;
                this.Right = right;
            }

            public void Add(long value)
            {
                this.root = AddInternal(this.root, this.Left, this.Right, value);
            }

            public long Get(long value)
            {
                return GetInternal(this.root, this.Left, this.Right, value + 1, this.Right);
            }

            static private SegmentTreeNode AddInternal(SegmentTreeNode node, int left, int right, long pos)
            {
                if (left > right)
                {
                    return null;
                }

                node = node == null ? new SegmentTreeNode() : node;

                if (left == right)
                {
                    node.Value++;
                    return node;
                }

                int mid = (left + right) / 2;
                if (pos <= mid)
                {
                    node.Left = AddInternal(node.Left, left, mid, pos);
                }
                else
                {
                    node.Right = AddInternal(node.Right, mid + 1, right, pos);
                }
                node.Value = GetValue(node.Left) + GetValue(node.Right);

                return node;
            }

            static private long GetInternal(SegmentTreeNode node, int left, int right, long queryLeft, long queryRight)
            {
                if (queryLeft > right || queryRight < left || node == null)
                {
                    return 0;
                }

                if (left >= queryLeft && right <= queryRight)
                {
                    return node.Value;
                }

                int mid = (left + right) / 2;

                return GetInternal(node.Left, left, mid, queryLeft, queryRight) + GetInternal(node.Right, mid + 1, right, queryLeft, queryRight);
            }

            static private long GetValue(SegmentTreeNode node)
            {
                return node != null ? node.Value : 0;
            }

            private class SegmentTreeNode
            {
                public long Value { get; set; }
                public SegmentTreeNode Left { get; set; }
                public SegmentTreeNode Right { get; set; }
            }
        }
    }
}
