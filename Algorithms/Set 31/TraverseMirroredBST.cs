using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_31
{
    public class TraverseMirroredBST
    {
        public enum TraverseType
        {
            Pre,
            In,
            Post,
            Level
        }

        public static void Traverse(TraverseType type, TreeNode root, Action<TreeNode> callback)
        {
            switch (type)
            {
                case TraverseType.Pre:
                    TraverseDFSPre(root, callback);
                    break;
                case TraverseType.In:
                    TraverseDFSIn(root, callback);
                    break;
                case TraverseType.Post:
                    TraverseDFSPost(root, callback);
                    break;
                case TraverseType.Level:
                    TraverseBFS(root, callback);
                    break;
            }
        }

        public static void MirrorTree(TreeNode root)
        {
            Action<TreeNode> callback = x =>
            {
                TreeNode buffer = x.Left;
                x.Left = x.Right;
                x.Right = buffer;
            };

            TraverseBFS(root, callback);
        }

        protected static void TraverseBFS(TreeNode root, Action<TreeNode> callback)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();

                callback(currentNode);

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        protected static void TraverseDFSPre(TreeNode root, Action<TreeNode> callback)
        {
            Stack<TreeNode> firstLook = new Stack<TreeNode>();
            firstLook.Push(root);

            while (firstLook.Count > 0)
            {
                TreeNode currentNode = firstLook.Pop();
                callback(currentNode);

                if (currentNode.Right != null)
                {
                    firstLook.Push(currentNode.Right);
                }

                if (currentNode.Left != null)
                {
                    firstLook.Push(currentNode.Left);
                }
            }
        }

        protected static void TraverseDFSIn(TreeNode root, Action<TreeNode> callback)
        {
            Stack<TreeNode> firstLook = new Stack<TreeNode>();
            Stack<TreeNode> secondLook = new Stack<TreeNode>();
            firstLook.Push(root);

            while (firstLook.Count > 0 || secondLook.Count > 0)
            {
                if (firstLook.Count > 0)
                {
                    TreeNode currentNode = firstLook.Pop();
                    secondLook.Push(currentNode);

                    if (currentNode.Left != null)
                    {
                        firstLook.Push(currentNode.Left);
                    }
                }
                else
                {
                    TreeNode currentNode = secondLook.Pop();
                    callback(currentNode);

                    if (currentNode.Right != null)
                    {
                        firstLook.Push(currentNode.Right);
                    }
                }
            }
        }

        protected static void TraverseDFSPost(TreeNode root, Action<TreeNode> callback)
        {
            Stack<TreeNode> firstLook = new Stack<TreeNode>();
            Stack<TreeNode> secondLook = new Stack<TreeNode>();
            firstLook.Push(root);

            while (firstLook.Count > 0 || secondLook.Count > 0)
            {
                if (firstLook.Count > 0)
                {
                    TreeNode currentNode = firstLook.Pop();
                    secondLook.Push(currentNode);

                    if (currentNode.Right != null)
                    {
                        firstLook.Push(currentNode.Right);
                    }

                    if (currentNode.Left != null)
                    {
                        firstLook.Push(currentNode.Left);
                    }
                }
                else
                {
                    TreeNode currentNode = secondLook.Pop();
                    callback(currentNode);
                }
            }
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}
