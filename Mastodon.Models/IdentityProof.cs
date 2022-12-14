namespace Mastodon.Models;

/// <summary>
/// Identity proofs have been deprecated in 3.5.0 and newer.
/// Previously, the only proof provider was Keybase,
/// but development on Keybase has stalled entirely
/// since it was acquired by Zoom.
/// </summary>
public sealed partial class IdentityProof
{
    /// <summary>
    /// The name of the identity provider.
    /// </summary>
    public required string Provider { get; set; }

    /// <summary>
    /// The account owner’s username on the identity provider’s service.
    /// </summary>
    public required string ProviderUsername { get; set; }

    /// <summary>
    /// When the identity proof was last updated.
    /// </summary>
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// A link to a statement of identity proof, hosted by the identity provider.
    /// </summary>
    public required string ProofUrl { get; set; }

    /// <summary>
    /// The account owner’s profile URL on the identity provider.
    /// </summary>
    public required string ProfileUrl { get; set; }
}
