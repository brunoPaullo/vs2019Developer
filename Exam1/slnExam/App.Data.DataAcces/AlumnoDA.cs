using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAcces
{
    public class AlumnoDA: BaseConnection
    {
        public List<Alumno> GetAll()
        {
            var resultado = new List<Alumno>();
            var sql = "usp_GetAllAlumnos";
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open();
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var alumno = new Alumno();
                    indice = reader.GetOrdinal("AlumnoID");
                    alumno.AlumnoID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Nombres");
                    alumno.Nombres = reader.GetString(indice);

                    indice = reader.GetOrdinal("Apellidos");
                    alumno.Apellidos = reader.GetString(indice);

                    indice = reader.GetOrdinal("Sexo");
                    alumno.Sexo = reader.GetString(indice);

                    indice = reader.GetOrdinal("FechaNacimiento");
                    alumno.FechaNacimiento = reader.GetDateTime(indice);

                    resultado.Add(alumno);
                }
            }
            return resultado;
        }

        public int Insert(Alumno alumno)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                IDbCommand cmd = new SqlCommand("usp_InsertAlumno")
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Connection = cn;
                cmd.Parameters.Add(
                    new SqlParameter("@pNombres", alumno.Nombres)
                    );
                cmd.Parameters.Add(
                   new SqlParameter("@pApellidos", alumno.Apellidos)
                   );
                cmd.Parameters.Add(
                   new SqlParameter("@Direccion", alumno.Direccion)
                   );
                cmd.Parameters.Add(
                   new SqlParameter("@Sexo", alumno.Sexo)
                   );
                cmd.Parameters.Add(
                   new SqlParameter("@FechaNacimiento", alumno.FechaNacimiento)
                   );
                resultado = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return resultado;
        }
    }
}
