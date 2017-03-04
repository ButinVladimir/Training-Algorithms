using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Algorithms.Set_31;

class Solution
{
    private class Tokenizer
    {
        private string currentString = null;

        private string[] tokens = null;

        private int tokenNumber = 0;

        private static readonly char[] Separators = { ' ' };

        public T NextToken<T>(Func<string, T> parser)
        {
            return parser(this.GetNextToken());
        }

        public string NextToken()
        {
            return this.GetNextToken();
        }

        public int NextInt()
        {
            return this.NextToken(int.Parse);
        }

        public long NextLong()
        {
            return this.NextToken(long.Parse);
        }

        private string GetNextToken()
        {
            if (this.currentString == null || this.tokenNumber == this.tokens.Length)
            {
                this.currentString = this.GetNextString();

                while (this.currentString != null && this.currentString.Equals(string.Empty))
                {
                    this.currentString = this.GetNextString();
                }

                if (this.currentString == null)
                {
                    throw new Exception("End of input");
                }

                this.tokens = this.currentString.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                this.tokenNumber = 0;
            }

            return this.tokens[this.tokenNumber++];
        }

        private string GetNextString()
        {
            string content = Console.ReadLine();
            if (content == null)
            {
                return null;
            }

            return content.Trim();
        }
    }

    static void Main()
    {
        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);

        TreeNode rootNode = new TreeNode()
        {
            Value = 10,
            Left = new TreeNode()
            {
                Value = 5,
                Left = new TreeNode()
                {
                    Value = 3,
                    Left = new TreeNode()
                    {
                        Value = 1,
                        Right = new TreeNode()
                        {
                            Value = 2
                        }
                    },
                    Right = new TreeNode()
                    {
                        Value = 4
                    },
                },
                Right = new TreeNode()
                {
                    Value = 8,
                    Left = new TreeNode()
                    {
                        Value = 7,
                        Left = new TreeNode()
                        {
                            Value = 6
                        }
                    },
                    Right = new TreeNode()
                    {
                        Value = 9
                    },
                }
            },
            Right = new TreeNode()
            {
                Value = 15,
                Left = new TreeNode()
                {
                    Value = 13,
                    Left = new TreeNode()
                    {
                        Value = 11,
                        Right = new TreeNode()
                        {
                            Value = 12
                        }
                    },
                    Right = new TreeNode()
                    {
                        Value = 14
                    },
                },
                Right = new TreeNode()
                {
                    Value = 18,
                    Left = new TreeNode()
                    {
                        Value = 17,
                        Left = new TreeNode()
                        {
                            Value = 16
                        }
                    },
                    Right = new TreeNode()
                    {
                        Value = 19
                    },
                }
            },
        };

        TraverseMirroredBST.TraverseType[] types = new TraverseMirroredBST.TraverseType[]
        {
            TraverseMirroredBST.TraverseType.Pre,
            TraverseMirroredBST.TraverseType.In,
            TraverseMirroredBST.TraverseType.Post,
            TraverseMirroredBST.TraverseType.Level
        };

        Traverse(rootNode, types);

        Console.Write("\r\n\r\n\r\n");
        TraverseMirroredBST.MirrorTree(rootNode);

        Traverse(rootNode, types);

        //writer.Close();
    }

    private static void Traverse(TreeNode rootNode, TraverseMirroredBST.TraverseType[] types)
    {
        foreach (var type in types)
        {
            Console.Write(string.Format("Order {0}:\t", type));
            TraverseMirroredBST.Traverse(type, rootNode, x => Console.Write(x.Value + "  "));
            Console.WriteLine();
        }
    }
}