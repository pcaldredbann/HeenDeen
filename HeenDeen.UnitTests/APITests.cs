using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeenDeen.UnitTests
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void Can_fluently_generate_objects()
        {
            ICollection<Person> result = 
                new HeenDeen<Person>()
                    .MakeMe(10)
                    .Init(e => e.Forename).AsA().Value("Paul")
                    .Init(e => e.Surname).AsA().Value("Aldred-Bann")
                    .Init(e => e.DateOfBirth).AsA().Value(new DateTime(1982, 6, 25))
                    .Compile();

            Assert.IsTrue(result.Count.Equals(10));
            CollectionAssert.AllItemsAreInstancesOfType(result as ICollection, typeof(Person));
        }
    }

    internal sealed class Person
    {
        internal string Forename { get; set; }
        internal string Surname { get; set; }
        internal DateTime DateOfBirth { get; set; }
    }
}
