using Core.API.Entity;
using Data.API.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntityBase,new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table
        {
            get => _context.Set<T>();
        }

        public IQueryable<T> GetByNameFiltersAsync(bool trackChanges, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> thenInclude = null)
        {
            IQueryable<T> query = Table;

            if (predicate is not null)
            {
                if (trackChanges)
                {
                    query = query.Where(predicate);
                }
                else
                {
                    query = query.Where(predicate).AsNoTracking();
                }
            }

            if (thenInclude is not null)
            {
                IQueryable<T> values = thenInclude(query);
                return values;
            }

            return query;
        }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.CountAsync(expression);
        }

        public IQueryable<TResult> GetSelect<TResult>(bool trackChanges, Expression<Func<T, TResult>> expression)
        {
            var query = Table.Select(expression);

            return query;
        }

        public IQueryable<T> GetAll(bool trackChanges, Expression<Func<T, bool>>? expression = null,
            params Expression<Func<T, object>>[] includeExpression)
        {
            IQueryable<T> query = Table;

            if (expression is not null)
            {
                if (trackChanges)
                {
                    query = query.Where(expression);
                }
                else
                {
                    query = query.Where(expression).AsNoTracking();
                }
            }

            if (includeExpression.Any())
            {
                foreach (var item in includeExpression)
                {
                    query = query.AsSplitQuery().Include(item);
                }
            }

            return query;
        }

        public IQueryable<T> GetAllThenInclude(bool trackChanges, Func<IQueryable<T>, IQueryable<T>> thenInclude,
            Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = Table;

            if (expression is not null)
            {
                if (trackChanges)
                {
                    query = query.Where(expression);
                }
                else
                {
                    query = query.Where(expression).AsNoTracking();
                }
            }

            IQueryable<T> values = thenInclude(query);

            return values;
        }

        public async Task<T> GetOne(bool trackChanges, Expression<Func<T, bool>> expression = null,
            params Expression<Func<T, object>>[] includeExpression)
        {
            IQueryable<T> query = Table;

            if (expression is not null)
            {
                if (trackChanges)
                {
                    query = query.Where(expression);
                }
                else
                {
                    query = query.Where(expression).AsNoTracking();
                }
            }

            if (includeExpression.Any())
            {
                foreach (var item in includeExpression)
                {
                    query = query.AsSplitQuery().Include(item);
                }
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> GetOneThenInclude(bool trackChanges, Func<IQueryable<T>, IQueryable<T>> thenInclude,
            Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = Table;

            if (expression is not null)
            {
                if (trackChanges)
                {
                    query = query.Where(expression);
                }
                else
                {
                    query = query.Where(expression).AsNoTracking();
                }
            }

            IQueryable<T> values = thenInclude(query);

            return await values.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
