using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using App.Entities;
using System.Data;
using System.Data.SqlClient;

namespace App.Data
{
    public class GenreTXLocalDapperDA : BaseConnection
    {
        public Genre Get(int genreId)
        {
            Genre genre = new Genre();
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                genre = cn.QueryFirstOrDefault<Genre>("usp_GetGenre", new { pGenreId = genreId }, commandType: CommandType.StoredProcedure);
            }
            return genre;
        }

        public List<Genre> GetAll(string name)
        {
            List<Genre> genres = new List<Genre>();
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                genres = cn.Query<Genre>("usp_GetAllGenre", new { pName = $"%{name}%" }, commandType: CommandType.StoredProcedure).ToList();
            }
            return genres;
        }

        public int Insert(Genre genre)
        {
            int result = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.ExecuteScalar<int>("usp_InsertGenre", new { pName = genre.Name }, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Update(Genre genre)
        {
            int result = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.Execute("usp_UpdateGenre", new { pGenreId = genre.GenreId, pName = genre.Name }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public int Delete(int genreId)
        {
            int result = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.Execute("usp_DeleteGenre", new { pGenreId = genreId }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
