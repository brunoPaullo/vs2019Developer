using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistTXLocalDAUnitTest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistTXLocalDA();
            Assert.IsTrue(da.GetCount() > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistTXLocalDA();
            var listado = da.GetAll("Aero");
            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void GetAllsp()
        {
            var da = new ArtistTXLocalDA();
            var listado = da.GetAllsp("Aero");
            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistTXLocalDA();
            var artist = da.Get(8);
            Assert.IsTrue(artist.ArtistId != 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new ArtistTXLocalDA();
            var artist = new Artist()
            {
                ArtistId = 0,
                Name = "Jlisk Young-3"
            };
            artist.ArtistId = da.Insert(artist);
            Assert.IsTrue(artist.ArtistId > 0, "El nombre del artista ya existe");
        }

        [TestMethod]
        public void Update()
        {
            var da = new ArtistTXLocalDA();
            var artist = new Artist()
            {
                ArtistId = 281,
                Name = "Jlisk Young - 1 "
            };
            var registrosAfectados = da.Update(artist);
            Assert.IsTrue(registrosAfectados > 0);
        }

        [TestMethod]
        public void Delete()
        {
            var da = new ArtistTXLocalDA();         
            var registrosAfectados = da.Delete(277);
            Assert.IsTrue(registrosAfectados > 0);
        }

    }
}
