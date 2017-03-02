using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_32
{
    public class AndValues
    {
        private const int Bits = 32;
        private const int End = -1;

        public static List<int> Solve(int[] a)
        {
            int n = a.Length;
            BitArray[] bitArray = new BitArray[n];
            for (int i = 0; i < n; i++)
            {
                bitArray[i] = new BitArray(new int[] { a[i] });
            }

            int[,] predValues = new int[n, Bits];

            for (int j = 0; j < Bits; j++)
            {
                predValues[0, j] = bitArray[0][j] ? End : 0;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < Bits; j++)
                {
                    predValues[i, j] = bitArray[i][j] ? predValues[i - 1, j] : i;
                }
            }

            SortedSet<int> values = new SortedSet<int>();

            int position, value, pred;

            for (int start = 0; start < n; start++)
            {
                position = start;
                value = a[start];

                while (position != -1)
                {
                    values.Add(value);

                    pred = End;

                    for (int j = 0; j < Bits; j++)
                    {
                        if ((value & (1 << j)) > 0 && predValues[position, j] != position)
                        {
                            pred = Math.Max(pred, predValues[position, j]);
                        }
                    }

                    if (pred != End)
                    {
                        value = value & a[pred];
                    }

                    position = pred;
                }
            }

            return values.ToList();
        }
    }
}
