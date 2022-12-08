﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mastodon;

partial class MastodonClient
{
    public sealed class TimelineClient
    {
        private readonly MastodonClient _client;

        internal TimelineClient(MastodonClient client)
        {
            _client = client;
        }

        /// <summary>
        /// View public statuses.
        /// </summary>
        public Task<List<Status>?> GetPublicAsync()
        {
            return _client.http.GetFromJsonAsync<List<Status>>("api/v1/timelines/public", _options);
        }

        /// <summary>
        /// View statuses from followed users.
        /// </summary>
        public Task<List<Status>?> GetHomeAsync()
        {
            return _client.http.GetFromJsonAsync<List<Status>>("api/v1/timelines/home", _options);
        }

        /// <summary>
        /// View public statuses containing the given hashtag.
        /// </summary>
        /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
        public Task<List<Status>?> GetTagAsync(string hashtag)
        {
            return _client.http.GetFromJsonAsync<List<Status>>($"api/v1/timelines/tag/{hashtag}", _options);
        }

        /// <summary>
        /// View statuses in the given list timeline.
        /// </summary>
        /// <param name="listId">Local ID of the List in the database.</param>
        public Task<List<Status>?> GetListAsync(string listId)
        {
            return _client.http.GetFromJsonAsync<List<Status>>($"api/v1/timelines/list/{listId}", _options);
        }

        /// <summary>
        /// View statuses with a “direct” privacy, from your account or in your notifications.
        /// </summary>
        [Obsolete]
        public Task<List<Status>?> GetDirectAsync()
        {
            return _client.http.GetFromJsonAsync<List<Status>>("api/v1/timelines/direct", _options);
        }
    }
}