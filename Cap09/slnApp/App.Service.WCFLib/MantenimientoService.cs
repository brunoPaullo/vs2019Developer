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
        #region Album
        public bool DeleteAlbum(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Album()
                {
                    AlbumId = id
                };
                uw.AlbumRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Album> GetAlbumAll(string nombre)
        {
            var result = new List<Album>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.AlbumRepository.GetAll(
                    a => a.Title.Contains(nombre)
                    );
            }
            return result;
        }

        public Album GetAlbumById(int id)
        {
            var result = new Album();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.AlbumRepository.GetById(id);
            }
            return result;
        }

        public int InsertAlbum(Album entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.AlbumRepository.Add(entity);
                uw.Complete();

                result = entity.AlbumId;
            }
            return result;
        }

        public bool UpdateAlbum(Album entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.AlbumRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region Artist
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
        #endregion

        #region Customer
        public bool DeleteCustomer(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Customer()
                {
                    CustomerId = id
                };
                uw.CustomerRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Customer> GetCustomerAll(string nombre)
        {
            var result = new List<Customer>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.CustomerRepository.GetAll(
                    a => a.FirstName.Contains(nombre)
                    );
            }
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            var result = new Customer();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.CustomerRepository.GetById(id);
            }
            return result;
        }

        public int InsertCustomer(Customer entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.CustomerRepository.Add(entity);
                uw.Complete();

                result = entity.CustomerId;
            }
            return result;
        }

        public bool UpdateCustomer(Customer entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.CustomerRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region Employee
        public bool DeleteEmployee(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Employee()
                {
                    EmployeeId = id
                };
                uw.EmployeeRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Employee> GetEmployeeAll(string nombre)
        {
            var result = new List<Employee>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.EmployeeRepository.GetAll(
                    a => a.FirstName.Contains(nombre)
                    );
            }
            return result;
        }

        public Employee GetEmployeeById(int id)
        {
            var result = new Employee();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.EmployeeRepository.GetById(id);
            }
            return result;
        }

        public int InsertEmployee(Employee entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.EmployeeRepository.Add(entity);
                uw.Complete();

                result = entity.EmployeeId;
            }
            return result;
        }

        public bool UpdateEmployee(Employee entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.EmployeeRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region Genre
        public bool DeleteGenre(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Genre()
                {
                    GenreId = id
                };
                uw.GenreRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Genre> GetGenreAll(string nombre)
        {
            var result = new List<Genre>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.GenreRepository.GetAll(
                    a => a.Name.Contains(nombre)
                    );
            }
            return result;
        }

        public Genre GetGenreById(int id)
        {
            var result = new Genre();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.GenreRepository.GetById(id);
            }
            return result;
        }

        public int InsertGenre(Genre entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.GenreRepository.Add(entity);
                uw.Complete();

                result = entity.GenreId;
            }
            return result;
        }

        public bool UpdateGenre(Genre entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.GenreRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region Invoice
        public bool DeleteInvoice(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Invoice()
                {
                    InvoiceId = id
                };
                uw.InvoiceRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Invoice> GetInvoiceAll(string nombre)
        {
            var result = new List<Invoice>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.InvoiceRepository.GetAll(
                    a => a.BillingAddress.Contains(nombre)
                    );
            }
            return result;
        }

        public Invoice GetInvoiceById(int id)
        {
            var result = new Invoice();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.InvoiceRepository.GetById(id);
            }
            return result;
        }

        public int InsertInvoice(Invoice entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.InvoiceRepository.Add(entity);
                uw.Complete();

                result = entity.InvoiceId;
            }
            return result;
        }

        public bool UpdateInvoice(Invoice entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.InvoiceRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region InvoiceLine
        public bool DeleteInvoiceLine(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new InvoiceLine()
                {
                    InvoiceLineId = id
                };
                uw.InvoiceLineRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<InvoiceLine> GetInvoiceLineAll(string nombre)
        {
            var result = new List<InvoiceLine>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.InvoiceLineRepository.GetAll();
            }
            return result;
        }

        public InvoiceLine GetInvoiceLineById(int id)
        {
            var result = new InvoiceLine();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.InvoiceLineRepository.GetById(id);
            }
            return result;
        }

        public int InsertInvoiceLine(InvoiceLine entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.InvoiceLineRepository.Add(entity);
                uw.Complete();

                result = entity.InvoiceLineId;
            }
            return result;
        }

        public bool UpdateInvoiceLine(InvoiceLine entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.InvoiceLineRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region MediaType
        public bool DeleteMediaType(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new MediaType()
                {
                    MediaTypeId = id
                };
                uw.MediaTypeRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<MediaType> GetMediaTypeAll(string nombre)
        {
            var result = new List<MediaType>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.MediaTypeRepository.GetAll(
                    a => a.Name.Contains(nombre)
                    );
            }
            return result;
        }

        public MediaType GetMediaTypeById(int id)
        {
            var result = new MediaType();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.MediaTypeRepository.GetById(id);
            }
            return result;
        }

        public int InsertMediaType(MediaType entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.MediaTypeRepository.Add(entity);
                uw.Complete();

                result = entity.MediaTypeId;
            }
            return result;
        }

        public bool UpdateMediaType(MediaType entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.MediaTypeRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region Playlist
        public bool DeletePlaylist(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Playlist()
                {
                    PlaylistId = id
                };
                uw.PlayListRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Playlist> GetPlaylistAll(string nombre)
        {
            var result = new List<Playlist>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.PlayListRepository.GetAll(
                    a => a.Name.Contains(nombre)
                    );
            }
            return result;
        }

        public Playlist GetPlaylistById(int id)
        {
            var result = new Playlist();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.PlayListRepository.GetById(id);
            }
            return result;
        }

        public int InsertPlaylist(Playlist entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.PlayListRepository.Add(entity);
                uw.Complete();

                result = entity.PlaylistId;
            }
            return result;
        }

        public bool UpdatePlaylist(Playlist entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.PlayListRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion

        #region Track
        public bool DeleteTrack(int id)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                var entity = new Track()
                {
                    TrackId = id
                };
                uw.TrackRepository.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Track> GetTrackAll(string nombre)
        {
            var result = new List<Track>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.TrackRepository.GetAll(
                    a => a.Name.Contains(nombre)
                    );
            }
            return result;
        }

        public Track GetTrackById(int id)
        {
            var result = new Track();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.TrackRepository.GetById(id);
            }
            return result;
        }

        public int InsertTrack(Track entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.TrackRepository.Add(entity);
                uw.Complete();

                result = entity.TrackId;
            }
            return result;
        }

        public bool UpdateTrack(Track entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.TrackRepository.Update(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }
        #endregion
    }
}