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

    static JsonSerializerOptions _options = new System.Text.Json.JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
    };
    public MastodonClient(Uri baseAddress)
    {
        http = new HttpClient { BaseAddress = baseAddress };
        Timeline = new TimelineClient(this);
    }

    public Task<Instance?> GetInstanceAsync()
    {
        return http.GetFromJsonAsync<Instance>("api/v2/instance");
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
