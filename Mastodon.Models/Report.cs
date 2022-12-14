namespace Mastodon.Models;

/// <summary>
/// Reports filed against users and/or statuses, to be taken action on by moderators.
/// </summary>
public sealed partial class Report
{
    /// <summary>
    /// The ID of the report in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Whether an action was taken yet.
    /// </summary>
    public required bool ActionTaken { get; set; }

    /// <summary>
    /// When an action was taken against the report.
    /// </summary>
    public DateTime? ActionTakenAt { get; set; }

    /// <summary>
    /// The generic reason for the report.
    /// <para>spam = Unwanted or repetitive content</para>
    /// <para>violation = A specific rule was violated</para>
    /// <para>other = Some other reason</para>
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// The reason for the report.
    /// </summary>
    public required string Comment { get; set; }

    /// <summary>
    /// Whether the report was forwarded to a remote domain.
    /// </summary>
    public required bool Forwarded { get; set; }

    /// <summary>
    /// When the report was created.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The domain name of the instance.
    /// </summary>
    public List<string>? StatusIds { get; set; }

    /// <summary>
    /// The domain name of the instance.
    /// </summary>
    public List<string>? RuleIds { get; set; }

    /// <summary>
    /// The account that was reported.
    /// </summary>
    public required Account TargetAccount { get; set; }
}
