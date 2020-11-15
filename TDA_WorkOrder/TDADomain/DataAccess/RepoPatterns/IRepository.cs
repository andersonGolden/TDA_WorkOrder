using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TDADomain.DataAccess.RepoPatterns
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(long id);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<List<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> keySelector);
        Task<TEntity> GetByIdIncludingAsync(Expression<Func<TEntity, bool>> keySelector, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);
    }
}
