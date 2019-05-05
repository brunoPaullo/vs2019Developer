using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace App.Data
{
    public class ArtistTXLocalDapperDA : BaseConnection
    {
        /// <summary>
        /// Permite obtener la catidad de registros que existen en la tabla Artista
        /// </summary>
        /// <returns>Retorna el numero de registros</returns>
        public int GetCount()
        {
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";
            /*1.-Creando instancia del objeto Connection*/
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.ExecuteScalar<int>(sql);
            }
            return result;
        }

        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        public List<Artist> GetAll(string filterByName = "")
        {
            var resultado = new List<Artist>();
            var sql = "SELECT * FROM Artist WHERE Name LIKE @filterByName";
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                resultado = cn.Query<Artist>(sql, new { filterByName = $"%{filterByName}%" }).ToList();
            }
            return resultado;
        }

        /// <summary>
        /// Permite obtener un artista
        /// </summary>
        /// <param name="id">Parametro ArtistId</param>
        /// <returns>Un artista</returns>
        public Artist Get(int id)
        {
            var result = new Artist();
            var sql = $"SELECT * FROM Artist WHERE ArtistId = @ParamId";
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                result = cn.QueryFirstOrDefault<Artist>(sql, new { ParamId = id });
            }

            return result;
        }

        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        public List<Artist> GetAllsp(string filterByName = "")
        {
            var resultado = new List<Artist>();
            var sql = "usp_GetAll";
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                resultado = cn.Query<Artist>(sql, new { filterByName = $"%{filterByName}%" }, commandType: CommandType.StoredProcedure).ToList();
            }
            return resultado;
        }

        public int Insert(Artist artist)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                resultado = cn.ExecuteScalar<int>("usp_InsertArtist", new { pName = artist.Name }, commandType: CommandType.StoredProcedure);
            }
            return resultado;
        }

        public int Update(Artist artist)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                resultado = cn.Execute("usp_UpdateArtist", new { pArtistId = artist.ArtistId, pName = artist.Name }, commandType: CommandType.StoredProcedure);
            }
            return resultado;
        }

        public int Delete(int artistId)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                resultado = cn.Execute("usp_DeleteArtist", new { pArtistId = artistId }, commandType: CommandType.StoredProcedure);
            }
            return resultado;
        }

        /// <summary>
        /// Transaccion with Dapper
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public int InsertTx(Artist artist)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                //Open the connection to data base
                //After to start the transaccion
                cn.Open();

                //Start the transaccion
                var tx = cn.BeginTransaction();
                try
                {
                    resultado = cn.ExecuteScalar<int>("usp_InsertArtist",
                        new { pName = artist.Name }
                        , commandType: CommandType.StoredProcedure,
                        transaction: tx);
                    //Commit the transaccion
                    tx.Commit();
                }
                catch (Exception)
                {
                    //Discart changes
                    tx.Rollback();
                }
            }
            return resultado;
        }

        public int UpdateTx(Artist artist)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                var tx = cn.BeginTransaction();
                try
                {
                    resultado = cn.Execute("usp_UpdateArtist",
                        new { pArtistId = artist.ArtistId, pName = artist.Name },
                        commandType: CommandType.StoredProcedure,
                        transaction: tx);
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                }
            }
            return resultado;
        }

        public int DeleteTx(int artistId)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                var tx = cn.BeginTransaction();
                try
                {
                    resultado = cn.Execute("usp_DeleteArtist",
                        new { pArtistId = artistId }
                        , commandType: CommandType.StoredProcedure,
                        transaction: tx);
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                }
            }
            return resultado;
        }
    }
}
