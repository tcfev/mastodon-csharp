﻿using Mastodon.Messages;
using System.Net.Http.Json;

namespace Mastodon.Services;

public sealed class PollClient
{
    private readonly MastodonClient _client;

    internal PollClient(MastodonClient client)
    {
        _client = client;
    }

    public Task<Poll?> GetPollAsync(string id)
    {
        return _client.http.GetFromJsonAsync<Poll>($"api/v1/polls/{id}", MastodonClient._options);
    }
}
