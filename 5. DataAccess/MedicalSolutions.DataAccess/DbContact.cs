using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace MedicalSolutions.DataAccess
{
    public class DbContact
    {
        private static string _connectionString;
        private IDbConnection _conn;

        static DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        static DbContact()
        {
            _connectionString = @"Data Source=127.0.0.1;Initial Catalog=BlackDragon;Persist Security Info=True;User ID=sa;Password=123456";

        }

        public DbContact()
        {
            this._conn = new SqlConnection(ConnectionString);
        }

        public static string ConnectionString { get { return _connectionString; } }

        
    }
}
