namespace Mastodon.Models;

/// <summary>
/// Represents a list of some users that the authenticated user follows.
/// </summary>
public sealed partial class List
{
    /// <summary>
    /// The internal database ID of the list.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The user-defined title of the list.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Which replies should be shown in the list.
    /// 
    /// <para>followed = Show replies to any followed user</para>
    /// <para>list = Show replies to members of the list</para>
    /// <para>none = Show replies to no one</para>
    /// </summary>
    public required string RepliesPolicy { get; set; }
}
