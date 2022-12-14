namespace Mastodon.Models;

/// <summary>
/// Represents a subset of your follows who also follow some other user.
/// </summary>
public sealed partial class FamiliarFollowers
{
    /// <summary>
    /// The ID of the Account in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Accounts you follow that also follow this account.
    /// </summary>
    public required List<Account> Accounts { get; set; }
}
