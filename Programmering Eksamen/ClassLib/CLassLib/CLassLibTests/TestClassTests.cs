using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLassLib.Tests
{
    [TestClass()]
    public class TestClassTests
    {
        //Creates objects that are used in testing the validation methods of the TestClass

        private readonly TestClass validTest = new TestClass() { Id = 1, InStock = 1523, Title = "TestGrey", Year = 1998 };
        private readonly TestClass invalidIdTest = new TestClass() { Id = 0, InStock = 1523, Title = "TestGrey", Year = 1998 };
        private readonly TestClass invalidInStockTest = new TestClass() { Id = 1, InStock = -1523, Title = "TestGrey", Year = 1998 };
        private readonly TestClass invalidTitleTest = new TestClass() { Id = 1, InStock = 1523, Title = "X", Year = 1998 };
        private readonly TestClass invalidTitleNullTest = new TestClass() { Id = 1, InStock = 1523, Title = null, Year = 1998 };
        private readonly TestClass invalidYearToLowTest = new TestClass() { Id = 1, InStock = 1523, Title = "TestGrey", Year = 1989 };
        private readonly TestClass invalidYearToHighTest = new TestClass() { Id = 1, InStock = 1523, Title = "TestGrey", Year = 2021 };

        [TestMethod()]
        public void ValidateTest()
        {
            //Tests the validation methods

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidIdTest.Validate() );
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidInStockTest.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidTitleTest.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => invalidTitleNullTest.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidYearToLowTest.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidYearToHighTest.Validate());

            validTest.Validate();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //Tests the ToString() override

            Assert.AreEqual("Id=1, Title=TestGrey, Year=1998, InStock=1523", validTest.ToString());
        }
    }
}