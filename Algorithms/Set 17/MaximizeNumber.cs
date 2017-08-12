using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_17
{
    public class MaximizeNumber
    {
        public int[] Number { get; set; }
        public int[] Replacement { get; set; }

        public void Replace()
        {
            Array.Sort(this.Replacement);
            Array.Reverse(this.Replacement);

            int posReplacement = 0;
            int posNumber = 0;

            while (posNumber < this.Number.Length && posReplacement < this.Replacement.Length)
            {
                if (this.Number[posNumber] < this.Replacement[posReplacement])
                {
                    this.Number[posNumber] = this.Replacement[posReplacement];
                    posNumber++;
                    posReplacement++;
                }
                else
                {
                    posNumber++;
                }
            }
        }
    }

    [TestClass]
    public class MaximizeNumberTest
    {
        [TestMethod]
        public void Test1()
        {
            MaximizeNumber mn = new MaximizeNumber()
            {
                Number = new int[] { 3, 1, 4, 5, 6 },
                Replacement = new int[] { 1, 9, 5, 2, 3 }
            };

            mn.Replace();

            CollectionAssert.AreEqual(new int[] { 9, 5, 4, 5, 6 }, mn.Number);
        }

        [TestMethod]
        public void Test2()
        {
            MaximizeNumber mn = new MaximizeNumber()
            {
                Number = new int[] { 1, 3, 4, 5, 6 },
                Replacement = new int[] { 1, 9, 5, 2, 3 }
            };

            mn.Replace();

            CollectionAssert.AreEqual(new int[] { 9, 5, 4, 5, 6 }, mn.Number);
        }
    }
}
