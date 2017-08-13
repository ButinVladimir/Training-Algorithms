using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_14
{
    public class MedianBST
    {
        public Node Root { get; set; }

        public double Solve()
        {
            UpdateCount(this.Root);

            int count = GetCount(this.Root);
            return (GetValue(this.Root, (count - 1) / 2 + 1) + GetValue(this.Root, (count - 1) - (count - 1) / 2) + 1) / 2.0;
        }

        private static int GetValue(Node node, int pos)
        {
            int currentPos = GetCount(node.Left) + 1;

            if (pos == currentPos)
            {
                return node.Value;
            }

            if (pos > currentPos)
            {
                return GetValue(node.Right, pos - currentPos);
            }

            return GetValue(node.Left, pos);
        }

        private static void UpdateCount(Node node)
        {
            if (node != null)
            {
                UpdateCount(node.Left);
                UpdateCount(node.Right);

                node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);
            }
        }

        private static int GetCount(Node node)
        {
            return node != null ? node.Count : 0;
        }

        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }
            public int Count { get; set; }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MedianBSTTest
    {
        [TestMethod]
        public void Test()
        {
            MedianBST mbst = new MedianBST()
            {
                Root = new MedianBST.Node()
                {
                    Value = 5,
                    Left = new MedianBST.Node()
                    {
                        Value = 3,
                        Left = new MedianBST.Node()
                        {
                            Value = 1
                        },
                        Right = new MedianBST.Node()
                        {
                            Value = 4
                        }
                    },
                    Right = new MedianBST.Node()
                    {
                        Value = 7
                    }
                }
            };

            Assert.AreEqual(4, mbst.Solve());
        }

        [TestMethod]
        public void Test2()
        {
            MedianBST mbst = new MedianBST()
            {
                Root = new MedianBST.Node()
                {
                    Value = 5,
                    Left = new MedianBST.Node()
                    {
                        Value = 3,
                        Left = new MedianBST.Node()
                        {
                            Value = 1
                        },
                        Right = new MedianBST.Node()
                        {
                            Value = 4
                        }
                    },
                    Right = new MedianBST.Node()
                    {
                        Value = 7,
                        Left = new MedianBST.Node()
                        {
                            Value = 6
                        }
                    }
                }
            };

            Assert.AreEqual(4.5, mbst.Solve());
        }
    }
}
