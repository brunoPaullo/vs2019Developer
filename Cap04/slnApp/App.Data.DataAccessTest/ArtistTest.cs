using System;
using App.Data.DataAccess;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class ArtistTest
    {
        private readonly ArtistDA da = new ArtistDA();

        [TestMethod]
        public void GetAll()
        {
            var artists = da.GetAll("Aero");
            Assert.IsTrue(artists.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var artists = da.Get(1);
            Assert.IsTrue(artists.ArtistId > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var artist = new Artist()
            {
                Name = "Artista Prueba"
            };
            var artistId = da.Insert(artist);
            Assert.IsTrue(artistId > 0);
        }

        [TestMethod]
        public void Update()
        {
            var artist = new Artist()
            {
                ArtistId = 288,
                Name = "Artista Update Prueba"
            };
            var result = da.Update(artist);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete()
        {
            var result = da.Delete(288);
            Assert.IsTrue(result);
        }
    }
}
