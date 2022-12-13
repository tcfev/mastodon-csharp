namespace Mastodon.Messages;

/// <summary>
/// Represents an extended description for the instance, to be shown on its about page.
/// </summary>
public sealed class ExtendedDescription
{
    /// <summary>
    /// A timestamp of when the extended description was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The rendered HTML content of the extended description.
    /// </summary>
    public required string Content { get; set; }
}
