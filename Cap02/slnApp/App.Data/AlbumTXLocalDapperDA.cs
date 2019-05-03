using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace App.Data
{
    public class AlbumTXLocalDapperDA : BaseConnection
    {
        public Album Get(int albumId)
        {
            Album album = new Album();
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                album = cn.QueryFirstOrDefault<Album>("usp_GetAlbum", new { pAlbumId = albumId }, commandType: CommandType.StoredProcedure);
            }
            return album;
        }

        public List<Album> GetAll(string title)
        {
            List<Album> albums = new List<Album>();
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                albums = cn.Query<Album>("usp_GetAllAlbum", new { pTitle = $"%{title}%" }, commandType: CommandType.StoredProcedure).ToList();
            }
            return albums;
        }

        public int Insert(Album album)
        {
            int result = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.ExecuteScalar<int>("usp_InsertAlbum", new
                {
                    pTitle = album.Title,
                    pArtistId = album.ArtistId
                }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public int Update(Album album)
        {
            int result = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.Execute("usp_UpdateAlbum", new
                {
                    pAlbumId = album.AlbumId,
                    pTitle = album.Title,
                    pArtistId = album.ArtistId
                }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public int Delete(int albumId)
        {
            int result = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.Execute("usp_DeleteAlabum", new { pAlbumId = albumId }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
