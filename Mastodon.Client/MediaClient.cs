using Mastodon.Models;
using System.Net.Http.Json;

namespace Mastodon.Client;

public sealed class MediaClient
{
    private readonly MastodonClient _client;

    internal MediaClient(MastodonClient client)
    {
        _client = client;
    }

    public Task<MediaAttachment?> GetMediaAsync(string id)
    {
        return _client.http.GetFromJsonAsync<MediaAttachment>($"api/v1/media/{id}", MastodonClient._options);
    }
}
