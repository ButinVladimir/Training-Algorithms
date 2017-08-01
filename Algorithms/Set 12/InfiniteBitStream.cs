using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Algorithms.Set_12
{
    public interface IInfiniteBitStream
    {
        void AddValue(int bit);
        bool IsDivisibleByThree();
    }

    public class InfiniteBitStreamRight : IInfiniteBitStream
    {
        public int CurrentValue { get; private set; }

        public InfiniteBitStreamRight()
        {
            this.CurrentValue = 0;
        }

        public void AddValue(int bit)
        {
            this.CurrentValue = (this.CurrentValue * 2 + bit) % 3;
        }

        public bool IsDivisibleByThree()
        {
            return this.CurrentValue == 0;
        }
    }

    public class InfiniteBitStreamLeft : IInfiniteBitStream
    {
        public int Multiplier { get; private set; }
        public int CurrentValue { get; private set; }

        public InfiniteBitStreamLeft()
        {
            this.CurrentValue = 0;
            this.Multiplier = 1;
        }

        public void AddValue(int bit)
        {
            this.CurrentValue = (this.Multiplier * bit + this.CurrentValue) % 3;
            this.Multiplier = (this.Multiplier * 2) % 3;
        }

        public bool IsDivisibleByThree()
        {
            return this.CurrentValue == 0;
        }
    }

    [TestClass]
    public class InfiniteBitStreamTest
    {
        [TestMethod]
        public void Test1()
        {
            this.Test(5);
        }

        [TestMethod]
        public void Test2()
        {
            this.Test(6);
        }

        [TestMethod]
        public void Test3()
        {
            this.Test(18);
        }

        [TestMethod]
        public void Test4()
        {
            this.Test(3);
        }

        [TestMethod]
        public void Test5()
        {
            this.Test(10);
        }

        [TestMethod]
        public void Test6()
        {
            this.Test(7);
        }

        private void Test(int number)
        {
            string s = Convert.ToString(number, 2);
            InfiniteBitStreamRight bitRight = new InfiniteBitStreamRight();
            InfiniteBitStreamLeft bitLeft = new InfiniteBitStreamLeft();

            for (int i = 0; i < s.Length; i++)
            {
                bitRight.AddValue(s[i] == '1' ? 1 : 0);
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                bitLeft.AddValue(s[i] == '1' ? 1 : 0);
            }

            bool expected = number % 3 == 0;
            Assert.AreEqual(expected, bitLeft.IsDivisibleByThree());
            Assert.AreEqual(expected, bitRight.IsDivisibleByThree());
        }
    }
}
