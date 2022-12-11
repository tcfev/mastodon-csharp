var client = new Mastodon.MastodonClient(new Uri("https://mastodon.lol"));

var statuses = await client.Timeline.GetPublicAsync();
var instance = await client.GetInstanceAsync();

Console.WriteLine(statuses);