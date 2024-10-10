namespace Domain.Interfaces;

/// <summary>
/// Pagination input.
/// </summary>
public interface IPaginationFilter
{
    /// <summary>
    /// Gets or sets the page number. The value is always greater than or equal to 1 (Base 1 index).
    /// </summary>
    int PageIndex { get; set; }

    /// <summary>
    /// Gets or sets the page size.
    /// </summary>
    int PageSize { get; set; }
}