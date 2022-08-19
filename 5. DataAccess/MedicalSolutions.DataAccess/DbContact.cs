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
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace MedicalSolutions.DataAccess
{
    public class DbContact: IDisposable
    {
        private static string _connectionString;
        private IDbConnection _conn;

        static DbContact()
        {
            _connectionString = @"Data Source=127.0.0.1;Initial Catalog=BlackDragon;Persist Security Info=True;User ID=sa;Password=123456";
        }

        public DbContact()
        {
            this._conn = new SqlConnection(_connectionString);
        }

        public async Task<IReadOnlyList<dynamic>> QueryAsync(string sql, object para = null, IDbTransaction dbTransaction = null)
        {
            return (await _conn.QueryAsync(sql, para, dbTransaction, commandType: CommandType.StoredProcedure)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object para = null, IDbTransaction dbTransaction = null)
        {
            return await _conn.QueryFirstOrDefaultAsync<T>(sql, para, dbTransaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object para = null, IDbTransaction dbTransaction = null)
        {
            return await _conn.QuerySingleAsync<T>(sql, para, dbTransaction);
        }

        public void Dispose()
        {
            _conn.Dispose();
        }
    }
}
