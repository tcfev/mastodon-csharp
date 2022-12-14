using System.Text.Json.Serialization;

namespace Mastodon.Models;

/// <summary>
/// Represents a user's preferences.
/// </summary>
public sealed partial class Preferences
{
    [JsonExtensionData]
    public Dictionary<string, object> Additional { get; } = new Dictionary<string, object>();
}
