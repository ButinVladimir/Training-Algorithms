using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MustBST
{
    class TreeNode
    {
        public int Value { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value, TreeNode left = null, TreeNode right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public bool CheckNode()
        {
            if (this.Left != null)
            {
                if (!this.Left.CheckNode())
                {
                    return false;
                }

                this.Left.UpdateMinMax();
                if (this.Value < this.Left.Max)
                {
                    return false;
                }
            }

            if (this.Right != null)
            {
                if (!this.Right.CheckNode())
                {
                    return false;
                }

                this.Right.UpdateMinMax();
                if (this.Value > this.Right.Min)
                {
                    return false;
                }
            }

            return true;
        }

        public void UpdateMinMax()
        {
            this.Min = this.Max = this.Value;
            this.UpdateMinMax(this.Left);
            this.UpdateMinMax(this.Right);
        }

        protected void UpdateMinMax(TreeNode node)
        {
            if (node != null)
            {
                if (node.Min < this.Min)
                {
                    this.Min = node.Min;
                }

                if (node.Max > this.Max)
                {
                    this.Max = node.Max;
                }
            }
        }
    }
}


/*
 * 
 * Usage
 * 
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5,
                new TreeNode(6, new TreeNode(3), new TreeNode(7)),
                new TreeNode(7, new TreeNode(6), new TreeNode(9))
            );

            bool result;
            result = root.CheckNode();
            Console.WriteLine(result);
        }
 */
