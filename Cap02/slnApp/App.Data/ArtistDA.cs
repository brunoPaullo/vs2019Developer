using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class ArtistDA : BaseConnection
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
                /*2.-Creando el objeto Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); //Abriendo conexion con la base de datos
                result = (int)cmd.ExecuteScalar();

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
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                filterByName = $"%{filterByName}%";
                cmd.Parameters.Add(
                    new SqlParameter("@filterByName", filterByName));
                cn.Open();
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    resultado.Add(artist);
                }
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
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;

                /*Configurando parametros*/
                cmd.Parameters.Add(
                    new SqlParameter("@ParamId", id)
                    );

                cn.Open();
                var reader = cmd.ExecuteReader();

                var indice = 0;
                while (reader.Read())
                {
                    indice = reader.GetOrdinal("ArtistId");
                    result.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    result.Name = reader.GetString(indice);
                }
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
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                filterByName = $"%{filterByName}%";
                cmd.Parameters.Add(
                    new SqlParameter("@filterByName", filterByName));
                cn.Open();
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    resultado.Add(artist);
                }
            }
            return resultado;
        }
    }
}
