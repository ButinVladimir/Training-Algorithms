using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Fun_15
{
    public static class SoccerField
    {
        public static int Solve(int ballRadius, int fieldLength, int fieldWidth)
        {
            int fitLength = fieldLength / ballRadius;
            int fitWidth = fieldWidth / ballRadius;

            return fitLength * fitWidth;
        }
    }

    [TestClass]
    public class SoccerFieldTest
    {
        [TestMethod]
        public void NotFitBothDimensions()
        {
            Assert.AreEqual(0, SoccerField.Solve(5, 4, 3));
        }

        [TestMethod]
        public void NotFitOneDimension()
        {
            Assert.AreEqual(0, SoccerField.Solve(5, 6, 3));
            Assert.AreEqual(0, SoccerField.Solve(5, 2, 20));
        }

        [TestMethod]
        public void FitWithoutSpace()
        {
            Assert.AreEqual(6, SoccerField.Solve(6, 12, 18));
            Assert.AreEqual(24, SoccerField.Solve(3, 12, 18));
        }

        [TestMethod]
        public void FitWithSpace()
        {
            Assert.AreEqual(6, SoccerField.Solve(6, 14, 21));
            Assert.AreEqual(6, SoccerField.Solve(6, 12, 21));
            Assert.AreEqual(6, SoccerField.Solve(6, 14, 18));
            Assert.AreEqual(24, SoccerField.Solve(3, 13, 19));
            Assert.AreEqual(24, SoccerField.Solve(3, 12, 19));
            Assert.AreEqual(24, SoccerField.Solve(3, 13, 18));
        }
    }
}
