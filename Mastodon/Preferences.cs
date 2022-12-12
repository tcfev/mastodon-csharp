﻿using System.Text.Json.Serialization;

namespace Mastodon;

/// <summary>
/// Represents a user's preferences.
/// </summary>
public sealed class Preferences
{
    [JsonExtensionData]
    public Dictionary<string, object> Additional { get; } = new Dictionary<string, object>();
}
