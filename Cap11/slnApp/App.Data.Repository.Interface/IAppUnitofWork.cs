using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IAppUnitofWork : IDisposable
    {
        
        IAlbumRepository AlbumRepository { get; set; }
        IArtistRepository ArtistRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        IEmployeeRepository EmployeeRepository { get; set; }
        IGenreRepository GenreRepository { get; set; }
        IInvoiceLineRepository InvoiceLineRepository { get; set; }
        IInvoiceRepository InvoiceRepository { get; set; }
        IMediaTypeRepository MediaTypeRepository { get; set; }
        IPlayListRepository PlayListRepository { get; set; }
        ITrackRepository TrackRepository { get; set; }
       
        int Complete();
    }
}
