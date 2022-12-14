namespace Mastodon.Models;

/// <summary>
/// Represents a status posted by an account.
/// </summary>
public sealed partial class Status
{
    /// <summary>
    /// ID of the status in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// URI of the status used for federation.
    /// </summary>
    public required string Uri { get; set; }

    /// <summary>
    /// The date when this status was created.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The account that authored this status.
    /// </summary>
    public required Account Account { get; set; }

    /// <summary>
    /// HTML-encoded status content.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// Visibility of this status.
    /// </summary>
    public required string Visibility { get; set; }

    /// <summary>
    /// Is this status marked as sensitive content.
    /// </summary>
    public required bool Sensitive { get; set; }

    /// <summary>
    /// Subject or summary line, below which status content is collapsed until expanded.
    /// </summary>
    public required string SpoilerText { get; set; }

    public required List<MediaAttachment> MediaAttachments { get; set; }

    /// <summary>
    /// The application used to post this status.
    /// </summary>
    public StatusApplication? Application { get; set; }

    /// <summary>
    /// Mentions of users within the status content.
    /// </summary>
    public required List<Mention> Mentions { get; set; }

    /// <summary>
    /// Hashtags used within the status content.
    /// </summary>
    public required List<Tag> Tags { get; set; }

    /// <summary>
    /// Custom emoji to be used when rendering status content.
    /// </summary>
    public required List<CustomEmoji> Emojis { get; set; }

    /// <summary>
    /// How many boosts this status has received.
    /// </summary>
    public required uint ReblogsCount { get; set; }

    /// <summary>
    /// How many favourites this status has received.
    /// </summary>
    public required uint FavouritesCount { get; set; }

    /// <summary>
    /// How many replies this status has received.
    /// </summary>
    public required uint RepliesCount { get; set; }

    /// <summary>
    /// A link to the status’s HTML representation.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// ID of the status being replied to.
    /// </summary>
    public string? InReplyToId { get; set; }

    /// <summary>
    /// ID of the account that authored the status being replied to.
    /// </summary>
    public string? InReplyToAccountId { get; set; }

    /// <summary>
    /// The status being reblogged.
    /// </summary>
    public Status? Reblog { get; set; }

    /// <summary>
    /// The poll attached to the status.
    /// </summary>
    public Poll? Poll { get; set; }

    /// <summary>
    /// Preview card for links included within status content.
    /// </summary>
    public PreviewCard? Card { get; set; }

    /// <summary>
    /// Primary language of this status.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// Plain-text source of a status. Returned instead of content when status is
    /// deleted, so the user may redraft from the source text without the client
    /// having to reverse-engineer the original text from the HTML content.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Timestamp of when the status was last edited.
    /// </summary>
    public required DateTime? EditedAt { get; set; }

    /// <summary>
    /// If the current token has an authorized user: Have you favourited this status?
    /// </summary>
    public bool Favourited { get; set; }


    /// <summary>
    /// If the current token has an authorized user: Have you boosted this status?
    /// </summary>
    public bool Reblogged { get; set; }


    /// <summary>
    /// If the current token has an authorized user: Have you muted notifications for this status’s conversation?
    /// </summary>
    public bool Muted { get; set; }


    /// <summary>
    /// If the current token has an authorized user: Have you bookmarked this status?
    /// </summary>
    public bool Bookmarked { get; set; }

    /// <summary>
    /// If the current token has an authorized user: Have you pinned this status? Only appears if the status is pinnable.
    /// </summary>
    public bool Pinned { get; set; }

    /// <summary>
    /// If the current token has an authorized user: The filter and keywords that matched this status.
    /// </summary>
    public List<FilterResult>? Filtered { get; set; }

    public sealed partial class StatusApplication
    {
        /// <summary>
        /// The name of the application that posted this status.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The website associated with the application that posted this status.
        /// </summary>
        public string? Website { get; set; }
    }

    public sealed partial class Mention
    {
        /// <summary>
        /// The account ID of the mentioned user (cast from an integer, but not guaranteed to be a number).
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// The username of the mentioned user.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// The location of the mentioned user’s profile.
        /// </summary>
        public required string Url { get; set; }

        /// <summary>
        /// The webfinger acct: URI of the mentioned user. Equivalent to username for local users, or username@domain for remote users.
        /// </summary>
        public required string Acct { get; set; }
    }
}
