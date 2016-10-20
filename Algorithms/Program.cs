using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MustBST;

namespace Algorithms
{
    class Program
    {
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
    }
}