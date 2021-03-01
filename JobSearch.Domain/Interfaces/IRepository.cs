using JobSearch.Domain.Entities.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobSearch.Domain.Interfaces
{
    public interface IRepository
    {
        Task AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        void Update<TEntity>(TEntity entity) where TEntity : EntityBase;
        void Remove<TEntity>(TEntity entity) where TEntity : EntityBase;
        IQueryable<TEntity> FilterAsNoTracking<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase;
        IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase;
        (IQueryable<T> query, int itemsCount, int pagesCount) GetListByPaging<T>
            (IQueryable<T> query, int count, int page) where T : EntityBase;

        Task SaveChangesAsync();
        void SaveChanges();
    }
}
