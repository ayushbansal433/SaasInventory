using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace SaasInventory.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly SaasInventoryParser _sut;

        public UnitTest1()
        {
            _sut = new SaasInventoryParser();
        }

        [TestMethod]
        public void Should_Match_Count_For_Json()
        {
            var invntory = _sut.Products("", Directory.GetCurrentDirectory() + "\\test.json");
            Assert.AreEqual(invntory?.Products.Count, 2);
        }

        [TestMethod]
        public void Should_Return_Null_For_Invalid_FileType()
        {
            var invntory = _sut.Products("", Directory.GetCurrentDirectory() + "\\TextFile1.txt");
            Assert.IsNull(invntory);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void Should_Return_Exception_For_MissingFile()
        {
            var invntory = _sut.Products("", Directory.GetCurrentDirectory() + "\\TextF.json");
        }
    }
}