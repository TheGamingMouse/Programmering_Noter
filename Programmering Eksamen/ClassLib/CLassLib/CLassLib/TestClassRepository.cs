using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLassLib
{
    public class TestClassRepository
    {
        private List<TestClass> tClasses = new List<TestClass>(); //Creates list
        private int _nextId = 0; //Creates a value, that can later be used to assign Id to objects when added to the list
        public TestClassRepository(bool mockData = true) //Adds objects into the list
        {
            if (mockData)
            {
                Populate();
            }
        }

        public void Populate()
        {
            tClasses.Clear();
            tClasses.Add(new TestClass { Id = 1, InStock = 1237, Title = "Test1", Year = 1996 });
            tClasses.Add(new TestClass { Id = 2, InStock = 1235, Title = "Test2", Year = 2007 });
            tClasses.Add(new TestClass { Id = 3, InStock = 4567, Title = "Test3", Year = 2003 });
            tClasses.Add(new TestClass { Id = 4, InStock = 2374, Title = "Test4", Year = 2018 });
            tClasses.Add(new TestClass { Id = 5, InStock = 4432, Title = "Test5", Year = 2012 });
            tClasses.Add(new TestClass { Id = 6, InStock = 2000 });

            _nextId = 7;
        }

        public IEnumerable<TestClass> Get()
        {
            //Returns a list of all objects

            IEnumerable<TestClass> result = new List<TestClass>(tClasses);

            return result;
        }

        public TestClass? GetById(int id)
        {
            //Returns the object with the corresponding Id

            return tClasses.Find(t => t.Id == id);
        }

        public TestClass Add(TestClass tClass)
        {
            //Creates an Id for the object, validates it, and then adds it to the list

            tClass.Id = _nextId++;
            tClass.Validate();

            tClasses.Add(tClass);

            return tClass;
        }

        public TestClass Update(int id, TestClass values)
        {
            //Validates the new values, (not validating Id, as that can cause issues) then updating a specific object with the new values

            values.ValidateNoId();
            TestClass? tClass = GetById(id);

            if (tClass == null)
            {
                return null;
            }

            tClass.Title = values.Title;
            tClass.Year = values.Year;
            tClass.InStock = values.InStock;

            return tClass;
        }

        public TestClass Delete(int id)
        {
            //Finds the object, then removes it

            TestClass? tClass = GetById(id);

            if (tClass == null )
            {
                return null;
            }

            tClasses.Remove(tClass);
            return tClass;
        }

        public IEnumerable<TestClass> GetLowStock(int stockLevel)
        {
            //Finds all objects where the stocklevel is bellow a specified point

            return tClasses.FindAll(t => stockLevel > t.InStock);
        }
    }
}
