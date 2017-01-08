using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_48
{
    class Prefix
    {
        public static int Solve(int[] numbers)
        {
            int n = numbers.Length;
            Dictionary<int, int> mapping = GetMapping(n, numbers);

            Node node = new Node();
            int number;
            int result = 0;
            for (int position = n - 1; position >= 0; position--)
            {
                number = mapping[numbers[position]];
                result = Math.Max(result, node.Get(0, n, number + 1, n));
                node.Add(0, n, number);
            }

            return result;
        }

        private static Dictionary<int, int> GetMapping(int n, int[] numbers)
        {
            Dictionary<int, int> mapping = new Dictionary<int, int>();

            int[] sortedNumbers = new int[n];
            numbers.CopyTo(sortedNumbers, 0);
            Array.Sort(sortedNumbers);

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (!mapping.ContainsKey(sortedNumbers[i]))
                {
                    mapping[sortedNumbers[i]] = count;
                    count++;
                }
            }

            return mapping;
        }

        private class Node
        {
            private Node left;
            private Node right;
            private int count;

            public Node()
            {
                this.count = 0;
                this.left = this.right = null;
            }

            public void Add(int left, int right, int position)
            {
                if (left == right)
                {
                    this.Update();
                    return;
                }

                int middle = (left + right) / 2;

                if (position <= middle)
                {
                    this.left = this.left ?? new Node();
                    this.left.Add(left, middle, position);
                }
                else
                {
                    this.right = this.right ?? new Node();
                    this.right.Add(middle + 1, right, position);
                }

                this.Update();
            }

            public int Get(int left, int right, int searchLeft, int searchRight)
            {
                if (left >= searchLeft && right <= searchRight)
                {
                    return this.count;
                }

                int middle = (left + right) / 2;
                int result = 0;

                if (this.left != null && middle >= searchLeft)
                {
                    result += this.left.Get(left, middle, searchLeft, searchRight);
                }

                if (this.right != null && (middle + 1) <= searchRight)
                {
                    result += this.right.Get(middle + 1, right, searchLeft, searchRight);
                }

                return result;
            }

            void Update()
            {
                this.count++;
            }
        }
    }
}
