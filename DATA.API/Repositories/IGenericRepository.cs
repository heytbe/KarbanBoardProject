using Core.API.Entity;
using System.Linq.Expressions;

namespace Data.API.Repositories
{
    public interface IGenericRepository<T> where T : class,IEntityBase,new()
    {
        IQueryable<T> GetAll(bool trackChanges, Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeExpression);
        IQueryable<T> GetAllThenInclude(bool trackChanges, Func<IQueryable<T>, IQueryable<T>> thenInclude, Expression<Func<T, bool>> expression = null);
        Task<T> GetOne(bool trackChanges, Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeExpression);
        Task<T> GetOneThenInclude(bool trackChanges, Func<IQueryable<T>, IQueryable<T>> thenInclude, Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetByNameFiltersAsync(bool trackChanges, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> thenInclude = null);
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        IQueryable<TResult> GetSelect<TResult>(bool trackChanges, Expression<Func<T, TResult>> expression);
    }
}
