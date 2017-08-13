using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_16
{
    public class DivideArray
    {
        public int[] A { get; set; }
        private int countLeft;
        private int countRight;
        private int sumLeft;
        private int sumRight;
        private int result;

        public int FindBrute()
        {
            this.countLeft = 0;
            this.countRight = 0;
            this.sumLeft = 0;
            this.sumRight = 0;
            this.result = this.A.Sum(x => Math.Abs(x));

            this.FindBrute(0);

            return this.result;
        }

        private void FindBrute(int pos)
        {
            if (Math.Abs(this.countLeft - this.countRight) > this.A.Length - pos + 1)
            {
                return;
            }

            if (pos == this.A.Length)
            {
                if (Math.Abs(this.countLeft - this.countRight) <= 1)
                {
                    this.result = Math.Min(result, Math.Abs(this.sumLeft - this.sumRight));
                }

                return;
            }

            this.countLeft++;
            this.sumLeft += this.A[pos];
            this.FindBrute(pos + 1);
            this.countLeft--;
            this.sumLeft -= this.A[pos];

            this.countRight++;
            this.sumRight += this.A[pos];
            this.FindBrute(pos + 1);
            this.countRight--;
            this.sumRight -= this.A[pos];
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class DivideArrayTest
    {
        [TestMethod]
        public void Test()
        {
            DivideArray da = new DivideArray()
            {
                A = new int[] { 1, 2, 3, 4, 5, 6 }
            };

            Assert.AreEqual(1, da.FindBrute());
        }

        [TestMethod]
        public void Test2()
        {
            DivideArray da = new DivideArray()
            {
                A = new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };

            Assert.AreEqual(0, da.FindBrute());
        }
    }
}
