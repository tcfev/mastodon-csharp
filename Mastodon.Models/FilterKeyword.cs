namespace Mastodon.Models;

/// <summary>
/// Represents a keyword that, if matched, should cause the filter action to be taken.
/// </summary>
public sealed partial class FilterKeyword
{
    /// <summary>
    /// The ID of the FilterKeyword in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The phrase to be matched against.
    /// </summary>
    public required string Keyword { get; set; }

    /// <summary>
    /// Should the filter consider word boundaries? See implementation guidelines for filters.
    /// </summary>
    public required bool WholeWord { get; set; }
}
