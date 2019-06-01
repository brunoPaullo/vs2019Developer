using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace App.Data.DataAcces
{
    public class BaseConnection
    {
        public string ConnectionString
        {
            get
            {              
                string cnx = ConfigurationManager.ConnectionStrings["cnxDBModel"].ConnectionString;
                return cnx;
            }
        }
    }
}
