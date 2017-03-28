using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    [TestClass]
    public class CustomQueueTest
    {
        const int N = 10;

        [TestMethod]
        public void Test()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            for (int i = 0; i < N; i++)
            {
                queue.Enqueue(i);
            }

            for (int i=0;i<N;i++)
            {
                Assert.AreEqual(i, queue.Peek());
                queue.Dequeue();
            }

            Assert.IsTrue(queue.IsEmpty());
        }
    }
}
