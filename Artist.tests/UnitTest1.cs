using System;
using Core.Entities;
using Core.Services.ArtWorkServices;
using Core.Services.DbServices;
using NUnit.Framework;

namespace Artist.tests
{
    public class Tests
    {
        private ArtworkSqlBuilder _table;

        [SetUp]
        public void Setup()
        {
            _table = new ArtworkSqlBuilder();
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine(_table.GetSqlProperties(new ArtWork
            {
                ShippingCost = 50,
                Username = "Brian",
                HeightInches = 10,
                WidthInches = 30,
                DateFinished = new DateTime(2020, 9, 23),
                IsCommission = true,
                IsPaymentCollected = false
            }));
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine(_table.GetSqlValues(new ArtWork
            {
                ShippingCost = 50,
                Username = "Brian",
                HeightInches = 10,
                WidthInches = 30,
                DateFinished = new DateTime(2020, 9, 23),
                IsCommission = true,
                IsPaymentCollected = false
            }));
        }

        [Test]
        public void Test3()
        {
            Console.WriteLine(_table.GetSqlSet(new ArtWork
            {
                ShippingCost = 50,
                Username = "Brian",
                HeightInches = 10,
                WidthInches = 30,
                DateFinished = new DateTime(2020, 9, 23),
                IsCommission = true,
                IsPaymentCollected = false
            }));
        }

        // [Test]
        // public void Test4()
        // {
        //     var edit = new EditArtWork();
        //     Console.WriteLine(edit.Edit(new ArtWork
        //         {
        //             ShippingCost = 50,
        //             Username = "Brian",
        //             HeightInches = 10,
        //             WidthInches = 30,
        //             DateFinished = new DateTime(2020, 9, 23),
        //             IsCommission = true,
        //             IsPaymentCollected = false
        //         }
        //     ));
        // }
    }
}