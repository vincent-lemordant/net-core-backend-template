using Domain.Interfaces;

namespace Infrastructure.Data.Core.Pagination;

// <inheritdoc />
public class PaginationFilter : IPaginationFilter
{
    // <inheritdoc />
    public int PageIndex { get; set; } = 1;

    // <inheritdoc />
    public int PageSize { get; set; } = 10;
}