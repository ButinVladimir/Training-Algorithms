using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_39
{
    public class Subsequence
    {
        public static List<int> Solve(int[] array)
        {
            List<int> result = new List<int>();
            int n = array.Length;

            SequenceElement[] elements = new SequenceElement[n];
            for (int i = n - 1; i >= 0; i--)
            {
                elements[i] = new SequenceElement();
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] > array[i] && elements[i].LengthUp < elements[j].LengthDown + 1)
                    {
                        elements[i].LengthUp = elements[j].LengthDown + 1;
                        elements[i].NextPositionUp = j;
                    }

                    if (array[j] < array[i] && elements[i].LengthDown < elements[j].LengthUp + 1)
                    {
                        elements[i].LengthDown = elements[j].LengthUp + 1;
                        elements[i].NextPositionDown = j;
                    }
                }
            }

            int start = 0;
            bool up = true;
            int length = 0;
            for (int i = 0; i < n; i++)
            {
                if (elements[i].LengthUp > length)
                {
                    length = elements[i].LengthUp;
                    up = true;
                    start = i;
                }

                if (elements[i].LengthDown > length)
                {
                    length = elements[i].LengthDown;
                    up = false;
                    start = i;
                }
            }

            while (start != -1)
            {
                result.Add(array[start]);
                if (up)
                {
                    start = elements[start].NextPositionUp;
                }
                else
                {
                    start = elements[start].NextPositionDown;
                }

                up = !up;
            }

            return result;
        }

        private class SequenceElement
        {
            public int LengthUp { get; set; }
            public int LengthDown { get; set; }
            public int NextPositionUp { get; set; }
            public int NextPositionDown { get; set; }

            public SequenceElement()
            {
                this.LengthDown = this.LengthUp = 1;
                this.NextPositionDown = this.NextPositionUp = -1;
            }
        }
    }
}
