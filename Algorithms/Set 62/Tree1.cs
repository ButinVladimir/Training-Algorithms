using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_62
{
    class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Count { get; set; }

        public TreeNode()
        {
            Count = 1;
            Left = Right = null;
        }

        public static TreeNode Add(TreeNode rootNode, TreeNode node)
        {
            if (rootNode == null)
            {
                rootNode = node;
                return rootNode;
            }

            TreeNode currentNode = rootNode;

            while (true)
            {
                currentNode.Count++;

                if (node.Value > currentNode.Value)
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        currentNode.Right = node;
                        return rootNode;
                    }
                }
                else
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        currentNode.Left = node;
                        return rootNode;
                    }
                }
            }
        }
    }

    class PrecalcMatrix
    {
        const int N = 31;
        private BigInteger[,] value;

        public PrecalcMatrix()
        {
            value = new BigInteger[N, N];
            Precalc();
        }

        private void Precalc()
        {
            for (int i = 0; i < N; i++)
            {
                value[0, i] = value[i, 0] = BigInteger.One;
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    value[i, j] = value[i - 1, j] + value[i, j - 1];
                }
            }
        }

        public BigInteger Get(int x, int y)
        {
            return value[x, y];
        }
    }

    class Tree1
    {
        private static PrecalcMatrix precalcMatrix;

        static Tree1()
        {
            precalcMatrix = new PrecalcMatrix();
        }

        private static BigInteger GetValue(TreeNode rootNode)
        {
            if (rootNode == null)
            {
                return BigInteger.One;
            }

            int x = rootNode.Left != null ? rootNode.Left.Count : 0;
            int y = rootNode.Right != null ? rootNode.Right.Count : 0;

            return precalcMatrix.Get(x, y) * GetValue(rootNode.Left) * GetValue(rootNode.Right);
        }

        public static BigInteger Solve(int[] arr)
        {
            int n = arr.Length;
            TreeNode rootNode = null;

            for (int i = 0; i < n; i++)
            {
                TreeNode currentNode = new TreeNode() { Value = arr[i] };
                rootNode = TreeNode.Add(rootNode, currentNode);
            }

            return GetValue(rootNode);
        }
    }
}
