namespace Mastodon.Models;

/// <summary>
/// Represents the results of a search.
/// </summary>
public sealed partial class Search
{
    /// <summary>
    /// Accounts which match the given query.
    /// </summary>
    public required List<Account> Accounts
    {
        get;
        set;
    }

    /// <summary>
    /// Statuses which match the given query.
    /// </summary>
    public required List<Status> Statuses
    {
        get;
        set;
    }

    /// <summary>
    /// Hashtags which match the given query.
    /// </summary>
    public required List<Tag> Hashtags
    {
        get;
        set;
    }
}
