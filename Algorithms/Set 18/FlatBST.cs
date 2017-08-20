using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_18
{
    public static class FlatBST
    {
        public static TreeNode Solve(TreeNode root)
        {
            TreeNode start, end;
            Solve(root, out start, out end);

            return start;
        }

        private static void Solve(TreeNode node, out TreeNode start, out TreeNode end)
        {
            if (node == null)
            {
                start = end = null;

                return;
            }

            TreeNode leftStart, leftEnd, rightStart, rightEnd;
            Solve(node.Left, out leftStart, out leftEnd);
            Solve(node.Right, out rightStart, out rightEnd);

            if (leftStart == null)
            {
                start = node;
            }
            else
            {
                start = leftStart;
                leftEnd.Right = node;
            }

            if (rightStart == null)
            {
                end = node;
            }
            else
            {
                end = rightEnd;
                node.Right = rightStart;
            }
        }

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class FlatBSTTest
    {
        [TestMethod]
        public void Test1()
        {
            FlatBST.TreeNode rootNode = this.BuildTree(new int[] { 10, 5, 1, 2, 3, 4, 6, 7, 9, 8 });
            FlatBST.TreeNode newRootNode = FlatBST.Solve(rootNode);

            List<int> result = new List<int>();
            while (newRootNode != null)
            {
                result.Add(newRootNode.Value);
                newRootNode = newRootNode.Right;
            }

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result.ToArray());
        }

        private FlatBST.TreeNode BuildTree(IEnumerable<int> values)
        {
            FlatBST.TreeNode rootNode, currentNode, nextNode;
            rootNode = null;

            foreach (int value in values)
            {
                if (rootNode == null)
                {
                    rootNode = new FlatBST.TreeNode()
                    {
                        Value = value
                    };

                    continue;
                }

                currentNode = rootNode;
                nextNode = new FlatBST.TreeNode()
                {
                    Value = value
                };

                while (true)
                {
                    if (value < currentNode.Value)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = nextNode;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Left;
                        }
                    }
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = nextNode;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                }
            }

            return rootNode;
        }
    }
}
