using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_10
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    public static class ConvertToTree
    {
        public static TreeNode Convert(int[] array)
        {
            Array.Sort(array);

            return Convert(array, 0, array.Length - 1);
        }

        private static TreeNode Convert(int[] array, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            int m = (left + right) / 2;

            return new TreeNode()
            {
                Value = array[m],
                Left = Convert(array, left, m - 1),
                Right = Convert(array, m + 1, right)
            };
        }
    }

    public class Sum
    {
        private TreeNode rootNode;

        public int[] Content { get; set; }
        public int X { get; set; }

        public Tuple<int, int> Solve()
        {
            this.rootNode = ConvertToTree.Convert(Content);

            Tuple<int, int> result = this.DFS(this.rootNode);
            if (result != null)
            {
                return new Tuple<int, int>(Math.Min(result.Item1, result.Item2), Math.Max(result.Item1, result.Item2));
            }

            return null;
        }

        private Tuple<int, int> DFS(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            if (this.Find(node, this.X - node.Value))
            {
                return new Tuple<int, int>(node.Value, this.X - node.Value);
            }

            return this.DFS(node.Left) ?? this.DFS(node.Right) ?? null;
        }

        private bool Find(TreeNode compareNode, int value)
        {
            TreeNode currentNode = this.rootNode;

            while (currentNode != null)
            {
                if (currentNode.Value + compareNode.Value == this.X)
                {
                    if (currentNode != compareNode)
                    {
                        return true;
                    }

                    if (currentNode.Left != null && currentNode.Left.Value == currentNode.Value)
                    {
                        return true;
                    }

                    if (currentNode.Right != null && currentNode.Right.Value == currentNode.Value)
                    {
                        return true;
                    }

                    return false;
                }

                if (value > currentNode.Value)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }

            return false;
        }
    }

    public class Sum2
    {
        enum LastOperation { Left, Right };

        private TreeNode rootNode;

        public int[] Content { get; set; }
        public int X { get; set; }

        public Tuple<int, int> Solve()
        {
            this.rootNode = ConvertToTree.Convert(Content);

            State leftState = new State() { Node = this.rootNode, Operation = LastOperation.Left };
            Stack<State> leftStack = new Stack<State>();
            leftStack.Push(leftState);
            this.GoLeft(leftStack);

            State rightState = new State() { Node = this.rootNode, Operation = LastOperation.Right };
            Stack<State> rightStack = new Stack<State>();
            rightStack.Push(rightState);
            this.GoRight(rightStack);

            while (leftStack.Count > 0 && rightStack.Count > 0)
            {
                leftState = leftStack.Peek();
                rightState = rightStack.Peek();

                int value = leftState.Node.Value + rightState.Node.Value;
                if (value > this.X)
                {
                    this.Prev(rightStack);
                }
                else if (value < this.X)
                {
                    this.Next(leftStack);
                }
                else
                {
                    if (leftState.Node != rightState.Node)
                    {
                        return new Tuple<int, int>(leftState.Node.Value, rightState.Node.Value);
                    }

                    return null;
                }
            }

            return null;
        }

        private bool Prev(Stack<State> stack)
        {
            while (stack.Count > 0)
            {
                State currentState = stack.Peek();
                if (currentState.Operation == LastOperation.Right)
                {
                    currentState.Operation = LastOperation.Left;

                    if (currentState.Node.Left != null)
                    {
                        State newState = new State()
                        {
                            Node = currentState.Node.Left,
                            Operation = LastOperation.Right
                        };
                        stack.Push(newState);

                        this.GoRight(stack);

                        return true;
                    }
                }
                else
                {
                    stack.Pop();
                }
            }

            return false;
        }

        private bool Next(Stack<State> stack)
        {
            while (stack.Count > 0)
            {
                State currentState = stack.Peek();
                if (currentState.Operation == LastOperation.Left)
                {
                    currentState.Operation = LastOperation.Right;

                    if (currentState.Node.Right != null)
                    {
                        State newState = new State()
                        {
                            Node = currentState.Node.Right,
                            Operation = LastOperation.Left
                        };
                        stack.Push(newState);

                        this.GoLeft(stack);

                        return true;
                    }
                }
                else
                {
                    stack.Pop();
                }
            }

            return false;
        }

        private void GoRight(Stack<State> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            State currentState = stack.Peek();
            while (currentState.Node.Right != null)
            {
                State newState = new State()
                {
                    Node = currentState.Node.Right,
                    Operation = LastOperation.Right
                };

                stack.Push(newState);
                currentState = newState;
            }
        }

        private void GoLeft(Stack<State> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            State currentState = stack.Peek();
            while (currentState.Node.Left != null)
            {
                State newState = new State()
                {
                    Node = currentState.Node.Left,
                    Operation = LastOperation.Left
                };

                stack.Push(newState);
                currentState = newState;
            }
        }

        private class State
        {
            public TreeNode Node { get; set; }
            public LastOperation Operation { get; set; }
        }
    }

    [TestClass]
    public class SumTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = { 2, 3, 7, 4, 2, 9 };
            Sum sum = new Sum() { Content = a, X = 4 };
            Sum2 sum2 = new Sum2() { Content = a, X = 4 };

            Tuple<int, int> result = sum.Solve();
            Tuple<int, int> result2 = sum2.Solve();

            Assert.AreEqual(2, result.Item1);
            Assert.AreEqual(2, result2.Item1);
            Assert.AreEqual(result.Item1, result2.Item1);
            Assert.AreEqual(result.Item2, result2.Item2);
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = { 2, 3, 5, 10, 11, 200 };
            Sum sum = new Sum() { Content = a, X = -1 };
            Sum2 sum2 = new Sum2() { Content = a, X = -1 };

            Tuple<int, int> result = sum.Solve();
            Tuple<int, int> result2 = sum2.Solve();

            Assert.IsNull(result);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void Test3()
        {
            int[] a = { 2, 3, 5, 10, 11 };
            Sum sum = new Sum() { Content = a, X = 14 };
            Sum2 sum2 = new Sum2() { Content = a, X = 14 };

            Tuple<int, int> result = sum.Solve();
            Tuple<int, int> result2 = sum2.Solve();

            Assert.AreEqual(3, result.Item1);
            Assert.AreEqual(11, result.Item2);
            Assert.AreEqual(result.Item1, result2.Item1);
            Assert.AreEqual(result.Item2, result2.Item2);
        }
    }
}
