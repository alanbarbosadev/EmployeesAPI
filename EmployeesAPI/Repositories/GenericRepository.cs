using EmployeesAPI.Data;
using EmployeesAPI.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeesAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
           _dbSet.Remove(entity);
           await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> ReadAllAsync(Expression<Func<T, bool>> filter = null)
        {
            var query = _dbSet.AsQueryable();

            if(filter != null)
            {
                query = query.Where(filter).AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> ReadByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
