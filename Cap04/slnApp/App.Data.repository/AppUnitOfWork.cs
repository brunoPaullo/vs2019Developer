using App.Data.DataAccess;
using App.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.repository
{
    public class AppUnitOfWork : IAppUnitofWork
    {
        private readonly DbContext _context;

        public AppUnitOfWork()
        {
            _context = new DBModel();
            ArtistRepository = new ArtistRepository(_context);
            AlbumRepository = new AlbumRepository(_context);
        }

        public IArtistRepository ArtistRepository { get; set; }
        public IAlbumRepository AlbumRepository { get; set; }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
