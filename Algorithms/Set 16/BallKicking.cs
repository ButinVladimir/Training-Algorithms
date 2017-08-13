using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_16
{
    public static class BallKicking
    {
        public static int Solve(string input, int pos)
        {
            if (input[pos] == ' ')
            {
                return 0;
            }

            int result = 1;
            bool goLeft = input[pos] == '<';
            int left = pos;
            int right = pos;
            
            if (goLeft)
            {
                right = pos + 1;
            }
            else
            {
                left = pos - 1;
            }

            while (true)
            {
                if (goLeft)
                {
                    while (left >= 0 && input[left] != '>')
                    {
                        left--;
                    }

                    if (left < 0)
                    {
                        break;
                    }
                    else
                    {
                        left--;
                    }
                }
                else
                {
                    while (right < input.Length && input[right] != '<')
                    {
                        right++;
                    }

                    if (right >=input.Length)
                    {
                        break;
                    }
                    else
                    {
                        right++;
                    }
                }

                result++;
                goLeft = !goLeft;
            }

            return result;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class BallKickingTest
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(1, BallKicking.Solve("  << >>", 3));
            Assert.AreEqual(2, BallKicking.Solve("  <><>>", 3));
            Assert.AreEqual(4, BallKicking.Solve("  >><><", 3));
        }
    }
}
