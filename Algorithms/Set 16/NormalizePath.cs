using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_16
{
    public static class NormalizePath
    {
        public static string Solve(string input)
        {
            var words = input.Split('\\').Where(s => !string.IsNullOrEmpty(s));
            LinkedList<string> queue = new LinkedList<string>();

            foreach (string word in words)
            {
                if (word.Equals(".."))
                {
                    queue.RemoveLast();
                }
                else
                {
                    queue.AddLast(word);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string word in queue)
            {
                sb.Append('\\');
                sb.Append(word);
            }

            return sb.ToString();
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class NormalizePathTest
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(@"\a\foo.txt", NormalizePath.Solve(@"\a\b\..\foo.txt"));
            Assert.AreEqual(@"\a\foo.txt", NormalizePath.Solve(@"\a\\\\b\..\foo.txt"));
            Assert.AreEqual(@"\foo.txt", NormalizePath.Solve(@"\\\\\b\..\foo.txt"));
        }
    }
}
