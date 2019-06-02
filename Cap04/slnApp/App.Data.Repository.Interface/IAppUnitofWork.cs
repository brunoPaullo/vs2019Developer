using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IAppUnitofWork : IDisposable
    {
        IArtistRepository ArtistRepository { get; set; }
        IAlbumRepository AlbumRepository { get; set; }
        ITrackRepository TrackRepository { get; set; }

        int Complete();
    }
}
