using App.Entities.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using App.Entities.Base;

namespace App.Data.DataAcces
{
    public  class AlumnoDapper:BaseConnection
    {
        public List<AlumnoInfo> GetAll(string grado, string curso)
        {
            List<AlumnoInfo> alumnoInfo = new List<AlumnoInfo>();
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                alumnoInfo = cn.Query<AlumnoInfo>("usp_AlumnoInfo", new { pGrado = grado, pCurso = curso }, commandType: CommandType.StoredProcedure).ToList();
            }
            return alumnoInfo;
        }

        public int InsertNotas(Notas nota)
        {
            var resultado = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                resultado = cn.ExecuteScalar<int>("usp_InsertNotas", new { nota.AlumnoID, nota.CursoID, nota.Nota}, commandType: CommandType.StoredProcedure);
            }
            return resultado;
        }
    }
}
