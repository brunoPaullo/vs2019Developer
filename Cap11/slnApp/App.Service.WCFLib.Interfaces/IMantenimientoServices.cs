using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib.Interfaces
{
    [ServiceContract]
    public interface IMantenimientoServices
    {

        #region Album
        [OperationContract]
        IEnumerable<Album> GetAlbumAll(string nombre);

        [OperationContract]
        int InsertAlbum(Album entity);

        [OperationContract]
        bool UpdateAlbum(Album entity);

        [OperationContract]
        Album GetAlbumById(int id);

        [OperationContract]
        bool DeleteAlbum(int id);
        #endregion

        #region Artist
        [OperationContract]
        IEnumerable<Artist> GetArtistAll(string nombre);

        [OperationContract]
        int InsertArtist(Artist entity);

        [OperationContract]
        bool UpdateArtist(Artist entity);

        [OperationContract]
        Artist GetArtistById(int id);

        [OperationContract]
        bool DeleteArtist(int id);
        #endregion

        #region Customer
        [OperationContract]
        IEnumerable<Customer> GetCustomerAll(string nombre);

        [OperationContract]
        int InsertCustomer(Customer entity);

        [OperationContract]
        bool UpdateCustomer(Customer entity);
        
        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        bool DeleteCustomer(int id);
        #endregion

        #region Employee
        [OperationContract]
        IEnumerable<Employee> GetEmployeeAll(string nombre);

        [OperationContract]
        int InsertEmployee(Employee entity);

        [OperationContract]
        bool UpdateEmployee(Employee entity);

        [OperationContract]
        Employee GetEmployeeById(int id);

        [OperationContract]
        bool DeleteEmployee(int id);
        #endregion

        #region Genre
        [OperationContract]
        IEnumerable<Genre> GetGenreAll(string nombre);

        [OperationContract]
        int InsertGenre(Genre entity);

        [OperationContract]
        bool UpdateGenre(Genre entity);

        [OperationContract]
        Genre GetGenreById(int id);

        [OperationContract]
        bool DeleteGenre(int id);
        #endregion

        #region Invoice
        [OperationContract]
        IEnumerable<Invoice> GetInvoiceAll(string nombre);

        [OperationContract]
        int InsertInvoice(Invoice entity);

        [OperationContract]
        bool UpdateInvoice(Invoice entity);

        [OperationContract]
        Invoice GetInvoiceById(int id);

        [OperationContract]
        bool DeleteInvoice(int id);
        #endregion

        #region InvoiceLine
        [OperationContract]
        IEnumerable<InvoiceLine> GetInvoiceLineAll(string nombre);

        [OperationContract]
        int InsertInvoiceLine(InvoiceLine entity);

        [OperationContract]
        bool UpdateInvoiceLine(InvoiceLine entity);

        [OperationContract]
        InvoiceLine GetInvoiceLineById(int id);

        [OperationContract]
        bool DeleteInvoiceLine(int id);
        #endregion

        #region MediaType
        [OperationContract]
        IEnumerable<MediaType> GetMediaTypeAll(string nombre);

        [OperationContract]
        int InsertMediaType(MediaType entity);

        [OperationContract]
        bool UpdateMediaType(MediaType entity);

        [OperationContract]
        MediaType GetMediaTypeById(int id);

        [OperationContract]
        bool DeleteMediaType(int id);
        #endregion

        #region PlayList
        [OperationContract]
        IEnumerable<Playlist> GetPlaylistAll(string nombre);

        [OperationContract]
        int InsertPlaylist(Playlist entity);

        [OperationContract]
        bool UpdatePlaylist(Playlist entity);

        [OperationContract]
        Playlist GetPlaylistById(int id);

        [OperationContract]
        bool DeletePlaylist(int id);
        #endregion

        #region Track
        [OperationContract]
        IEnumerable<Track> GetTrackAll(string nombre);

        [OperationContract]
        int InsertTrack(Track entity);

        [OperationContract]
        bool UpdateTrack(Track entity);

        [OperationContract]
        Track GetTrackById(int id);

        [OperationContract]
        bool DeleteTrack(int id);
        #endregion
    }
}
