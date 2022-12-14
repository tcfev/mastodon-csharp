namespace Mastodon.Models;

/// <summary>
/// Represents a rule that server users should follow.
/// </summary>
public sealed partial class Rule
{
    /// <summary>
    /// An identifier for the rule.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The rule to be followed.
    /// </summary>
    public required string Text { get; set; }
}
