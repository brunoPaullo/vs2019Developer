using App.Entities.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
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
    }
}
