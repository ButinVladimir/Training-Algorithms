using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    sealed class TreeNode
    {
        public char Value { get; set; }

        public TreeNode Left {get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(char value, TreeNode left, TreeNode right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }

    sealed class TreeConverter
    {
        const char DELIMITER = '$';
        const char ESCAPE = '\\';
        static public string ConvertTo(TreeNode root)
        {
            if (root == null)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            ConvertToRecursive(root, sb);
            return sb.ToString();
        }

        static private void ConvertToRecursive(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                return;
            }

            if (root.Value == DELIMITER)
            {
                sb.Append(ESCAPE);
            }
            sb.Append(root.Value);

            if (root.Left != null)
            {
                ConvertToRecursive(root.Left, sb);
            } else
            {
                sb.Append(DELIMITER);
            }

            if (root.Right!= null)
            {
                ConvertToRecursive(root.Right, sb);
            }
            else
            {
                sb.Append(DELIMITER);
            }
        }

        static public TreeNode ConvertFrom(string s)
        {
            if (s == "")
            {
                return null;
            }

            int position = 0;
            return ConvertFromRecursive(s, ref position);
        }

        static private TreeNode ConvertFromRecursive(string s, ref int position)
        {
            if (s[position] == DELIMITER)
            {
                return null;
            }
            if (s[position] == ESCAPE)
            {
                position++;
            }

            TreeNode result = new TreeNode(s[position], null, null);
            position++;
            ConvertFromRecursive(s, ref position);
            ConvertFromRecursive(s, ref position);
            return result;
        }
    }
}
