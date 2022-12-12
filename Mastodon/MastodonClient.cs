using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mastodon;

public sealed partial class MastodonClient
{
    internal readonly HttpClient http;
    public readonly TimelineClient Timeline;
    public readonly InstanceClient Instance;
    public readonly MediaClient Media;
    public readonly StatusClient Statuses;
    public readonly AccountClient Accounts;

    static JsonSerializerOptions _options = new System.Text.Json.JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
    };

    public MastodonClient(Uri baseAddress)
    {
        http = new HttpClient { BaseAddress = baseAddress };
        Timeline = new TimelineClient(this);
        Instance = new InstanceClient(this);
        Media = new MediaClient(this);
        Statuses = new StatusClient(this);
        Accounts = new AccountClient(this);
    }

    public void SetAuthorizationToken(string token)
    {
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }


    private sealed class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => JsonUtils.ToSnakeCase(name);


        private static class JsonUtils
        {
            private enum SeparatedCaseState
            {
                Start,
                Lower,
                Upper,
                NewWord
            }

            public static string ToSnakeCase(string s) => ToSeparatedCase(s, '_');

            private static string ToSeparatedCase(string s, char separator)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return s;
                }

                StringBuilder sb = new StringBuilder();
                SeparatedCaseState state = SeparatedCaseState.Start;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        if (state != SeparatedCaseState.Start)
                        {
                            state = SeparatedCaseState.NewWord;
                        }
                    }
                    else if (char.IsUpper(s[i]))
                    {
                        switch (state)
                        {
                            case SeparatedCaseState.Upper:
                                bool hasNext = (i + 1 < s.Length);
                                if (i > 0 && hasNext)
                                {
                                    char nextChar = s[i + 1];
                                    if (!char.IsUpper(nextChar) && nextChar != separator)
                                    {
                                        sb.Append(separator);
                                    }
                                }
                                break;
                            case SeparatedCaseState.Lower:
                            case SeparatedCaseState.NewWord:
                                sb.Append(separator);
                                break;
                        }

                        char c;
                        c = char.ToLowerInvariant(s[i]);
                        sb.Append(c);

                        state = SeparatedCaseState.Upper;
                    }
                    else if (s[i] == separator)
                    {
                        sb.Append(separator);
                        state = SeparatedCaseState.Start;
                    }
                    else
                    {
                        if (state == SeparatedCaseState.NewWord)
                        {
                            sb.Append(separator);
                        }

                        sb.Append(s[i]);
                        state = SeparatedCaseState.Lower;
                    }
                }

                return sb.ToString();
            }
        }
    }
}


partial class MastodonClient
{
    public sealed class InstanceClient
    {
        private readonly MastodonClient _client;

        internal InstanceClient(MastodonClient client)
        {
            _client = client;
        }

        public Task<Instance?> GetInstanceAsync()
        {
            return _client.http.GetFromJsonAsync<Instance>("api/v2/instance");
        }

        public Task<ExtendedDescription?> GetExtendedDescriptionAsync()
        {
            return _client.http.GetFromJsonAsync<ExtendedDescription>("api/v1/instance/extended_description");
        }

        public Task<List<DomainBlock>?> GetDomainBlocksAsync()
        {
            return _client.http.GetFromJsonAsync<List<DomainBlock>>("api/v1/instance/domain_block");
        }
    }
}

partial class MastodonClient
{
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
            return _client.http.GetFromJsonAsync<StatusSource>($"api/v1/statuses/{id}/source");
        }

        /// <summary>
        /// Get all known versions of a status, including the initial and current states.
        /// </summary>
        /// <param name="id">The local ID of the Status in the database.</param>
        public Task<List<StatusEdit>?> GetHistoryAsync(string id)
        {
            return _client.http.GetFromJsonAsync<List<StatusEdit>>($"api/v1/statuses/{id}/history");
        }
    }
}


partial class MastodonClient
{
    public sealed class AccountClient
    {
        private readonly MastodonClient _client;

        internal AccountClient(MastodonClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Obtain a list of all accounts that follow a given account, filtered for accounts you follow.
        /// </summary>
        public Task<List<FamiliarFollowers>?> GetFamiliarFollowersAsync()
        {
            return _client.http.GetFromJsonAsync<List<FamiliarFollowers>>($"api/v1/accounts/familiar_followers");
        }
    }
}

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

        /// <summary>
        /// View public statuses.
        /// </summary>
        public Task<List<Status>?> GetTrendsAsync()
        {
            return _client.http.GetFromJsonAsync<List<Status>>("api/v1/trends/statuses", _options);
        }
    }
}


partial class MastodonClient
{
    public sealed class MediaClient
    {
        private readonly MastodonClient _client;

        internal MediaClient(MastodonClient client)
        {
            _client = client;
        }

        public Task<MediaAttachment?> GetMediaAsync(string id)
        {
            return _client.http.GetFromJsonAsync<MediaAttachment>($"api/v1/media/{id}", _options);
        }
    }
}
