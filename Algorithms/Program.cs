using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
//using Algorithms.Set_49;

public class Program
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

    class Washing
    {
        public int N { get; set; }

        public int K { get; set; }

        public long[] P { get; set; }

        public long[] D { get; set; }

        public long Solve()
        {
            long[] a = new long[this.N];
            long result = 0;

            for (int i = 0; i < this.N; i++)
            {
                a[i] = this.P[i] + this.D[i];
                result -= this.D[i];
            }

            Array.Sort(a);

            for (int i = this.N - 1; i >= 0 && i >= this.N - this.K; i--)
            {
                result += a[i];
            }

            return result < 0 ? 0 : result;
        }
    }

    class NPHard
    {
        private const int Pari = 1;

        private const int Arya = -1;

        private const int Neutral = 0;

        public int N { get; set; }

        public int M { get; set; }

        public List<int>[] Ribs { get; set; }

        public List<int> PariVertices { get; private set; }

        public List<int> AryaVertices { get; private set; }

        public bool Solve()
        {
            int[] colors = new int[this.N];

            for (int i = 0; i < this.N; i++)
            {
                colors[i] = Neutral;
            }

            Queue<int> queue = new Queue<int>();

            for (int startVertex = 0; startVertex < this.N; startVertex++)
            {
                if (!this.BFS(colors, startVertex, queue))
                {
                    return false;
                }
            }

            this.AryaVertices = new List<int>();
            this.PariVertices = new List<int>();

            for (int vertex = 0; vertex < this.N; vertex++)
            {
                if (colors[vertex] == Arya)
                {
                    this.AryaVertices.Add(vertex);
                }
                else if (colors[vertex] == Pari)
                {
                    this.PariVertices.Add(vertex);
                }
            }

            return true;
        }

        private bool BFS(int[] colors, int startVertex, Queue<int> queue)
        {
            if (colors[startVertex] != Neutral)
            {
                return true;
            }

            colors[startVertex] = Arya;
            queue.Clear();
            queue.Enqueue(startVertex);

            int currentVertex, nextColor;
            while (queue.Count > 0)
            {
                currentVertex = queue.Dequeue();
                nextColor = colors[currentVertex] == Arya ? Pari : Arya;

                foreach (int nextVertex in this.Ribs[currentVertex])
                {
                    if (colors[nextVertex] == Neutral)
                    {
                        colors[nextVertex] = nextColor;
                        queue.Enqueue(nextVertex);
                    }
                    else if (colors[nextVertex] != nextColor)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public static void Main()
    {
        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextToken(int.Parse);
        int m = tokenizer.NextToken(int.Parse);
        List<int>[] ribs = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            ribs[i] = new List<int>();
        }

        int a, b;
        for (int i = 0; i < m; i++)
        {
            a = tokenizer.NextToken(int.Parse) - 1;
            b = tokenizer.NextToken(int.Parse) - 1;
            ribs[a].Add(b);
            ribs[b].Add(a);
        }

        NPHard problem = new NPHard() { N = n, M = m, Ribs = ribs };
        if (!problem.Solve())
        {
            Console.WriteLine("-1");
            return;
        }

        Console.WriteLine(problem.AryaVertices.Count);
        foreach (int vertice in problem.AryaVertices)
        {
            Console.Write(string.Format("{0} ", vertice + 1));
        }

        Console.WriteLine();

        Console.WriteLine(problem.PariVertices.Count);
        foreach (int vertice in problem.PariVertices)
        {
            Console.Write(string.Format("{0} ", vertice + 1));
        }
    }
}