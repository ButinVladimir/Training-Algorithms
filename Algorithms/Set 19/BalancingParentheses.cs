using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_19
{
    public static class BalancingParentheses
    {
        public static int Solve(string s)
        {
            int balance = 0;
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    balance++;
                }
                else
                {
                    balance--;

                    if (balance < 0)
                    {
                        result -= balance;
                        balance = 0;
                    }
                }
            }

            return result + balance;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class BalancingParenthesesTest
    {
        [TestMethod]
        public void Test1()
        {
            string s = "(())()";

            Assert.AreEqual(0, BalancingParentheses.Solve(s));
        }

        [TestMethod]
        public void Test2()
        {
            string s = ")))((";

            Assert.AreEqual(5, BalancingParentheses.Solve(s));
        }

        [TestMethod]
        public void Test3()
        {
            string s = "(()))(";

            Assert.AreEqual(2, BalancingParentheses.Solve(s));
        }
    }
}
