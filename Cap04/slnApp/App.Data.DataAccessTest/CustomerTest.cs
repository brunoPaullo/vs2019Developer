using App.Data.DataAccess;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class CustomerTest
    {
        private readonly CustomerDA da = new CustomerDA();

        [TestMethod]
        public void GetAll()
        {
            var customers = da.GetAll("");
            Assert.IsTrue(customers.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var customer = da.Get(60);
            Assert.IsTrue(customer.CustomerId > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var customer = new Customer()
            {
                FirstName = "Cliente Prueba",
                LastName="Apellido 1",
                Company="Cibertec",
                Address="Miraflores",
                City="Lima",
                State="Lima",
                Country="Peru",
                PostalCode="01",
                Email="prueba@gmail.com",

            };
            var customerId = da.Insert(customer);
            Assert.IsTrue(customerId > 0);
        }

        [TestMethod]
        public void Update()
        {
            var customer = new Customer()
            {
                CustomerId = 61,
                FirstName = "Cliente Prueba2",
                LastName = "Apellido2",
                Email= "prueba@gmail.com"
            };
            var result = da.Update(customer);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete()
        {
            var result = da.Delete(61);
            Assert.IsTrue(result);
        }
    }
}
