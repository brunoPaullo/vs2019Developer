using System;
using System.Collections.Generic;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class InvoiceUnitTest
    {
        [TestMethod]
        public void InsertTXLocal()
        {
            var invoiceDa = new InvoiceDA();
            var invoice = new Invoice()
            {
                CustomerId = 60,
                BillingCountry = "Lima",
                BillingAddress = "Los Alamos 233",
                BillingCity = "Lima",
                BillingPostalCode = "Lima32",
                BillingState = "Lima",
                InvoiceDate = DateTime.Now,
                Total = 100
            };
            invoice.InvoiceLines = new List<InvoiceLine>
            {
                new InvoiceLine()
                {
                    TrackId = 1,
                    Quantity = 1,
                    UnitPrice = 50
                },

                 new InvoiceLine()
                {
                    TrackId = 2,
                    Quantity = 1,
                    UnitPrice = 50
                }
            };

            var result = invoiceDa.InsertTXLocal(invoice);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void InsertTXDist()
        {
            var invoiceDa = new InvoiceDA();
            var invoice = new Invoice()
            {
                CustomerId = 60,
                BillingCountry = "Lima",
                BillingAddress = "Los Alamos 233",
                BillingCity = "Lima",
                BillingPostalCode = "Lima32",
                BillingState = "Lima",
                InvoiceDate = DateTime.Now,
                Total = 200
            };
            invoice.InvoiceLines = new List<InvoiceLine>
            {
                new InvoiceLine()
                {
                    TrackId = 1,
                    Quantity = 1,
                    UnitPrice = 50
                },

                 new InvoiceLine()
                {
                    TrackId = 2,
                    Quantity = 3,
                    UnitPrice = 50
                }
            };

            var result = invoiceDa.InsertTXLocal(invoice);
            Assert.IsTrue(result > 0);
        }
    }
}
