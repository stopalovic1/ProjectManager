
namespace ProjectManager.Library.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<bool> DeleteAsync<T>(T model) where T : class;
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<T> GetAsync<T, U>(U id) where T : class;
        Task<int> InsertAsync<T>(T model) where T : class;
        Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters);
        Task SaveDataAsync<U>(string storedProcedure, U parameters);
        Task<bool> UpdateAsync<T>(T model) where T : class;
    }
}