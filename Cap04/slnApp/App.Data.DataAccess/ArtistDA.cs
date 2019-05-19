using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace App.Data.DataAccess
{
    public class ArtistDA
    {
        public List<Artist> GetAll(string nombre)
        {
            var result = new List<Artist>();
            using (var db = new DBModel())
            {
                result = db.Artist
                    .Where(a => a.Name.Contains(nombre))
                    .OrderBy(a => a.Name)
                    .ToList();
            }
            return result;
        }

        public Artist Get(int id)
        {
            var result = new Artist();
            using (var db = new DBModel())
            {
                //Con Lazy Loading
                //result = db.Artist
                //    .Find(id);

                //Con Include
                result = db.Artist
                    .Include(item => item.Album)
                    .Where(item => item.ArtistId == id)
                    .FirstOrDefault();
            }
            return result;
        }

        public int Insert(Artist artist)
        {
            var result = 0;
            using (var db = new DBModel())
            {
                //Agrega la entidad al contexo
                db.Artist.Add(artist);
                //Se confirma la transaccion
                db.SaveChanges();

                result = artist.ArtistId;
            }
            return result;
        }

        public bool Update(Artist artist)
        {
            var result = false;
            using (var db = new DBModel())
            {
                //Atachamos la entidad al contexto
                db.Artist.Attach(artist);

                //Cambiando el estado de la entidad
                db.Entry(artist).State = EntityState.Modified;

                //Confirmando la transaccion
                db.SaveChanges();

                result = true;
            }
            return result;
        }

        public bool Delete(int artistId)
        {
            var result = false;
            using (var db = new DBModel())
            {
                var artist = new Artist
                {
                    ArtistId = artistId
                };
                db.Artist.Attach(artist);
                db.Artist.Remove(artist);

                //Confirmando la transaccion
                db.SaveChanges();

                result = true;
            }
            return result;
        }
    }
}
