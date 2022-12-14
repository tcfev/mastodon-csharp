namespace Mastodon.Models;

/// <summary>
/// Represents the tree around a given status. Used for reconstructing threads of statuses.
/// </summary>
public sealed partial class Context
{
    /// <summary>
    /// Parents in the thread.
    /// </summary>
    public required List<Status> Ancestors { get; set; }

    /// <summary>
    /// Children in the thread.
    /// </summary>
    public required List<Status> Descendants { get; set; }
}
