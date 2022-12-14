namespace Mastodon.Models;

/// <summary>
/// Represents a status ID that, if matched, should cause the filter action to be taken.
/// </summary>
public sealed partial class FilterStatus
{
    /// <summary>
    /// The ID of the FilterStatus in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the filtered Status in the database.
    /// </summary>
    public required string StatusId { get; set; }
}
