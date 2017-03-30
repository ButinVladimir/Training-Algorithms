using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public interface ICustomQueue<T>
    {
        void Enqueue(T value);
        void Dequeue();
        T Peek();
        bool IsEmpty();
    }

    public class CustomQueue<T>: ICustomQueue<T>
    {
        private QueueNode<T> front;
        private QueueNode<T> back;

        public void Enqueue(T value)
        {
            QueueNode<T> node = new QueueNode<T>() { Value = value };

            if (this.front == null)
            {
                this.front = this.back = node;
            }
            else
            {
                this.back.Next = node;
                this.back = node;
            }
        }

        public void Dequeue()
        {
            if (!this.IsEmpty())
            {
                this.front = this.front.Next;

                if (this.front == null)
                {
                    this.back = null;
                }
            }
        }

        public T Peek()
        {
            if (this.front != null)
            {
                return this.front.Value;
            }

            throw new IndexOutOfRangeException("Queue is empty");
        }

        public bool IsEmpty()
        {
            return this.front == null;
        }

        private class QueueNode<P>
        {
            public P Value { get; set; }
            public QueueNode<P> Next { get; set; }
        }
    }
}
