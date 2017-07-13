using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_9
{
    public static class AggregatedNumber
    {
        public static bool Solve(string s)
        {
            for (int p1 = 0; p1 < s.Length - 1; p1++)
            {
                string s1 = s.Substring(0, p1 + 1);

                for (int p2 = p1 + 1; p2 < s.Length - 1; p2++)
                {
                    string s2 = s.Substring(p1 + 1, p2 - p1);

                    if (Check(s, p2 + 1, s1, s2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool Check(string s, int pos, string s1, string s2)
        {
            while (pos < s.Length)
            {
                string s3 = Sum(s1, s2);
                if (pos + s3.Length - 1 >= s.Length)
                {
                    return false;
                }

                string sb = s.Substring(pos, s3.Length);

                if (!sb.Equals(s3))
                {
                    return false;
                }

                pos += s3.Length;

                s1 = s2;
                s2 = s3;
            }

            return true;
        }

        private static string Sum(string s1, string s2)
        {
            StringBuilder sb = new StringBuilder();

            string rs1 = sb.Clear().Append(s1.Reverse().ToArray<char>()).ToString();
            string rs2 = sb.Clear().Append(s2.Reverse().ToArray<char>()).ToString();

            sb.Clear();

            int d = 0;
            for (int i = 0; i < rs1.Length || i < rs2.Length || d > 0; i++)
            {
                if (i < rs1.Length)
                {
                    d += rs1[i] - '0';
                }

                if (i < rs2.Length)
                {
                    d += rs2[i] - '0';
                }

                sb.Append((char)((d % 10) + '0'));
                d /= 10;
            }

            string buffer = sb.ToString();

            return sb.Clear().Append(buffer.Reverse().ToArray<char>()).ToString();
        }
    }

    [TestClass]
    public class AggregatedNumberTest
    {
        [TestMethod]
        public void Test1()
        {
            Assert.IsTrue(AggregatedNumber.Solve("112358"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.IsTrue(AggregatedNumber.Solve("122436"));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.IsTrue(AggregatedNumber.Solve("1299111210"));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.IsTrue(AggregatedNumber.Solve("112112224"));
        }

        [TestMethod]
        public void Test5()
        {
            Assert.IsFalse(AggregatedNumber.Solve("125"));
        }

        [TestMethod]
        public void Test6()
        {
            Assert.IsFalse(AggregatedNumber.Solve("12"));
        }

        [TestMethod]
        public void Test7()
        {
            Assert.IsTrue(AggregatedNumber.Solve("22123"));
        }

        [TestMethod]
        public void Test8()
        {
            Assert.IsFalse(AggregatedNumber.Solve("221242212422124"));
        }

    }
}
