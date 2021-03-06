﻿using System;
using App.Entities;
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

        [TestMethod]
        public void Insert()
        {
            var da = new ArtistDA();
            var artist = new Artist()
            {
                ArtistId = 0,
                Name = "Jubel"
            };
            artist.ArtistId = da.Insert(artist);
            Assert.IsTrue(artist.ArtistId > 0, "El nombre del artista ya existe");
        }

        [TestMethod]
        public void Update()
        {
            var da = new ArtistDA();
            var artist = new Artist()
            {
                ArtistId = 279,
                Name = "Diego Flores"
            };
            var registrosAfectados = da.Update(artist);
            Assert.IsTrue(registrosAfectados > 0);
        }

        [TestMethod]
        public void Delete()
        {
            var da = new ArtistDA();         
            var registrosAfectados = da.Delete(278);
            Assert.IsTrue(registrosAfectados > 0);
        }

    }
}
