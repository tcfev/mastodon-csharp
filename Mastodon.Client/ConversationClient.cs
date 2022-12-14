
using Mastodon.Models;
using System.Net.Http.Json;

namespace Mastodon.Client;

public sealed class ConversationClient
{
    private readonly MastodonClient _client;

    internal ConversationClient(MastodonClient client)
    {
        _client = client;
    }


    /// <summary>
    /// Direct conversations with other participants. (Currently, just threads containing a post with "direct" visibility.)
    /// </summary>
    public Task<List<Conversation>?> GetConversationsAsync()
    {
        return _client.http.GetFromJsonAsync<List<Conversation>>($"api/v1/conversations", MastodonClient._options);
    }

    /// <summary>
    /// Removes a conversation from your list of conversations.
    /// </summary>
    /// <param name="id">The ID of the Conversation in the database.</param>
    /// <returns></returns>
    public Task DeleteAsync(string id)
    {
        return _client.http.DeleteAsync($"api/v1/conversations/{id}");
    }

    /// <summary>
    /// Removes a conversation from your list of conversations.
    /// </summary>
    /// <param name="id">The ID of the Conversation in the database.</param>
    /// <returns></returns>
    public async Task<Conversation?> MarkReadAsync(string id)
    {
        var result = await _client.http.PostAsync($"api/v1/conversations/{id}/read", new StringContent(string.Empty));
        return await result.Content.ReadFromJsonAsync<Conversation>();
    }
}
