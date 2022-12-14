namespace Mastodon.Models;

/// <summary>
/// Represents a poll attached to a status.
/// </summary>
public sealed partial class Poll
{
    /// <summary>
    /// The ID of the poll in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// When the poll ends.
    /// </summary>
    public required DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Is the poll currently expired?
    /// </summary>
    public required bool Expired { get; set; }

    /// <summary>
    /// Does the poll allow multiple-choice answers?
    /// </summary>
    public required bool Multiple { get; set; }

    /// <summary>
    /// How many votes have been received.
    /// </summary>
    public required uint VotesCount { get; set; }

    /// <summary>
    /// How many unique accounts have voted on a multiple-choice poll.
    /// </summary>
    public uint? VotersCount { get; set; }

    /// <summary>
    /// Possible answers for the poll.
    /// </summary>
    public required List<Option> Options { get; set; }

    /// <summary>
    /// Custom emoji to be used for rendering poll options.
    /// </summary>
    public required List<CustomEmoji> Emojis { get; set; }

    /// <summary>
    /// When called with a user token, has the authorized user voted?
    /// </summary>
    public bool? Voted { get; set; }

    /// <summary>
    /// When called with a user token, which options has the authorized user chosen? Contains an array of index values for options.
    /// </summary>
    public List<int>? OwnVotes { get; set; }

    public sealed partial class Option
    {
        /// <summary>
        /// The text value of the poll option.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// The total number of received votes for this option.
        /// </summary>
        public int? VotesCount { get; set; }
    }
}
