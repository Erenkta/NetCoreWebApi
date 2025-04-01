using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace App.Repositories
{
    public class GenericRepository<T> (AppDbContext context): IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();
        public  ValueTask<EntityEntry<T>> AddAsync(T entity) => _dbSet.AddAsync(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);
        public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();

        public ValueTask<T?>  GetByIdAsync(int id) =>  _dbSet.FindAsync(id);
        public void Update(T entity) => _dbSet.Update(entity);

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)=> _dbSet.Where(predicate).AsQueryable().AsNoTracking();
    }
}
