using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_58
{
    class Traversal
    {
        public static List<int> Solve(TreeNode root)
        {
            List<int> result = new List<int>();

            LinkedList<TreeNode> queue = new LinkedList<TreeNode>();
            PushToQueue(root, queue);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Last.Value;
                result.Add(current.Value);
                queue.RemoveLast();

                PushToQueue(current.Right, queue);
                PushToQueue(current.Left, queue);
            }

            result.Reverse();

            return result;
        }

        private static void PushToQueue(TreeNode node, LinkedList<TreeNode> queue)
        {
            if (node != null)
            {
                queue.AddFirst(node);
            }
        }

        public class TreeNode
        {
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public int Value{ get; set; }
        }
    }
}
