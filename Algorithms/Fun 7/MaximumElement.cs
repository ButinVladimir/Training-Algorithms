using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public class MaximumElement
    {
        private Stack<int> elementsStack = new Stack<int>();
        private Stack<int> maxStack = new Stack<int>();

        public void Push(int data)
        {
            int max = data;
            if (maxStack.Count > 0)
            {
                max = Math.Max(max, maxStack.Peek());
            }
                
            this.elementsStack.Push(data);
            this.maxStack.Push(max);
        }

        public void Pop()
        {
            this.elementsStack.Pop();
            this.maxStack.Pop();
        }

        public int Print()
        {
            return this.maxStack.Peek();
        }

    }
}
