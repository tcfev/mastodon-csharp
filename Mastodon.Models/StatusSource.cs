namespace Mastodon.Models;

/// <summary>
/// Represents a status's source as plain text.
/// </summary>
public sealed partial class StatusSource
{
    /// <summary>
    /// ID of the status in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The plain text used to compose the status.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    /// The plain text used to compose the status’s subject or content warning.
    /// </summary>
    public required string SpoilerText { get; set; }
}
