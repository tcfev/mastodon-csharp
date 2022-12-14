namespace Mastodon.Models;

/// <summary>
/// Represents a hashtag that is featured on a profile.
/// </summary>
public sealed partial class FeaturedTag
{
    /// <summary>
    /// The internal ID of the featured tag in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The name of the hashtag being featured.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// A link to all statuses by a user that contain this hashtag.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// The number of authored statuses containing this hashtag.
    /// </summary>
    public required int StatusesCount { get; set; }

    /// <summary>
    /// The timestamp of the last authored status containing this hashtag.
    /// </summary>
    public required DateTime LastStatusAt { get; set; }
}
