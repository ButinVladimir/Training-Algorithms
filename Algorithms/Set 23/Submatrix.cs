using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_23
{
    public class Submatrix
    {
        public static int Solve(bool[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] height = new int[m];
            int[] linkLeft = new int[m];
            int[] linkRight = new int[m];
            int max = 0;

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < m; column++)
                {
                    linkLeft[column] = column - 1;
                    linkRight[column] = column + 1;

                    if (matrix[row, column])
                    {
                        height[column]++;
                    }
                    else
                    {
                        height[column] = 0;
                    }
                }

                for (int column = 0; column < m; column++)
                {
                    while (linkLeft[column] >= 0 && height[linkLeft[column]] >= height[column])
                    {
                        linkLeft[column] = linkLeft[linkLeft[column]];
                    }
                }

                for (int column = m - 1; column >= 0; column--)
                {
                    while (linkRight[column] < m && height[linkRight[column]] >= height[column])
                    {
                        linkRight[column] = linkRight[linkRight[column]];
                    }
                }

                for (int column = 0; column < m; column++)
                {
                    max = Math.Max(max, height[column] * (linkRight[column] - linkLeft[column] - 1));
                }
            }

            return max;
        }

        public static int SolveBrute(bool[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] height = new int[m];
            int max = 0;

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < m; column++)
                {
                    if (matrix[row, column])
                    {
                        height[column]++;
                    }
                    else
                    {
                        height[column] = 0;
                    }
                }

                for (int column = 0; column < m; column++)
                {
                    int linkLeft, linkRight;
                    for (linkLeft = column; linkLeft >= 0 && height[linkLeft] >= height[column]; linkLeft--) ;
                    for (linkRight = column; linkRight < m && height[linkRight] >= height[column]; linkRight++) ;

                    max = Math.Max(max, height[column] * (linkRight - linkLeft - 1));
                }
            }

            return max;
        }
    }

    [TestClass]
    public class SubmatrixTest
    {
        [TestMethod]
        public void Test1()
        {
            bool[,] matrix = new bool[,]
            {
                { true, false, false }
            };

            Assert.AreEqual(Submatrix.SolveBrute(matrix), Submatrix.Solve(matrix));
        }

        [TestMethod]
        public void Test2()
        {
            bool[,] matrix = new bool[,]
            {
                { true, true, true },
                { true, false, false },
            };

            Assert.AreEqual(3, Submatrix.Solve(matrix));
            Assert.AreEqual(Submatrix.SolveBrute(matrix), Submatrix.Solve(matrix));
        }

        [TestMethod]
        public void Test3()
        {
            bool[,] matrix = new bool[,]
            {
                { false, false, true, false, false },
                { false, true, true, true, false },
                { true, true, true, true, true },
            };

            Assert.AreEqual(6, Submatrix.Solve(matrix));
            Assert.AreEqual(Submatrix.SolveBrute(matrix), Submatrix.Solve(matrix));
        }
    }
}
