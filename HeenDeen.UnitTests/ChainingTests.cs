using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeenDeen.UnitTests
{
    [TestClass]
    public class ChainingTests
    {
        [TestMethod]
        public void Fluently_sets_up_a_single_type()
        {
    Person person = 
        new HeenDeen<Person>()
        .Init(e => e.Forename).AsA().Constant("Paul")
        .Init(e => e.Surname).AsA().Constant("Aldred-Bann")
        .Init(e => e.DateOfBirth).AsA().Constant(DateTime.Parse("25 June 1982"))
        .DoIt();

            Assert.AreEqual("Paul", person.Forename);
            Assert.AreEqual("Aldred-Bann", person.Surname);
            Assert.AreEqual(new DateTime(1982, 6, 25), person.DateOfBirth);
        }

        [TestMethod]
        public void Fluently_sets_up_a_collection_of_type()
        {
    ICollection<Person> collection = 
        new HeenDeenCollection<Person>()
        .GiveMe(10)
        .ConfigureWith(config => {
            config
                .Init(e => e.Forename).AsA().Constant("Paul")
                .Init(e => e.Surname).AsA().Constant("Aldred-Bann")
                .Init(e => e.DateOfBirth).AsA().Constant(DateTime.Parse("25 June 1982"));
        })
        .DoIt();

            Assert.IsTrue(collection.Count.Equals(10));
            CollectionAssert.AllItemsAreNotNull((ICollection)collection);
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)collection, typeof(Person));
        }
    }

    internal sealed class Person
    {
        internal string Forename { get; set; }
        internal string Surname { get; set; }
        internal DateTime DateOfBirth { get; set; }
    }
}
