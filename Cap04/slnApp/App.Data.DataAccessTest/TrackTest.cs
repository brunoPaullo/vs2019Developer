using System;
using System.Linq;
using App.Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class TrackTest
    {
        TrackDA da = new TrackDA();
        [TestMethod]
        public void ConsultarTracks()
        {
            var tracks = da.ConsultarTracks("%Volta%");

            Assert.IsTrue(tracks.Count() > 0);
        }

        [TestMethod]
        public void ConsultarTracksQ()
        {
            var tracks = da.ConsultarTracksQ("Volta", 0, 0);

            Assert.IsTrue(tracks.Count() > 0);
        }
    }
}
