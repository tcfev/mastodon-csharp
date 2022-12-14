using Mastodon.Models;
using System.Net.Http.Json;

namespace Mastodon.Client;

public sealed class StatusClient
{
    private readonly MastodonClient _client;

    internal StatusClient(MastodonClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Obtain the source properties for a status so that it can be edited.
    /// </summary>
    /// <param name="id">The local ID of the Status in the database.</param>
    /// <returns></returns>
    public Task<StatusSource?> GetSourceAsync(string id)
    {
        return _client.http.GetFromJsonAsync<StatusSource>($"api/v1/statuses/{id}/source", MastodonClient._options);
    }

    /// <summary>
    /// Get all known versions of a status, including the initial and current states.
    /// </summary>
    /// <param name="id">The local ID of the Status in the database.</param>
    public Task<List<StatusEdit>?> GetHistoryAsync(string id)
    {
        return _client.http.GetFromJsonAsync<List<StatusEdit>>($"api/v1/statuses/{id}/history", MastodonClient._options);
    }
}
