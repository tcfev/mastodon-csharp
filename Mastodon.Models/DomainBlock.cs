namespace Mastodon.Models;

/// <summary>
/// Represents a domain that is blocked by the instance.
/// </summary>
public sealed partial class DomainBlock
{
    /// <summary>
    /// The domain which is blocked. This may be obfuscated or partially censored.
    /// </summary>
    public required string Domain { get; set; }

    /// <summary>
    /// The SHA256 hash digest of the domain string.
    /// </summary>
    public required string Digest { get; set; }

    /// <summary>
    /// The level to which the domain is blocked.
    /// <para>silence = Users from this domain will be hidden from timelines, threads, and notifications (unless you follow the user).</para>
    /// <para>suspend = Incoming messages from this domain will be rejected and dropped entirely.</para>
    /// </summary>
    public required string Severity { get; set; }

    /// <summary>
    /// An optional reason for the domain block.
    /// </summary>
    public string? Comment { get; set; }
}
