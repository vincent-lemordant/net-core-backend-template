using System.Linq.Expressions;
using Domain.Base;
using Domain.Exceptions;
using Domain.Interfaces;

namespace API.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IBaseRepository<T> Repository { get; set; }

        public BaseService(IBaseRepository<T> repository)
        {
            Repository = repository;
        }

        /// <inheritdoc />
        public async Task<IPaginatedList<T>> SearchByInstanceLabelAsync(string filter, IPaginationFilter paginationFilter)
        {
            return await ListAsync(_ => _.InstanceLabel != null && _.InstanceLabel.Contains(filter), paginationFilter);
        }

        /// <inheritdoc />
        public async Task<T> AddAsync(T model)
        {
            if (!model.TryCheckCreate())
            {
                throw new EntityNotValidException();
            }
            return await Repository.AddAsync(model);
        }

        /// <inheritdoc />
        public async Task<T> UpdateAsync(T model)
        {
            return await Repository.UpdateAsync(model);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(T model)
        {
            return await Repository.DeleteAsync(model);
        }

        /// <inheritdoc />
        public async Task<T> GetById(Guid id)
        {
            var entity = await TryGetById(id);
            return entity ?? throw new EntityNotFoundException();
        }

        /// <inheritdoc />
        public async Task<T?> TryGetById(Guid id)
        {
            return await Repository.GetById(id);
        }

        /// <inheritdoc />
        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await Repository.GetAsync(expression);
        }

        /// <inheritdoc />
        public async Task<IPaginatedList<T>> ListAsync(Expression<Func<T, bool>> expression, IPaginationFilter paginationFilter)
        {
            return await Repository.ListAsync(expression, paginationFilter);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await Repository.DeleteByIdAsync(id);
        }
    }
}