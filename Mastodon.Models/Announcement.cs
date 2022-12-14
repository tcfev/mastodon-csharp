namespace Mastodon.Models;

/// <summary>
/// Represents an announcement set by an administrator.
/// </summary>
public sealed partial class Announcement
{
    /// <summary>
    /// The ID of the announcement in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The text of the announcement.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// When the announcement will start.
    /// </summary>
    public DateTime? StartsAt { get; set; }

    /// <summary>
    /// When the announcement will end.
    /// </summary>
    public DateTime? EndsAt { get; set; }

    /// <summary>
    /// Whether the announcement should start and end on dates only instead of datetimes. Will be false if there is no StartsAt or EndsAt time.
    /// </summary>
    public bool AllDay { get; set; }

    /// <summary>
    /// When the announcement was published.
    /// </summary>
    public DateTime PublishedAt { get; set; }

    /// <summary>
    /// When the announcement was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Whether the announcement has been read by the current user.
    /// </summary>
    public bool? Read { get; set; }

    /// <summary>
    /// Accounts mentioned in the announcement text.
    /// </summary>
    public required List<Account> Mentions { get; set; }

    /// <summary>
    /// Statuses linked in the announcement text.
    /// </summary>
    public required List<Status> Statuses { get; set; }

    /// <summary>
    /// Tags linked in the announcement text.
    /// </summary>
    public required List<Tag> Tags { get; set; }

    /// <summary>
    /// Custom emoji used in the announcement text.
    /// </summary>
    public required List<CustomEmoji> Emojis { get; set; }

    /// <summary>
    /// Emoji reactions attached to the announcement.
    /// </summary>
    public required List<Reaction> Reactions { get; set; }
}
