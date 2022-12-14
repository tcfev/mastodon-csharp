namespace Mastodon.Models;

/// <summary>
/// Represents a status that will be published at a future scheduled date.
/// </summary>
public sealed partial class ScheduledStatus
{
    /// <summary>
    /// ID of the scheduled status in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Timestamp.
    /// </summary>
    public required DateTime ScheduledAt { get; set; }

    /// <summary>
    /// The parameters to be used when the status is posted.
    /// </summary>
    public required ParamsHash Params { get; set; }

    /// <summary>
    /// Media that will be attached when the status is posted.
    /// </summary>
    public required List<MediaAttachment> MediaAttachments { get; set; }

    /// <summary>
    /// The parameters to be used when the status is posted.
    /// </summary>
    public sealed partial class ParamsHash
    {
        public string? Text { get; set; }
        public List<string>? MediaIds { get; set; }
        public bool? Sensitive { get; set; }
        public string? SpoilerText { get; set; }
        public string? Visibility { get; set; }
        public string? Language { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public Poll? Poll { get; set; }
        public object? Idempotency { get; set; }
        public bool? WithRateLimit { get; set; }
        public string? InReplyToId { get; set; }
        public object? ApplicationId { get; set; }
    }
}
