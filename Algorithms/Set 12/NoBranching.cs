using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_12
{
    public static class NoBranching
    {
        public static string Solve(int value)
        {
            StringBuilder sb = new StringBuilder();

            int a = value | -value;
            sb.AppendLine(Convert.ToString(value, 2));
            sb.AppendLine(Convert.ToString(-value, 2));
            sb.AppendLine(Convert.ToString(~value, 2));
            sb.AppendLine(Convert.ToString(a, 2));

            int b = ~a;
            sb.AppendLine(Convert.ToString(b, 2));

            int c = b >> 31;
            sb.AppendLine(Convert.ToString(c, 2));

            int d = c & 1;
            sb.AppendLine(Convert.ToString(d, 2));

            int e = value |     ~value;
            sb.AppendLine(Convert.ToString(e, 2));

            Console.WriteLine(sb.ToString());

            return (d + e).ToString("X8");
        }
    }

    [TestClass]
    public class NoBranchingTest
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("FFFFFFFF", NoBranching.Solve(3));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("FFFFFFFF", NoBranching.Solve(-21));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("00000000", NoBranching.Solve(0));
        }
    }
}
