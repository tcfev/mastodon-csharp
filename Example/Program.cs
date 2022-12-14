﻿var client = new Mastodon.Client.MastodonClient(new Uri("https://mastodon.lol"));

var statuses = await client.Timeline.GetPublicAsync();
var instance = await client.Instance.GetInstanceAsync();
var extendedDescription = await client.Instance.GetExtendedDescriptionAsync();
var conversations = await client.Conversations.GetConversationsAsync();
//var media = await client.Media.GetMediaAsync("109500199520793100");

Console.WriteLine(statuses);