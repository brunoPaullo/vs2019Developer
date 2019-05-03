using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Test
{
    [TestClass]
    public class GenreTXLocalDapperDAUnitTest
    {
        private readonly GenreTXLocalDapperDA da = new GenreTXLocalDapperDA();

        [TestMethod]
        public void Get()
        {
            var genre = da.Get(25);
            Assert.IsTrue(genre.GenreId > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            var genres = da.GetAll("B");
            Assert.IsTrue(genres.Count() > 0);
        }

        [TestMethod]
        public void Insert()
        {
            Genre genre = new Genre()
            {
                Name = "Jubel-2"
            };
            var result = da.Insert(genre);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Update()
        {
            Genre genre = new Genre()
            {
                GenreId = 27, 
                Name = "Jubel-2"
            };
            var result = da.Update(genre);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Delete()
        {
            var result = da.Delete(26);
            Assert.IsTrue(result > 0);
        }
    }
}
