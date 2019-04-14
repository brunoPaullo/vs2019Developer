using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistDAUnitTest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();
            Assert.IsTrue(da.GetCount() > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();
            var listado = da.GetAll("Aero");
            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void GetAllsp()
        {
            var da = new ArtistDA();
            var listado = da.GetAllsp("Aero");
            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistDA();
            var artist = da.Get(8);
            Assert.IsTrue(artist.ArtistId != 0);
        }
    }
}
