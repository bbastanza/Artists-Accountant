using System;
using Core.Entities;
using Core.Services.ArtWorkServices;
using NUnit.Framework;

namespace Artist.tests
{
    public class Tests
    {
        private ArtworkPropertyHash _table;

        [SetUp]
        public void Setup()
        {
            _table = new ArtworkPropertyHash();
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine(_table.GetSqlProperty(new ArtWork
            {
                ShippingCost = 50,
                Username = "Brian"
            }));
        }
    }
}