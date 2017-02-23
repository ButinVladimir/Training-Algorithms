using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_36
{
    public class Tree
    {
        private const string End = "#";

        public static TreeNode Parse(string[] array)
        {
            TreeNode rootNode = null;
            Dictionary<string, TreeNode> mapping = new Dictionary<string, TreeNode>();

            foreach (string s in array)
            {
                string[] values = s.Split(',');
                TreeNode parent = GetNode(values[0], mapping);

                if (!values[1].Equals(End))
                {
                    TreeNode left = GetNode(values[1], mapping);
                    parent.Left = left;
                    left.Parent = parent;
                }

                if (!values[2].Equals(End))
                {
                    TreeNode right = GetNode(values[2], mapping);
                    parent.Right = right;
                    right.Parent = parent;
                }

                if (rootNode == null)
                {
                    rootNode = parent;
                }
            }

            while (rootNode.Parent != null)
            {
                rootNode = rootNode.Parent;
            }

            return rootNode;
        }

        private static TreeNode GetNode(string value, Dictionary<string, TreeNode> mapping)
        {
            TreeNode resultNode;

            if (!mapping.TryGetValue(value, out resultNode))
            {
                resultNode = new Tree.TreeNode()
                {
                    Value = value
                };

                mapping[value] = resultNode;
            }

            return resultNode;
        }

        public class TreeNode
        {
            public TreeNode Left { get; set; }

            public TreeNode Right { get; set; }

            public TreeNode Parent { get; set; }

            public string Value { get; set; }

            public void Walk(Action<TreeNode> callback)
            {
                if (this.Left != null)
                {
                    this.Left.Walk(callback);
                }

                callback(this);

                if (this.Right != null)
                {
                    this.Right.Walk(callback);
                }
            }
        }
    }
}
