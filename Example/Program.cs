var client = new Mastodon.MastodonClient(new Uri("https://mastodon.lol"));

var statuses = await client.Timeline.GetPublicAsync();
var s = await client.Timeline.GetTagAsync("something");

Console.WriteLine(statuses);