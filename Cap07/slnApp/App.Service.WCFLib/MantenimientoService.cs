using App.Data.repository;
using App.Entities.Base;
using App.Service.WCFLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib
{
    public class MantenimientoService : IMantenimientoServices
    {
        public bool DeleteArtist(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Artist()
                {
                    ArtistId = id
                };
                uw.ArtistRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Artist> GetArtistAll(string nombre)
        {
            var result = new List<Artist>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetAll(
                    a => a.Name.Contains(nombre)
                    );
            }
            return result;
        }

        public Artist GetArtistById(int id)
        {
            var result = new Artist();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetById(id);
            }
            return result;
        }

        public int InsertArtist(Artist entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepository.Add(entity);
                uw.Complete();

                result = entity.ArtistId;
            }
            return result;
        }

        public bool UpdateArtist(Artist entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
    }
}
