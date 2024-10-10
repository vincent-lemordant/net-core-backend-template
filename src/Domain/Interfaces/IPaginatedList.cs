namespace Domain.Interfaces;

/// <summary>
/// Represents a list of entities and the metadata associated with it.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPaginatedList<T> where T : class
{
    /// <summary>
    /// The list of entities.
    /// </summary>
    public List<T> Items { get; set; }
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

}