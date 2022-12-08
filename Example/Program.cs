var client = new Mastodon.MastodonClient(new Uri("https://mastodon.lol"));

var statuses = await client.GetPublicTimelineAsync();

Console.WriteLine(statuses);