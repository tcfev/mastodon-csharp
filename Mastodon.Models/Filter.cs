namespace Mastodon.Models;

/// <summary>
/// Represents a user-defined filter for determining which statuses should not be shown to the user.
/// </summary>
public sealed partial class Filter
{
    /// <summary>
    /// The ID of the Filter in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// A title given by the user to name the filter.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// The contexts in which the filter should be applied.</para>
    /// <para>home = home timeline and lists.</para>
    /// <para>notifications = notifications timeline.</para>
    /// <para>public = public timelines.</para>
    /// <para>thread = expanded thread of a detailed status.</para>
    /// <para>account = when viewing a profile.</para>
    /// </summary>
    public required List<string> Context { get; set; }

    /// <summary>
    /// When the filter should no longer be applied.
    /// </summary>
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// The action to be taken when a status matches this filter.
    /// <para>warn = show a warning that identifies the matching filter by title, and allow the user to expand the filtered status. This is the default (and unknown values should be treated as equivalent to warn).</para>
    /// <para>hide = do not show this status if it is received.</para>
    /// </summary>
    public required string FilterAction { get; set; }

    /// <summary>
    /// The keywords grouped under this filter.
    /// </summary>
    public required FilterKeyword[] Keywords { get; set; }

    /// <summary>
    /// The statuses grouped under this filter.
    /// </summary>
    public required FilterStatus[] Statuses { get; set; }
}
