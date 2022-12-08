﻿namespace Mastodon;

/// <summary>
/// Represents a custom emoji.
/// </summary>
public sealed class CustomEmoji
{
    /// <summary>
    /// The name of the custom emoji.
    /// </summary>
    public required string Shortcode { get; set; }

    /// <summary>
    /// A link to the custom emoji.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// A link to a static copy of the custom emoji.
    /// </summary>
    public required string StaticUrl { get; set; }

    /// <summary>
    /// Whether this Emoji should be visible in the picker or unlisted.
    /// </summary>
    public required bool VisibleInPicker { get; set; }

    /// <summary>
    /// Used for sorting custom emoji in the picker.
    /// </summary>
    public string? Category { get; set; }
}
