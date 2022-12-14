namespace Mastodon.Models;

/// <summary>
/// Represents a revision of a status that has been edited.
/// </summary>
public sealed partial class StatusEdit
{
    /// <summary>
    /// The content of the status at this revision.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// The content of the subject or content warning at this revision.
    /// </summary>
    public required string SpoilerText { get; set; }

    /// <summary>
    /// Whether the status was marked sensitive at this revision.
    /// </summary>
    public required bool Sensitive { get; set; }

    /// <summary>
    /// The timestamp of when the revision was published.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The account that published this revision.
    /// </summary>
    public required Account Account { get; set; }

    /// <summary>
    /// The current state of the poll options at this revision. Note that edits changing the poll options will be collapsed together into one edit, since this action resets the poll.
    /// </summary>
    public Poll? Poll { get; set; }

    /// <summary>
    /// The current state of the poll options at this revision. Note that edits changing the poll options will be collapsed together into one edit, since this action resets the poll.
    /// </summary>
    public required List<MediaAttachment> MediaAttachments { get; set; }

    /// <summary>
    /// Any custom emoji that are used in the current revision.
    /// </summary>
    public required List<CustomEmoji> Emojis { get; set; }
}
