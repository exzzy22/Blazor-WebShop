using System.Text.Json.Serialization;

namespace Shared.RequestFeatures;

[JsonDerivedType(typeof(ReviewMetaData), 1)]
public class MetaData
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}