using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Library.Internal.DataAccess
{
    public class SqlDataAccess
    {

        public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                var results = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task SaveDataAsync<U>(string storedProcedure, U parameters, string connectionString)
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> InsertAsync<T>(T model, string connectionString) where T : class
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.InsertAsync(model);
                return result;
            }
        }

        public async Task<T> GetAsync<T, U>(U id, string connectionString) where T : class
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.GetAsync<T>(id);
                return result;
            }
        }

        public async Task<List<T>> GetAllAsync<T>(string connectionString) where T : class
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.GetAllAsync<T>();
                return result.ToList();
            }
        }

        public async Task<bool> UpdateAsync<T>(T model, string connectionString) where T : class
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.UpdateAsync(model);
                return result;
            }
        }


        public async Task<bool> DeleteAsync<T>(T model, string connectionString) where T : class
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.DeleteAsync(model);
                return result;
            }
        }

    }
}
