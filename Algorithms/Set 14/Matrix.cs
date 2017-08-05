using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_14
{
    public static class Matrix
    {
        public static int[,] Solve(int[,] input)
        {
            int n = input.GetLength(0);
            int m = input.GetLength(1);

            int[,] output = new int[n, m];
            bool[] nullX = new bool[n];
            bool[] nullY = new bool[m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (input[i, j] == 0)
                    {
                        nullX[i] = true;
                        nullY[j] = true;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    output[i, j] = (nullX[i] || nullY[j]) ? 0 : input[i, j];
                }
            }

            return output;
        }
    }

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void Test()
        {
            int[,] input = new int[,]
            {
                { 1, 0, 1, 1, 0 },
                { 0, 1, 1, 1, 0 },
                { 1, 1, 1, 1, 1 },
                { 1, 0, 1, 1, 1 },
                { 1, 1, 1, 1, 1 }
            };

            int[,] expected = new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0 },
            };

            int[,] output = Matrix.Solve(input);
            CollectionAssert.AreEquivalent(expected, output);
        }
    }
}
