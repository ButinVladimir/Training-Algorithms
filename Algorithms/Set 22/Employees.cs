using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_22
{
    public class Employees
    {
        private SortedSet<int> visited;
        public BitArray[] Input { get; set; }

        public List<List<int>> FindGroups()
        {
            if (!this.Check())
            {
                throw new ArgumentException("Invalid input");
            }

            this.visited = new SortedSet<int>();
            int n = this.Input.Length;
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                if (!this.visited.Contains(i))
                {
                    result.Add(this.MakeGroup(i));
                }
            }

            return result;
        }

        private List<int> MakeGroup(int startIndex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startIndex);
            this.visited.Add(startIndex);

            List<int> result = new List<int>() { startIndex };

            int n = this.Input.Length;
            while (queue.Count > 0)
            {
                int currentIndex = queue.Dequeue();
                for (int nextIndex = 0; nextIndex < n; nextIndex++)
                {
                    if (this.Input[currentIndex][nextIndex] && !this.visited.Contains(nextIndex))
                    {
                        this.visited.Add(nextIndex);
                        queue.Enqueue(nextIndex);
                        result.Add(nextIndex);
                    }
                }
            }

            return result;
        }

        private bool Check()
        {
            int n = this.Input.Length;

            for (int i = 0; i < n; i++)
            {
                if (this.Input[i].Length != n)
                {
                    return false;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (this.Input[i][j] != this.Input[j][i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    [TestClass]
    public class EmployeesTest
    {
        [TestMethod]
        public void Test1()
        {
            Employees employees = new Employees();
            employees.Input = new BitArray[4];
            employees.Input[0] = new BitArray(new bool[] { false, true, true, false });
            employees.Input[1] = new BitArray(new bool[] { true, false, false, true });
            employees.Input[2] = new BitArray(new bool[] { true, false, false, false });
            employees.Input[3] = new BitArray(new bool[] { false, true, false, false });

            List<List<int>> result = employees.FindGroups();
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(this.CompareGroup(new int[] { 0, 1, 2, 3 }, result[0]));
        }

        private bool CompareGroup(int[] expected, List<int> actual)
        {
            int[] actualArray = actual.ToArray();
            Array.Sort(actualArray);
            Array.Sort(expected);

            if (actualArray.Length != expected.Length)
            {
                return false;
            }

            for (int i = 0; i < actualArray.Length; i++)
            {
                if (actualArray[i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
