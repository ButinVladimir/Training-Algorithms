using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_29
{
    public static class Ancestor
    {
        public static TreeNode FindAncestory(TreeNode a, TreeNode b)
        {
            int depthA = FindDepth(a);
            int depthB = FindDepth(b);

            a = UpLift(a, depthA, depthB);
            b = UpLift(b, depthB, depthA);

            depthA = depthB = Math.Min(depthA, depthB);

            while (a != b)
            {
                a = a.Parent;
                b = b.Parent;
            }

            return a;
        }

        public static bool CheckBalance(TreeNode root)
        {
            int depth;
            return CheckBalanceInt(root, out depth);
        }

        private static bool CheckBalanceInt(TreeNode root, out int depth)
        {
            if (root == null)
            {
                depth = 0;
                return true;
            }

            int leftDepth, rightDepth;

            bool correct = true;

            correct &= CheckBalanceInt(root.Left, out leftDepth);
            correct &= CheckBalanceInt(root.Right, out rightDepth);

            if (Math.Abs(leftDepth - rightDepth) > 1)
            {
                correct = false;
            }

            depth = Math.Max(leftDepth, rightDepth) + 1;

            return correct;
        }

        private static int FindDepth(TreeNode node)
        {
            int result = 0;

            while (node != null)
            {
                result++;
                node = node.Parent;
            }

            return result;
        }

        private static TreeNode UpLift(TreeNode node, int depthSrc, int depthDest)
        {
            while (depthSrc > depthDest)
            {
                depthSrc--;
                node = node.Parent;
            }

            return node;
        }

        public class TreeNode
        {
            public TreeNode(int value)
            {
                this.Value = value;
            }

            public int Value { get; private set; }

            public TreeNode Left { get; set; }

            public TreeNode Right { get; set; }

            public TreeNode Parent { get; set; }
        }
    }
}
