using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Core.Pagination;

// <inheritdoc />
public class PaginatedList<T> : IPaginatedList<T> where T : class
{
    // <inheritdoc />
    public List<T> Items { get; set; }
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages { get; private set; }
    public int TotalCount { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;

        Items = [.. items];
    }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    /// <summary>
    /// Create a paginated list from the full list and the pagination data (performs the pagination.)
    /// </summary>
    /// <param name="source"></param>
    /// <param name="paginationFilter"></param>
    /// <returns>The paginated list</returns>
    public static async Task<IPaginatedList<T>> CreateAsync(IQueryable<T> source, IPaginationFilter paginationFilter)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((paginationFilter.PageIndex - 1) * paginationFilter.PageSize).Take(paginationFilter.PageSize).ToListAsync();
        return new PaginatedList<T>(items, count, paginationFilter.PageIndex, paginationFilter.PageSize);
    }
}