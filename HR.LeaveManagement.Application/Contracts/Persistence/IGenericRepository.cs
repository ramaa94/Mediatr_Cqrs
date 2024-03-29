namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository <T> where T : class
    {
        Task<List<T>> CreateAsync (T entity);
        Task DeleteAsync (T entity);
        Task<T> UpdateAsync (T entity);
        
        Task<T> GetAsync();
        Task<T> GetByIdAsync (int id);  

    }

}
