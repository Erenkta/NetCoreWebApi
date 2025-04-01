using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Repositories
{
    /// <summary>
    /// Generic CRUD operations for any type of <typeparamref name="class" />.
    /// </summary>
    public interface IGenericRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T,bool>> predicate);
        ValueTask<T?> GetByIdAsync(int id);
        ValueTask<EntityEntry<T>> AddAsync(T entity);

        void Update(T entity);
        void Delete(T entity);
        
    }
}
