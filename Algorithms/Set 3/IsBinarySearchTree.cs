using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_3
{
    public static class IsBinarySearchTree
    {
        public static bool Solve(TreeNode rootNode)
        {
            int min, max;

            if (rootNode == null)
            {
                return true;
            }

            return Solve(rootNode, out min, out max);
        }

        private static bool Solve(TreeNode node, out int min, out int max)
        {
            min = max = node.Value;
            int leftMin, leftMax, rightMin, rightMax;

            if (node.Left != null)
            {
                if (!Solve(node.Left, out leftMin, out leftMax))
                {
                    return false;
                }

                if (leftMax > node.Value)
                {
                    return false;
                }

                min = Math.Min(min, leftMin);
            }

            if (node.Right != null)
            {
                if (!Solve(node.Right, out rightMin, out rightMax))
                {
                    return false;
                }

                if (rightMin < node.Value)
                {
                    return false;
                }

                max = Math.Max(max, rightMax);
            }

            return true;
        }
    }

    public class TreeNode
    {
        public int Value { get; private set; }
        public TreeNode Left { get; private set; }
        public TreeNode Right{ get; private set; }

        public TreeNode(int value, TreeNode left, TreeNode right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }

    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void Test1()
        {
            TreeNode rootNode = new TreeNode(
                5,
                new TreeNode(
                    3, 
                    null, 
                    new TreeNode(4, null, null)),
                new TreeNode(
                    7,
                    new TreeNode(6, null, null),
                    new TreeNode(10, null, null)));

            Assert.IsTrue(IsBinarySearchTree.Solve(rootNode));
        }

        [TestMethod]
        public void Test2()
        {
            TreeNode rootNode = new TreeNode(
                5,
                new TreeNode(
                    3,
                    null,
                    new TreeNode(7, null, null)),
                new TreeNode(
                    7,
                    new TreeNode(3, null, null),
                    new TreeNode(10, null, null)));

            Assert.IsFalse(IsBinarySearchTree.Solve(rootNode));
        }
    }
}
