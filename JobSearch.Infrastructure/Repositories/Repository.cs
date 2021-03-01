using JobSearch.Domain.Entities.Base;
using JobSearch.Domain.Interfaces;
using JobSearch.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobSearch.Infrastructure.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly JobSearchContext _context;

        public Repository(JobSearchContext context)
        {
            _context = context;
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.AddAsync(entity);
        }

        public IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase
        {
            return _context.Set<TEntity>().Where(expression).Where(e => !e.IsDeleted);
        }

        public IQueryable<TEntity> FilterAsNoTracking<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : EntityBase
        {
            return _context.Set<TEntity>().Where(expression).Where(e => !e.IsDeleted).AsNoTracking();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Update(entity);
        }

        public (IQueryable<T> query, int itemsCount, int pagesCount) GetListByPaging<T>(IQueryable<T> query, int count, int page) where T : EntityBase
        {
            var itemCount = query.Count();
            var itemPage = Convert.ToInt32(Math.Ceiling(decimal.Divide(itemCount, count)));
            var data = query.Skip((page - 1) * count).Take(count);

            return (data, itemCount, itemPage);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
