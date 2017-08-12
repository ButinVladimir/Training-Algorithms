using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_17
{
    public static class AvoidDuplicates
    {
        public static LinkedList<Node> Solve(LinkedList<Node> listA, LinkedList<Node> listB)
        {
            LinkedList<Node> result = new LinkedList<Node>();
            foreach (Node node in listA)
            {
                if (!result.Any(x => x.Equals(node)))
                {
                    result.AddLast(node);
                }
            }

            foreach (Node node in listB)
            {
                if (!result.Any(x => x.Equals(node)))
                {
                    result.AddLast(node);
                }
            }

            return result;
        }

        public class Node : IEquatable<Node>
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }

            public bool Equals(Node other)
            {
                return this.Name.Equals(other.Name) && this.Phone.Equals(other.Phone);
            }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class AvoidDuplicatesTest
    {
        [TestMethod]
        public void Test1()
        {
            LinkedList<AvoidDuplicates.Node> listA = new LinkedList<AvoidDuplicates.Node>();
            listA.AddLast(new AvoidDuplicates.Node() { Name = "studentA", Phone = "phoneA", Address = "" });
            listA.AddLast(new AvoidDuplicates.Node() { Name = "studentA", Phone = "phoneA", Address = "qu" });
            listA.AddLast(new AvoidDuplicates.Node() { Name = "studentA", Phone = "phoneB", Address = "quq" });
            listA.AddLast(new AvoidDuplicates.Node() { Name = "studentB", Phone = "phoneB", Address = "quq" });

            LinkedList<AvoidDuplicates.Node> listB = new LinkedList<AvoidDuplicates.Node>();
            listB.AddLast(new AvoidDuplicates.Node() { Name = "studentB", Phone = "phoneB", Address = "quq" });
            listB.AddLast(new AvoidDuplicates.Node() { Name = "studentC", Phone = "phoneD", Address = "duq" });

            LinkedList<AvoidDuplicates.Node> result = AvoidDuplicates.Solve(listA, listB);
            Assert.AreEqual(4, result.Count);
        }
    }
}
