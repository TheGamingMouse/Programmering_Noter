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
    public class TestClassRepositoryTests
    {
        private TestClassRepository _repo; //Creates a TestClassRepository object
        private readonly TestClass invalidTestClass = new() { Id = 0, InStock = -1, Title = "", Year = 2030 }; //Creates an invalid object, for testing purposes

        [TestInitialize()]
        public void Init()
        {
            //Adds objects to the _repo list
            _repo = new TestClassRepository();

            //_repo.Add(new TestClass { InStock = 1237, Title = "Test1", Year = 1996 });
            //_repo.Add(new TestClass { InStock = 1235, Title = "Test2", Year = 2007 });
            //_repo.Add(new TestClass { InStock = 4567, Title = "Test3", Year = 2003 });
            //_repo.Add(new TestClass { InStock = 2374, Title = "Test4", Year = 2018 });
            //_repo.Add(new TestClass { InStock = 4432, Title = "Test5", Year = 2012 });
            //_repo.Add(new TestClass { InStock = 2000 });
        }

        [TestMethod()]
        public void TestClassConstructorTest()
        {
            //Tests if the default constructor works correctly

            Assert.AreEqual("Test", _repo.GetById(6).Title);
        }

        [TestMethod()]
        public void GetTest()
        {
            //Tests if all objects are being returned in the list correctly

            IEnumerable<TestClass> tClasses = _repo.Get();
            Assert.IsNotNull(tClasses);

            Assert.AreEqual(6, tClasses.Count());
            Assert.AreEqual("Test1", tClasses.First().Title);
            Assert.AreEqual("Test", tClasses.Last().Title);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //Tests if the GetById() function is correctly finding the corresponding object

            Assert.IsNotNull(_repo.GetById(1));
            Assert.IsNull(_repo.GetById(10));
        }

        [TestMethod()]
        public void AddTest()
        {
            //Tests if the Add() function is correctly adding objects to the list

            TestClass tClass = new() { InStock = 1234, Title = "AddTest", Year = 1999 };

            Assert.AreEqual(7, _repo.Add(tClass).Id);
            Assert.AreEqual(7, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(invalidTestClass));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            //Tests if the Update() function is correctly updating objects in the list

            Assert.AreEqual(6, _repo.Get().Count());

            TestClass tClass = new() { InStock = 1256, Title = "UpdateTest", Year = 2000 };
            Assert.IsNull(_repo.Update(100, tClass));
            Assert.AreEqual(1, _repo.Update(1, tClass).Id);

            Assert.AreEqual(6, _repo.Get().Count());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Tests if the Delete() function is correctly deleting objects from the list

            Assert.IsNull(_repo.Delete(100));

            Assert.AreEqual(1, _repo.Delete(1).Id);
            Assert.AreEqual(5, _repo.Get().Count());
        }

        [TestMethod()]
        [DataRow(2000)]
        [DataRow(4500)]
        public void GetLowStockTest(int stockLevel)
        {
            //Tests if the GetLowStock() function is correctly finding the objects, in which the stocklevel is bellow the specified amount

            IEnumerable<TestClass> tClasses = _repo.GetLowStock(stockLevel);

            switch (stockLevel)
            {
                case 2000:
                    Assert.AreEqual(2, _repo.GetLowStock(stockLevel).Count());
                    break;
                case 4500:
                    Assert.AreEqual(5, _repo.GetLowStock(stockLevel).Count());
                    break;
            }
        }
    }
}