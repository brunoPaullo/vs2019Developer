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

        #region Album

        #endregion
    }
}
