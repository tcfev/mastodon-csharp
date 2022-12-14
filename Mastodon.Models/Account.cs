namespace Mastodon.Models;

/// <summary>
/// Represents a user of Mastodon and their associated profile.
/// </summary>
public sealed partial class Account
{
    /// <summary>
    /// The account id (cast from an integer, but not guaranteed to be a number).
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The username of the account, not including domain.
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// The Webfinger account URI. Equal to username for local users, or username@domain for remote users.
    /// </summary>
    public required string Acct { get; set; }

    /// <summary>
    /// The location of the user’s profile page.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// The profile’s display name.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// The profile’s bio or description.
    /// </summary>
    public required string Note { get; set; }

    /// <summary>
    /// An image icon that is shown next to statuses and in the profile.
    /// </summary>
    public required string Avatar { get; set; }

    /// <summary>
    /// A static version of the avatar. Equal to avatar if its value is a static image; different if avatar is an animated GIF.
    /// </summary>
    public string? AvatarStatic { get; set; }

    /// <summary>
    /// An image banner that is shown above the profile and in profile cards.
    /// </summary>
    public required string Header { get; set; }

    /// <summary>
    /// A static version of the header. Equal to header if its value is a static image; different if header is an animated GIF.
    /// </summary>
    public string? HeaderStatic { get; set; }

    /// <summary>
    /// Whether the account manually approves follow requests.
    /// </summary>
    public required bool Locked { get; set; }

    /// <summary>
    /// Additional metadata attached to a profile as name-value pairs.
    /// </summary>
    public required List<FieldHash> Fields { get; set; }

    /// <summary>
    /// Custom emoji entities to be used when rendering the profile.
    /// </summary>
    public required List<CustomEmoji> Emojis { get; set; }

    /// <summary>
    /// Indicates that the account may perform automated actions, may not be monitored, or identifies as a robot.
    /// </summary>
    public required bool Bot { get; set; }

    /// <summary>
    /// Indicates that the account represents a Group actor.
    /// </summary>
    public required bool Group { get; set; }

    /// <summary>
    /// Whether the account has opted into discovery features such as the profile directory.
    /// </summary>
    public bool? Discoverable { get; set; }

    /// <summary>
    /// Indicates that the profile is currently inactive and that its user has moved to a new account.
    /// </summary>
    public Account? Moved { get; set; }

    /// <summary>
    /// An extra attribute returned only when an account is suspended.
    /// </summary>
    public bool Suspended { get; set; }

    /// <summary>
    /// An extra attribute returned only when an account is silenced. If true, indicates that the account should be hidden behing a warning screen.
    /// </summary>
    public bool Limited { get; set; }

    /// <summary>
    /// When the account was created.
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the most recent status was posted.
    /// </summary>
    public DateTime? LastStatusAt { get; set; }

    /// <summary>
    /// How many statuses are attached to this account.
    /// </summary>
    public uint? StatusesCount { get; set; }
    /// <summary>
    /// The reported followers of this profile.
    /// </summary>
    public uint? FollowersCount { get; set; }

    /// <summary>
    /// The reported follows of this profile.
    /// </summary>
    public uint? FollowingCount { get; set; }

    /// <summary>
    /// An extra attribute that contains source values to be used with API methods that verify credentials and update credentials.
    /// </summary>
    public SourceHash? Source { get; set; }

    /// <summary>
    /// The role assigned to the currently authorized user.
    /// </summary>
    public Role? Role { get; set; }

    public sealed partial class MutedAccount
    {
        /// <summary>
        /// When a timed mute will expire, if applicable.
        /// </summary>
        public DateTime? MuteExpiresAt { get; set; }
    }

    public sealed partial class FieldHash
    {
        /// <summary>
        /// The key of a given field’s key-value pair.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The value associated with the name key.
        /// </summary>
        public required string Value { get; set; }

        /// <summary>
        /// Timestamp of when the server verified a URL value for a rel=“me” link.
        /// </summary>
        public DateTime? VerifiedAt { get; set; }
    }

    /// <summary>
    /// An extra attribute that contains source values to be used with API methods that verify credentials and update credentials.
    /// </summary>
    public sealed partial class SourceHash
    {
        /// <summary>
        /// Profile bio, in plain-text instead of in HTML.
        /// </summary>
        public required string Note { get; set; }

        /// <summary>
        /// Metadata about the account.
        /// </summary>
        public required List<FieldHash> Fields { get; set; }

        /// <summary>
        /// The default post privacy to be used for new statuses.
        /// 
        /// public = Public post
        /// unlisted = Unlisted post
        /// private = Followers-only post
        /// direct = Direct post
        /// </summary>
        public required string Privacy { get; set; }


        /// <summary>
        /// Whether new statuses should be marked sensitive by default.
        /// </summary>
        public required bool Sensitive { get; set; }

        /// <summary>
        /// The default posting language for new statuses.
        /// </summary>
        public required string Language { get; set; }

        /// <summary>
        /// The number of pending follow requests.
        /// </summary>
        public required uint FollowRequestsCount { get; set; }
    }
}
