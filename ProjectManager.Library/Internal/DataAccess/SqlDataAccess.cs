using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Library.Internal.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ProjectManagerDB"].ConnectionString;
        }

        public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters)
        {
            string sqlConnectionString = GetConnectionString();
            using (IDbConnection connection = new SqlConnection(sqlConnectionString))
            {
                var results = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task SaveDataAsync<U>(string storedProcedure, U parameters)
        {
            string sqlConnectionString = GetConnectionString();
            using (IDbConnection connection = new SqlConnection(sqlConnectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> InsertAsync<T>(T model) where T : class
        {
            string sqlConnectionString = GetConnectionString();
            using (IDbConnection connection = new SqlConnection(sqlConnectionString))
            {
                var result = await connection.InsertAsync(model);
                return result;
            }
        }

        public async Task<T> GetAsync<T, U>(U id) where T : class
        {
            string sqlConnectionString = GetConnectionString();
            using (IDbConnection connection = new SqlConnection(sqlConnectionString))
            {
                var result = await connection.GetAsync<T>(id);
                return result;
            }
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            string sqlConnectionString = GetConnectionString();
            using (IDbConnection connection = new SqlConnection(sqlConnectionString))
            {
                var result = await connection.GetAllAsync<T>();
                return result.ToList();
            }
        }

        public async Task<bool> UpdateAsync<T>(T model) where T : class
        {
            string sqlConnectionString = GetConnectionString();
            using (IDbConnection connection = new SqlConnection(sqlConnectionString))
            {
                var result = await connection.UpdateAsync(model);
                return result;
            }
        }


        public async Task<bool> DeleteAsync<T>(T model) where T : class
        {
            string sqlConnectionString = GetConnectionString();
            using (IDbConnection connection = new SqlConnection(sqlConnectionString))
            {
                var result = await connection.DeleteAsync(model);
                return result;
            }
        }

    }
}
