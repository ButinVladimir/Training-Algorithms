using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_8
{
    public class KPalindrome
    {
        public string S { get; set; }
        public int K { get; set; }

        private Dictionary<State, bool> intermediateResults;

        public bool Solve()
        {
            this.intermediateResults = new Dictionary<State, bool>();

            return this.Solve(0, this.S.Length - 1, this.K);
        }

        private bool Solve(int start, int end, int k)
        {
            if (start >= end)
            {
                return true;
            }

            State state = new State() { Start = start, End = end, K = k };
            bool result;

            if (this.intermediateResults.TryGetValue(state, out result))
            {
                return result;
            }

            if (k == 0)
            {
                result = this.S[start] == this.S[end] ? this.Solve(start + 1, end - 1, k) : false;
            }
            else
            {
                if (this.S[start] == this.S[end])
                {
                    result = this.Solve(start + 1, end - 1, k);
                }
                else
                {
                    result = this.Solve(start + 1, end, k - 1) || this.Solve(start, end - 1, k - 1);
                }
            }

            this.intermediateResults[state] = result;

            return result;
        }

        private class State : IComparable<State>
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int K { get; set; }

            int IComparable<State>.CompareTo(State other)
            {
                int result = this.Start.CompareTo(other.Start);

                if (result == 0)
                {
                    result = this.End.CompareTo(other.End);
                }

                if (result == 0)
                {
                    result = this.K.CompareTo(other.K);
                }

                return result;
            }
        }
    }

    [TestClass]
    public class KPalindromeTest
    {
        [TestMethod]
        public void Test1()
        {
            KPalindrome kp = new KPalindrome()
            {
                S = "abxa",
                K = 1
            };

            Assert.IsTrue(kp.Solve());
        }

        [TestMethod]
        public void Test2()
        {
            KPalindrome kp = new KPalindrome()
            {
                S = "abdxa",
                K = 1
            };

            Assert.IsFalse(kp.Solve());
        }

        [TestMethod]
        public void Test3()
        {
            KPalindrome kp = new KPalindrome()
            {
                S = "abbbba",
                K = 20
            };

            Assert.IsTrue(kp.Solve());
        }

        [TestMethod]
        public void Test4()
        {
            KPalindrome kp = new KPalindrome()
            {
                S = "cbdxa",
                K = 1
            };

            Assert.IsFalse(kp.Solve());
        }

        [TestMethod]
        public void Test5()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('a', 20000);
            for (int i = 0; i < 15; i++)
            {
                sb[25 * i + 20] = 'b';
                sb[18000 - 3 * i] = 'b';
            }


            KPalindrome kp = new KPalindrome()
            {
                S = sb.ToString(),
                K = 17
            };

            Assert.IsFalse(kp.Solve());
        }
    }
}
