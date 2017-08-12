using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_17
{
    public static class SortArray
    {
        public static void Sort(int[] a, int k)
        {
            Heap heap = new Heap();
            for (int i = 0; i <= k && i < a.Length; i++)
            {
                heap.Push(a[i]);
            }

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = heap.Peek();
                heap.Pop();
                if (i + k + 1 < a.Length)
                {
                    heap.Push(a[i + k + 1]);
                }
            }
        }

        private class Heap
        {
            private int[] heap;
            private int position;

            public Heap()
            {
                this.heap = new int[10000];
                this.position = 0;
            }

            public int Peek()
            {
                return this.heap[1];
            }

            public void Push(int value)
            {
                this.position++;
                this.heap[this.position] = value;

                int currentPosition = this.position;
                int nextPosition;
                while (currentPosition > 1)
                {
                    nextPosition = currentPosition / 2;

                    if (this.heap[currentPosition] < this.heap[nextPosition])
                    {
                        this.Swap(currentPosition, nextPosition);
                        currentPosition = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public void Pop()
            {
                this.heap[1] = this.heap[this.position];
                this.position--;

                int currentPosition = 1;
                int nextPosition;
                int tryPosition;

                while (currentPosition < this.position)
                {
                    nextPosition = currentPosition;

                    for (tryPosition = 2 * currentPosition; tryPosition <= 2 * currentPosition + 1 && tryPosition <= this.position; tryPosition++)
                    {
                        if (this.heap[tryPosition] < this.heap[nextPosition])
                        {
                            nextPosition = tryPosition;
                        }
                    }

                    if (nextPosition != currentPosition)
                    {
                        this.Swap(nextPosition, currentPosition);
                        currentPosition = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Swap(int i1, int i2)
            {
                int buffer = this.heap[i1];
                this.heap[i1] = this.heap[i2];
                this.heap[i2] = buffer;
            }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class SortArrayTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = new int[] { 2, 1, 5, 4, 3 };

            SortArray.Sort(a, 2);
            CollectionAssert.AreEquivalent(new int[] { 1, 2, 3, 4, 5 }, a);
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { 5, 4, 3, 2, 1 };

            SortArray.Sort(a, 4);
            CollectionAssert.AreEquivalent(new int[] { 1, 2, 3, 4, 5 }, a);
        }
    }
}
