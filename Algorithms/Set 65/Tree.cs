using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_65
{
    using System.Net;

    public class Tree
    {
        private const long Module = 1000000007;

        private int n;

        private TreeNode[] nodes;

        public Tree(int n)
        {
            this.n = n;

            this.nodes = new TreeNode[this.n];
            for (int i = 0; i < this.n; i++)
            {
                this.nodes[i] = new TreeNode();
            }
        }

        public void AddRib(int from, int to, bool red)
        {
            this.nodes[from].AddRib(to, red);
            this.nodes[to].AddRib(from, red);
        }

        public long Solve()
        {
            this.ComputeCounts();

            return this.Calc();
        }

        private void ComputeCounts()
        {
            int[] queue = new int[this.n];
            bool[] visited = new bool[this.n];

            queue[0] = 0;
            visited[0] = true;

            int leftBorder = 0;
            int rightBorder = 0;
            int from, to;
            long black, red;

            while (leftBorder <= rightBorder)
            {
                from = queue[leftBorder++];

                foreach (var rib in this.nodes[from].Ribs)
                {
                    to = rib.Item1;
                    if (visited[to])
                    {
                        continue;
                    }

                    queue[++rightBorder] = to;
                    visited[to] = true;
                }
            }

            while (rightBorder >= 0)
            {
                TreeNode node = this.nodes[queue[rightBorder--]];

                node.BlackCount = 1;
                node.RedCount = 0;

                foreach (var rib in node.Ribs)
                {
                    this.GetCount(rib.Item1, rib.Item2, out black, out red);

                    node.RedCount += red;
                    node.BlackCount += black;
                }
            }
        }

        private void GetCount(int vertex, bool isRibRed, out long black, out long red)
        {
            TreeNode node = this.nodes[vertex];

            if (isRibRed)
            {
                black = 0;
                red = node.RedCount + node.BlackCount;
            }
            else
            {
                black = node.BlackCount;
                red = node.RedCount;
            }
        }

        private long Calc()
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[this.n];
            long[] blackCount = new long[this.n];
            long[] redCount = new long[this.n];

            queue.Enqueue(0);
            visited[0] = true;
            int from, to;

            long result = 0;
            long localResult;
            long sumBlack = 0;
            long sumRed = 0;
            long red, black;
            long blackPairs = 0;
            long redPairs = 0;

            long localRed, localBlack;

            while (queue.Count > 0)
            {
                from = queue.Dequeue();
                blackCount[from]++;

                foreach (var rib in this.nodes[from].Ribs)
                {
                    to = rib.Item1;
                    if (visited[to])
                    {
                        continue;
                    }
                    this.GetCount(to, rib.Item2, out black, out red);

                    blackPairs = (blackPairs + (red * sumBlack) % Module) % Module;
                    blackPairs = (blackPairs + (black * sumRed) % Module) % Module;
                    redPairs = (redPairs + (red * sumRed) % Module) % Module;

                    sumBlack += black;
                    sumRed += red;
                }

                localResult = 0;
                localBlack = sumBlack;
                localRed = sumRed;

                foreach (var rib in this.nodes[from].Ribs)
                {
                    to = rib.Item1;
                    if (visited[to])
                    {
                        continue;
                    }
                    this.GetCount(to, rib.Item2, out black, out red);

                    sumBlack -= black;
                    sumRed -= red;

                    blackPairs = (blackPairs - red * sumBlack % Module + Module) % Module;
                    blackPairs = (blackPairs - black * sumRed % Module + Module) % Module;
                    redPairs = (redPairs - red * sumRed % Module + Module) % Module;

                    localResult = (localResult + black * redPairs % Module) % Module;
                    localResult = (localResult + red * blackPairs % Module) % Module;
                    localResult = (localResult + red * redPairs % Module) % Module;

                    localResult = (localResult + red * blackCount[from] % Module * sumRed % Module) % Module;
                    localResult = (localResult + red * redCount[from] % Module * sumBlack % Module) % Module;
                    localResult = (localResult + red * redCount[from] % Module * sumRed % Module) % Module;
                    localResult = (localResult + black * redCount[from] % Module * sumRed % Module) % Module;

                    localResult = (localResult + red * redCount[from] % Module) % Module;
                }

                result = (result + localResult) % Module;

                foreach (var rib in this.nodes[from].Ribs)
                {
                    to = rib.Item1;
                    if (visited[to])
                    {
                        continue;
                    }
                    this.GetCount(to, rib.Item2, out black, out red);

                    redCount[to] = redCount[from] + localRed - red;
                    blackCount[to] = blackCount[from] + localBlack - black;

                    if (rib.Item2)
                    {
                        redCount[to] += blackCount[to];
                        blackCount[to] = 0;
                    }

                    visited[to] = true;
                    queue.Enqueue(to);
                }
            }

            return result;            
        }

        private class TreeNode
        {
            public TreeNode()
            {
                this.Ribs = new List<Tuple<int, bool>>();
            }

            public long RedCount { get; set; }

            public long BlackCount { get; set; }

            public List<Tuple<int, bool>> Ribs { get; private set; }

            public void AddRib(int to, bool red)
            {
                this.Ribs.Add(new Tuple<int, bool>(to, red));
            }
        }
    }
}
