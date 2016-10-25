using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun.Pond
{
    class Pond
    {
        private class Stuff
        {
            public int Index { get; set; }

            public int Level { get; set; }

            public int MinHeight { get; set; }

            public Stuff(int index, int level, int minHeight)
            {
                this.Index = index;
                this.Level = level;
                this.MinHeight = minHeight;
            }
        }

        public static int MaxDepth(int[] heights)
        {
            Stack<Stuff> stack = new Stack<Stuff>();
            Stuff top;
            int maxHeight = heights[0], maxLocalHeight;
            int minHeight;
            int result = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(new Stuff(i, 0, heights[i]));
                    continue;
                }

                top = stack.First();
                if (heights[top.Index] >= heights[i])
                {
                    stack.Push(new Stuff(i, 0, heights[i]));
                }
                else 
                {
                    maxLocalHeight = heights[i];
                    if (maxHeight < maxLocalHeight)
                    {
                        maxLocalHeight = maxHeight;
                    }

                    minHeight = maxLocalHeight;
                    while (stack.Count > 0 && heights[top.Index] < maxLocalHeight)
                    {
                        if (top.MinHeight < minHeight)
                        {
                            minHeight = top.MinHeight;
                        }

                        stack.Pop();
                        if (stack.Count > 0)
                        {
                            top = stack.First();
                        }
                    }

                    if (stack.Count > 0)
                    {
                        if (top.MinHeight > minHeight)
                        {
                            top.MinHeight = minHeight;
                        }
                        if (top.Level < maxLocalHeight)
                        {
                            top.Level = maxLocalHeight;
                        }

                        if (top.Level - top.MinHeight > result)
                        {
                            result = top.Level - top.MinHeight;
                        }
                    }

                    stack.Push(new Stuff(i, 0, heights[i]));
                }

                if (heights[i] > maxHeight)
                {
                    maxHeight = heights[i];
                }
            }

            return result;
        }

        public static int Volume(int[] heights)
        {
            Stack<Stuff> stack = new Stack<Stuff>();
            Stuff top;
            int maxHeight = heights[0], maxLocalHeight;
            int minHeight;
            int result = 0;
            int index;
            int delta;

            for (int i = 0; i < heights.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(new Stuff(i, heights[i], heights[i]));
                    continue;
                }

                top = stack.First();
                if (heights[top.Index] >= heights[i])
                {
                    stack.Push(new Stuff(i, heights[i], heights[i]));
                }
                else
                {
                    maxLocalHeight = heights[i];
                    if (maxHeight < maxLocalHeight)
                    {
                        maxLocalHeight = maxHeight;
                    }

                    minHeight = maxLocalHeight;
                    index = i;
                    delta = 0;
                    while (stack.Count > 0 && heights[top.Index] < maxLocalHeight)
                    {
                        delta += (index - (top.Index)) * (maxLocalHeight - top.Level);

                        if (top.MinHeight < minHeight)
                        {
                            minHeight = top.MinHeight;
                        }

                        stack.Pop();
                        if (stack.Count > 0)
                        {
                            top = stack.First();
                        }
                    }

                    if (stack.Count > 0)
                    {
                        if (top.MinHeight > minHeight)
                        {
                            top.MinHeight = minHeight;
                        }
                        if (top.Level < maxLocalHeight)
                        {
                            top.Level = maxLocalHeight;
                        }

                        result += delta;
                    }

                    stack.Push(new Stuff(i, heights[i], heights[i]));
                }

                if (heights[i] > maxHeight)
                {
                    maxHeight = heights[i];
                }
            }

            return result;
        }

    }
}
