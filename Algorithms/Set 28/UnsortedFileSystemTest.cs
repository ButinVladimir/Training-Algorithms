using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    [TestClass]
    public class UnsortedFileSystemTest
    {
        [TestMethod]
        public void Test1()
        {
            UnsortedFileSystemQuery query = new UnsortedFileSystemQuery();
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 1, 3, 5, 10 }));
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 2, 4, 6, 8 }));
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 1, 1, 1 }));
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 11, 12, 13 }));

            //1 1 1 1 2 3 4 5 6 8 10 11 12 13

            Assert.AreEqual(1, query.GetKthValue(1));
            Assert.AreEqual(1, query.GetKthValue(4));
            Assert.AreEqual(2, query.GetKthValue(5));
            Assert.AreEqual(3, query.GetKthValue(6));
            Assert.AreEqual(6, query.GetKthValue(9));
            Assert.AreEqual(10, query.GetKthValue(11));
            Assert.AreEqual(12, query.GetKthValue(13));
            Assert.AreEqual(13, query.GetKthValue(14));
        }

        [TestMethod]
        public void Test2()
        {
            UnsortedFileSystemQuery query = new UnsortedFileSystemQuery();
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 7, 5, 5, 5 }));
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 5, 6, 5 }));
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 1 }));
            query.AddFileSystem(new UnsortedFileSystem(new int[] { 1050 }));

            //1 5 5 5 5 5 6 7 1050

            Assert.AreEqual(1, query.GetKthValue(1));
            Assert.AreEqual(5, query.GetKthValue(2));
            Assert.AreEqual(5, query.GetKthValue(3));
            Assert.AreEqual(5, query.GetKthValue(4));
            Assert.AreEqual(5, query.GetKthValue(5));
            Assert.AreEqual(5, query.GetKthValue(6));
            Assert.AreEqual(6, query.GetKthValue(7));
            Assert.AreEqual(7, query.GetKthValue(8));
            Assert.AreEqual(1050, query.GetKthValue(9));
        }
    }
}
