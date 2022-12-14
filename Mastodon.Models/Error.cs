namespace Mastodon.Models;

/// <summary>
/// Represents an error message.
/// </summary>
public sealed partial class ErrorMessage
{
    /// <summary>
    /// The error message.
    /// </summary>
    public required string Error { get; set; }

    /// <summary>
    /// A longer description of the error, mainly provided with the OAuth API.
    /// </summary>
    public required string ErrorDescription { get; set; }
}
