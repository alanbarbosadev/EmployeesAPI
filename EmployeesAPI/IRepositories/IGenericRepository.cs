using System.Linq.Expressions;

namespace EmployeesAPI.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ReadAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> ReadByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
