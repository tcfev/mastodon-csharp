using System.Text;
using System.Text.Json;

namespace Mastodon.Client;

public sealed class MastodonClient
{
    internal readonly HttpClient http;
    public readonly TimelineClient Timeline;
    public readonly InstanceClient Instance;
    public readonly MediaClient Media;
    public readonly StatusClient Statuses;
    public readonly AccountClient Accounts;
    public readonly PollClient Polls;
    public readonly ConversationClient Conversations;

    internal static JsonSerializerOptions _options = new()
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
        Polls = new PollClient(this);
        Conversations = new ConversationClient(this);
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
