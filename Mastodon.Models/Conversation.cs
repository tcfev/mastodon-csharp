namespace Mastodon.Models;

/// <summary>
/// Represents a conversation with "direct message" visibility.
/// </summary>
public sealed partial class Conversation
{
    /// <summary>
    /// The ID of the conversation in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Is the conversation currently marked as unread?
    /// </summary>
    public required bool Unread { get; set; }


    /// <summary>
    /// Participants in the conversation.
    /// </summary>
    public required List<Account> Accounts { get; set; }

    /// <summary>
    /// The last status in the conversation.
    /// </summary>
    public Status? LastStatus { get; set; }
}
