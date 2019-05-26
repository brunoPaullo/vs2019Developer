using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAcces
{
    public class AlumnoEntityFramework
    {
        public List<Alumno> GetAll()
        {
            var result = new List<Alumno>();
            using (var db = new DBModel())
            {
                result = db.Alumno
                    .ToList();
            }
            return result;
        }
    }
}
