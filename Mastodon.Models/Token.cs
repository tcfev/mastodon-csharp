namespace Mastodon.Models;

/// <summary>
/// Represents an OAuth token used for authenticating with the API and performing actions.
/// </summary>
public sealed partial class Token
{
    /// <summary>
    /// An OAuth token to be used for authorization.
    /// </summary>
    public required string AccessToken { get; set; }

    /// <summary>
    /// The OAuth token type. Mastodon uses Bearer tokens.
    /// </summary>
    public required string TokenType { get; set; }

    /// <summary>
    /// The OAuth scopes granted by this token, space-separated.
    /// </summary>
    public required string Scope { get; set; }

    /// <summary>
    /// When the token was generated.
    /// </summary>
    public required ulong CreatedAt { get; set; }
}
