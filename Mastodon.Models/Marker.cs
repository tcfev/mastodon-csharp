namespace Mastodon.Models;

/// <summary>
/// Represents the last read position within a user's timelines.
/// </summary>
public sealed partial class Marker
{
    /// <summary>
    /// The ID of the most recently viewed entity.
    /// </summary>
    public required string LastReadId { get; set; }

    /// <summary>
    /// An incrementing counter, used for locking to prevent write conflicts.
    /// </summary>
    public required int Version { get; set; }

    /// <summary>
    /// The timestamp of when the marker was set.
    /// </summary>
    public required DateTime UpdatedAt { get; set; }
}
