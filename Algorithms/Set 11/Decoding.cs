using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_11
{
    public class Decoding
    {
        private Dictionary<int, bool> states;
        private List<string> result;
        private LinkedList<char> chars;

        public string S { get; set; }

        public string[] Solve()
        {
            this.result = new List<string>();

            this.states = new Dictionary<int, bool>();
            this.chars = new LinkedList<char>();

            this.Step(0);

            return this.result.ToArray();
        }

        private bool Step(int position)
        {
            if (position >= this.S.Length)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in this.chars)
                {
                    sb.Append(c);
                }
                this.result.Add(sb.ToString());

                return true;
            }

            bool contained = false;
            bool haveValue = states.TryGetValue(position, out contained);
            if (haveValue && !contained)
            {
                return false;
            }

            string numberString = this.S.Substring(position, 1);
            int number = 0;

            if (int.TryParse(numberString, out number) && number > 0)
            {
                this.chars.AddLast((char)('a' + (number - 1)));
                contained = this.Step(position + 1) || contained;
                this.chars.RemoveLast();
            }

            if (position < this.S.Length - 1)
            {
                numberString = this.S.Substring(position, 2);

                if (int.TryParse(numberString, out number) && number >= 10 && number <= 26)
                {
                    this.chars.AddLast((char)('a' + (number - 1)));
                    contained = this.Step(position + 2) || contained;
                    this.chars.RemoveLast();
                }
            }

            if (!haveValue)
            {
                states[position] = contained;
            }

            return contained;
        }
    }

    [TestClass]
    public class DecodingTest
    {
        [TestMethod]
        public void Test()
        {
            Decoding decoding = new Decoding() { S = "1123" };

            string[] result = decoding.Solve();
            string[] expected =
            {
                "aabc",
                "aaw",
                "alc",
                "kbc",
                "kw"
            };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
