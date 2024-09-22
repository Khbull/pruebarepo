using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces.Conexion
{
    public class Connection_DataBase
    {
        //  String cadena_conexion = ConfigurationManager.ConnectionStrings["Data Source=.;Initial Catalog=CRUD_N_CAPAS;Integrated Security=True;Trust Server Certificate=True"].ToString();
        private SqlConnection c = new SqlConnection("Data Source=.;Initial Catalog=CRUD_N_CAPAS;Integrated Security=True;TrustServerCertificate=False;");

        public SqlConnection OpenConnection()
        {
            if (c.State == ConnectionState.Closed) c.Open();
            return c;
        }

        public SqlConnection CloseConnection()
        {
            if (c.State == ConnectionState.Open) c.Close();
            return c;
        }

    }
}
