namespace Mastodon.Models;
/// <summary>
/// Represents a filter whose keywords matched a given status.
/// </summary>
public sealed partial class FilterResult
{
    /// <summary>
    /// The filter that was matched.
    /// </summary>
    public required Filter Filter { get; set; }

    /// <summary>
    /// The keyword within the filter that was matched.
    /// </summary>
    public List<string>? KeywordMatches { get; set; }

    /// <summary>
    /// The status ID within the filter that was matched.
    /// </summary>
    public List<string>? StatusMatches { get; set; }
}
