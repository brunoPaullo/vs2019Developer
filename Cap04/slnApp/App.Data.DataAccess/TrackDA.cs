using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class TrackDA
    {
        //Implementar las operaciones CRUD

        public IEnumerable<TrackQuery> ConsultarTracks(string trackName)
        {
            using (var db = new DBModel())
            {
                return db.Database.SqlQuery<TrackQuery>("usp_GetTracks @trackName",
                                                         new SqlParameter("@trackName", trackName)
                                                         ).ToList();
            }
        }

        public IEnumerable<TrackQuery> ConsultarTracksQ(string trackName, int genreId, int mediaTypeId)
        {
            using (var db = new DBModel())
            {
                var query = from a in db.Track join
                                 b in db.Album on a.AlbumId equals b.AlbumId join 
                                 c in db.Genre on a.GenreId equals c.GenreId join
                                 d in db.MediaType on a.MediaTypeId equals d.MediaTypeId
                            where a.Name.Contains(trackName) &&
                                  a.GenreId == ((genreId > 0)? genreId : a.GenreId) && //(genreId == 0 || a.GenreId == genreId)
                                  a.MediaTypeId == ((mediaTypeId > 0) ? mediaTypeId : a.MediaTypeId)   //(mediaTypeId == 0 || a.MediaTypeId == mediaTypeId)
                            select new TrackQuery
                            {
                                TrackId = a.TrackId,
                                TrackName = a.Name,
                                AlbumTitle = b.Title,
                                Bytes = a.Bytes,
                                Composer = a.Composer,
                                Milliseconds = a.Milliseconds,
                                UnitPrice = a.UnitPrice,
                                GenreName = c.Name,
                                MediaTypeName = d.Name
                            };
                return query.ToList();
            }
        }
    }
}
