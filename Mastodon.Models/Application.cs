namespace Mastodon.Models;

public sealed partial class Application
{
    /// <summary>
    /// The name of your application.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The website associated with your application.
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Used for Push Streaming API. Returned with POST /api/v1/apps. Equivalent to WebPushSubscription#server_key
    /// </summary>
    public required string VapidKey { get; set; }

    /// <summary>
    /// Client ID key, to be used for obtaining OAuth tokens.
    /// </summary>
    public string? ClientId { get; set; }

    /// <summary>
    /// Client secret key, to be used for obtaining OAuth tokens.
    /// </summary>
    public string? ClientSecret { get; set; }
}