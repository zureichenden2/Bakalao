using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSQL
    {
        private readonly string connectionString;
        public ConnectionToSQL()
        {
            connectionString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            //Data Source=.\\SQLEXPRESS;Initial Catalog=Sistema_Incidencias;Integrated Security=True
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


    }
}
