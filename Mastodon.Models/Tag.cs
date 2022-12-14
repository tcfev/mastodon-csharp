namespace Mastodon.Models;

/// <summary>
/// Represents a hashtag used within the content of a status.
/// </summary>
public sealed partial class Tag
{
    /// <summary>
    /// The value of the hashtag after the # sign.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// A link to the hashtag on the instance.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Usage statistics for given days (typically the past week).
    /// </summary>
    public List<TagHistory>? History { get; set; }

    /// <summary>
    /// Whether the current token’s authorized user is following this tag.
    /// </summary>
    public bool? Following { get; set; }

    /// <summary>
    /// Usage statistics for given days (typically the past week).
    /// </summary>
    public sealed partial class TagHistory
    {
        /// <summary>
        /// UNIX timestamp on midnight of the given day.
        /// </summary>
        public required string Day { get; set; }

        /// <summary>
        /// The counted usage of the tag within that day.
        /// </summary>
        public required string Uses { get; set; }

        /// <summary>
        /// The total of accounts using the tag within that day.
        /// </summary>
        public required string Accounts { get; set; }
    }
}
