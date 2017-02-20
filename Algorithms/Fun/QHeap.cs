using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    public class QHeap
    {
        private int[] heap;
        private Dictionary<int, int> valueLocations;
        private int endPosition;

        public QHeap(int n)
        {
            this.heap = new int[n + 1];
            this.endPosition = 0;
            this.valueLocations = new Dictionary<int, int>();
        }

        public void Add(int value)
        {
            this.endPosition++;
            this.heap[this.endPosition] = value;
            this.valueLocations[value] = this.endPosition;
            this.Swim(this.endPosition);
        }

        public int GetMin()
        {
            return this.heap[1];
        }

        public void Remove(int value)
        {
            int location = this.valueLocations[value];
            this.Swap(location, this.endPosition);
            this.endPosition--;

            if (location <= this.endPosition)
            {
                this.Swim(location);
                this.Sink(location);
            }
        }

        private void Swim(int startPosition)
        {
            int currentPosition = startPosition;
            int nextPosition;

            while (currentPosition > 1)
            {
                nextPosition = currentPosition / 2;

                if (nextPosition >=1 && this.heap[nextPosition] > this.heap[currentPosition])
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

        private void Sink(int startPosition)
        {
            int currentPosition = startPosition;
            int nextPosition;
            int tryPosition;

            while (currentPosition <= this.endPosition)
            {
                nextPosition = currentPosition;

                for (tryPosition = currentPosition * 2; tryPosition <= currentPosition * 2 + 1; tryPosition++)
                {
                    if (tryPosition <= this.endPosition && this.heap[nextPosition] >= this.heap[tryPosition])
                    {
                        nextPosition = tryPosition;
                    }
                }

                if (nextPosition != currentPosition)
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

        private void Swap(int p1, int p2)
        {
            int v1 = this.heap[p1];
            int v2 = this.heap[p2];

            this.heap[p1] = v2;
            this.heap[p2] = v1;

            this.valueLocations[v1] = p2;
            this.valueLocations[v2] = p1;
        }
    }
}
