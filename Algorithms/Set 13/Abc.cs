using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_13
{
    public static class Abc
    {
        enum State
        {
            NotStarted,
            OnA,
            OnB,
        };

        public static bool Solve(string s)
        {
            State state = State.NotStarted;
            for (int i=0;i<s.Length;i++)
            {
                switch (state)
                {
                    case State.NotStarted:
                        if (s[i] == 'a')
                        {
                            state = State.OnA;
                        }

                        break;
                    case State.OnA:
                        if (s[i] == 'a')
                        {
                            state = State.OnA;
                        }
                        else
                        if (s[i] == 'b')
                        {
                            state = State.OnB;
                        }
                        else
                        {
                            state = State.NotStarted;
                        }

                        break;
                    case State.OnB:
                        if (s[i]=='c')
                        {
                            return true;
                        }

                        break;
                }
            }

            return false;
        }
    }

    [TestClass]
    public class AbcTest
    {
        [TestMethod]
        public void Test1()
        {
            Assert.IsTrue(Abc.Solve("abc"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.IsTrue(Abc.Solve("sdfsdfsdfabsdfcvxxcrtrqwe"));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.IsTrue(Abc.Solve("aaaaaabggggggggcsssss"));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.IsFalse(Abc.Solve("affffvvvvvvbbbbbghghc"));
        }

        [TestMethod]
        public void Test5()
        {
            Assert.IsFalse(Abc.Solve("cvxcvxcvsdf"));
        }
    }
}
