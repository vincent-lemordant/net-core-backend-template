using System.Linq.Expressions;
using Domain.Base;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Data.Core.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    /// <inheritdoc />
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // <inheritdoc />
        public async Task<T?> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        // <inheritdoc />
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        // <inheritdoc />
        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        // <inheritdoc />
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            _dbContext.Set<T>().Remove((await GetById(id)) ?? throw new EntityNotFoundException());
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // <inheritdoc />
        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // <inheritdoc />
        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        // <inheritdoc />
        public async Task<IPaginatedList<T>> ListAsync(Expression<Func<T, bool>> expression, IPaginationFilter paginationFilter)
        {
            return await PaginatedList<T>.CreateAsync(_dbContext.Set<T>().Where(expression), paginationFilter);
        }
    }
}