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
    }
}
