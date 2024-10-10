using System.Linq.Expressions;
using Domain.Base;

namespace Domain.Interfaces
{
    /// <summary>
    /// Generic repository exposing the available operations against the database.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Add the given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The added entity.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update the given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The updated entity.</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Delete the entity associated with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the entity has been successfully deleted, false otherwise.</returns>
        Task<bool> DeleteByIdAsync(Guid id);

        /// <summary>
        /// Delete the given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True if the entity has been successfully deleted, false otherwise.</returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// Try to get the entity associated with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The entity or null if not found.</returns>
        Task<T?> GetById(Guid id);

        /// <summary>
        /// Try to get an entity matching the given expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>An entity or null if not found.</returns>
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Retrieve a paginated list of the entities matching the expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="paginationFilter"></param>
        /// <returns>A paginated list of the entities matching the expression.</returns>
        Task<IPaginatedList<T>> ListAsync(Expression<Func<T, bool>> expression, IPaginationFilter paginationFilter);
    }
}