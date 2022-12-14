namespace Mastodon.Models;


/// <summary>
/// Represents an emoji reaction to an Announcement.
/// </summary>
public sealed partial class Reaction
{
    /// <summary>
    /// The emoji used for the reaction. Either a unicode emoji, or a custom emoji’s shortcode.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The total number of users who have added this reaction.
    /// </summary>
    public required int Count { get; set; }

    /// <summary>
    /// If there is a currently authorized user: Have you added this reaction?
    /// </summary>
    public bool? Me { get; set; }

    /// <summary>
    /// If the reaction is a custom emoji: A link to the custom emoji.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// If the reaction is a custom emoji: A link to a non-animated version of the custom emoji.
    /// </summary>
    public string? StaticUrl { get; set; }
}
