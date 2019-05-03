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
    public class AlbumTXLocalDapperDAUnitTest
    {
        private readonly AlbumTXLocalDapperDA da = new AlbumTXLocalDapperDA();

        [TestMethod]
        public void Get()
        {
            var album = da.Get(5);
            Assert.IsTrue(album.AlbumId > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            var albums = da.GetAll("B");
            Assert.IsTrue(albums.Count() > 0);
        }

        [TestMethod]
        public void Insert()
        {
            Album album = new Album()
            {
                Title="Jubel",
                ArtistId = 274
            };
            var result = da.Insert(album);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Update()
        {
            Album album = new Album()
            {
                AlbumId = 348,
                Title ="Jubel - Mix",
                ArtistId = 274
            };
            var result = da.Update(album);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Delete()
        {
            var result = da.Delete(348);
            Assert.IsTrue(result > 0);
        }
    }
}
