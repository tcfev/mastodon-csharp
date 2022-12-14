namespace Mastodon.Models;

/// <summary>
/// Represents a notification of an event relevant to the user.
/// </summary>
public sealed partial class Notification
{
    /// <summary>
    /// The id of the notification in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The type of event that resulted in the notification.
    /// <para>mention = Someone mentioned you in their status.</para>
    /// <para>status = Someone you enabled notifications for has posted a status.</para>
    /// <para>reblog = Someone boosted one of your statuses.</para>
    /// <para>follow = Someone followed you.</para>
    /// <para>follow_request = Someone requested to follow you.</para>
    /// <para>favourite = Someone favourited one of your statuses.</para>
    /// <para>poll = A poll you have voted in or created has ended.</para>
    /// <para>update = A status you interacted with has been edited.</para>
    /// <para>admin.sign_up = Someone signed up(optionally sent to admins).</para>
    /// <para>admin.report = A new report has been filed.</para>
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// The timestamp of the notification.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The account that performed the action that generated the notification.
    /// </summary>
    public required Account Account { get; set; }

    /// <summary>
    /// Status that was the object of the notification. Attached when type of the notification is favourite, reblog, status, mention, poll, or update.
    /// </summary>
    public Status? Status { get; set; }

    /// <summary>
    /// Report that was the object of the notification. Attached when type of the notification is admin.report.
    /// </summary>
    public Report? Report { get; set; }
}
