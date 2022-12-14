namespace Mastodon.Models;

/// <summary>
/// Represents a suggested account to follow and an associated reason for the suggestion.
/// </summary>
public sealed partial class Suggestion
{
    /// <summary>
    /// The reason this account is being suggested.
    /// 
    /// <para>staff = This account was manually recommended by your administration team.</para>
    /// <para>past_interactions = You have interacted with this account previously.</para>
    /// <para>global = This account has many reblogs, favourites, and active local followers within the last 30 days.</para>
    /// </summary>
    public required string Source
    {
        get; set;
    }

    public required Account Account
    {
        get; set;
    }
}
