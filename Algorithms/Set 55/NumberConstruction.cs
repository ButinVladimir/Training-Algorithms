using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_55
{
    internal class RemainderState
    {
        public const int START_REMAINDER = -1;

        public int Remainder { get; set; }
        public int Distance { get; set; }
        public int Digit { get; set; }
        public RemainderState Previous { get; set; }

        public RemainderState(int remainder, int distance, int digit, RemainderState previous)
        {
            this.Remainder = remainder;
            this.Distance = distance;
            this.Digit = digit;
            this.Previous = previous;
        }

        public System.Collections.Generic.IEnumerable<RemainderState> Visit(int a)
        {
            int product = this.Remainder, r;
            if (product == START_REMAINDER)
            {
                product = 0;
            }

            for (int i = 0; i < 10; i++)
            {
                r = product % 10;
                if (r == 3 || r == 5 || r == 7)
                {
                    yield return new RemainderState(product / 10, this.Distance + 1, r, this);
                }
                product += a;
            }
        }
    }

    class NumberConstruction
    {
        public static String Construct(int a)
        {
            Dictionary<int, RemainderState> states = new Dictionary<int, RemainderState>();
            SortedSet<int> queueRemainders = new SortedSet<int>();
            Queue<int> queue = new Queue<int>();

            RemainderState currentState = new RemainderState(RemainderState.START_REMAINDER, 0, 0, null), oldState;
            queue.Enqueue(currentState.Remainder);
            states[currentState.Remainder] = currentState;
            queueRemainders.Add(currentState.Remainder);

            while (queue.Count > 0)
            {
                currentState = states[queue.Dequeue()];
                queueRemainders.Remove(currentState.Remainder);

                foreach (RemainderState newState in currentState.Visit(a))
                {
                    if (states.TryGetValue(newState.Remainder, out oldState))
                    {
                        if (oldState.Distance > newState.Distance || oldState.Distance == newState.Distance && oldState.Digit > newState.Digit)
                        {
                            states[newState.Remainder] = newState;
                        }
                    }
                    else
                    {
                        states[newState.Remainder] = newState;
                        queue.Enqueue(newState.Remainder);
                    }
                }
            }

            if (states.TryGetValue(0, out currentState))
            {
                StringBuilder sb = new StringBuilder();
                while (currentState.Remainder != RemainderState.START_REMAINDER)
                {
                    sb.Append(currentState.Digit);
                    currentState = currentState.Previous;
                }

                return sb.ToString();
            }
            return "Nope";
        }
    }
}
