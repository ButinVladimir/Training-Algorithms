using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_26
{
    public static class BuildTree
    {
        public static BinaryTreeNode Solve(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                return null;
            }

            return Solve(0, a.Length - 1, a);
        }

        private static BinaryTreeNode Solve(int l, int r, int[] a)
        {
            if (l > r)
            {
                return null;
            }

            int m = (l + r) / 2;

            return new BinaryTreeNode(a[m], Solve(l, m - 1, a), Solve(m + 1, r, a));
        }

        public class BinaryTreeNode
        {
            public BinaryTreeNode(int data, BinaryTreeNode left, BinaryTreeNode right)
            {
                this.Data = data;
                this.Left = left;
                this.Right = right;
            }

            public int Data { get; private set; }

            public BinaryTreeNode Left { get; private set; }

            public BinaryTreeNode Right { get; private set; }
        }
    }

    [TestClass]
    public class BuildTreeTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            BuildTree.BinaryTreeNode root = BuildTree.Solve(a);

            Assert.IsTrue(TestTree(root, a));
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { };
            BuildTree.BinaryTreeNode root = BuildTree.Solve(a);

            Assert.IsNull(root);
        }

        [TestMethod]
        public void Test3()
        {
            int[] a = null;
            BuildTree.BinaryTreeNode root = BuildTree.Solve(a);

            Assert.IsNull(root);
        }

        [TestMethod]
        public void Test4()
        {
            int[] a = new int[] { 1, 1, 1, 1, 1 };
            BuildTree.BinaryTreeNode root = BuildTree.Solve(a);

            Assert.IsTrue(TestTree(root, a));
        }

        [TestMethod]
        public void Test5()
        {
            int[] a = new int[] { 1, 1, 2, 2, 3, 3 };
            BuildTree.BinaryTreeNode root = BuildTree.Solve(a);

            Assert.IsTrue(TestTree(root, a));
        }

        private bool TestTree(BuildTree.BinaryTreeNode root, int[] a)
        {
            List<int> resultList = new List<int>();

            BuildTreeList(root, resultList);

            int[] resultArray = resultList.ToArray();
            if (a.Length != resultArray.Length)
            {
                return false;
            }

            for (int i = 0; i < resultArray.Length; i++)
            {
                if (a[i] != resultArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void BuildTreeList(BuildTree.BinaryTreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            BuildTreeList(node.Left, result);
            result.Add(node.Data);
            BuildTreeList(node.Right, result);
        }
    }
}
