namespace Mastodon.Models;

/// <summary>
/// Represents the relationship between accounts, such as following/blocking/muting/etc.
/// </summary>
public sealed partial class Relationship
{
    /// <summary>
    /// The account ID.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Are you following this user?
    /// </summary>
    public required bool Following { get; set; }

    /// <summary>
    /// Are you receiving this user’s boosts in your home timeline?
    /// </summary>
    public required bool ShowingReblogs { get; set; }

    /// <summary>
    /// Have you enabled notifications for this user?
    /// </summary>

    public required bool Notifying { get; set; }

    /// <summary>
    /// Which languages are you following from this user?
    /// </summary>
    public required List<string> Languages { get; set; }

    /// <summary>
    /// Are you followed by this user?
    /// </summary>
    public required bool FollowedBy { get; set; }

    /// <summary>
    /// Are you blocking this user?
    /// </summary>
    public required bool Blocking { get; set; }

    /// <summary>
    /// Is this user blocking you?
    /// </summary>
    public required bool BlockedBy { get; set; }

    /// <summary>
    /// Are you muting this user?
    /// </summary>
    public required bool Muting { get; set; }

    /// <summary>
    /// Are you muting notifications from this user?
    /// </summary>
    public required bool MutingNotifications { get; set; }

    /// <summary>
    /// Do you have a pending follow request for this user?
    /// </summary>
    public required bool Requested { get; set; }

    /// <summary>
    /// Are you blocking this user’s domain?
    /// </summary>
    public required bool DomainBlocking { get; set; }

    /// <summary>
    /// Are you featuring this user on your profile?
    /// </summary>
    public required bool Endorsed { get; set; }

    /// <summary>
    /// This user’s profile bio
    /// </summary>
    public required string Note { get; set; }
}
