using System;
using App.Data.DataAccess;
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
            var artists = da.GetAll();
            Assert.IsTrue(artists.Count > 0);
        }
    }
}
