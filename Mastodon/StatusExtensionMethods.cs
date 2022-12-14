using Google.Protobuf.WellKnownTypes;

namespace Mastodon;

public static class StatusExtensionMethods
{
    public static Grpc.Status ToGrpc(this Mastodon.Models.Status i)
    {
        var v = new Grpc.Status
        {
            Account = i.Account.ToGrpc(),
            Id = i.Id,
            Bookmarked = i.Bookmarked,
            CreatedAt = Timestamp.FromDateTime(i.CreatedAt),
            Uri = i.Uri,
            Url = i.Url,
            Content = i.Content,
            Visibility = i.Visibility,
            SpoilerText = i.SpoilerText,
            Favourited = i.Favourited,
            FavouritesCount = i.FavouritesCount,
            Muted = i.Muted,
            Pinned = i.Pinned,
            Reblog = i.Reblog?.ToGrpc(),
            Reblogged = i.Reblogged,
        };

        if (i.InReplyToAccountId != null)
        {
            v.InReplyToAccountId = i.InReplyToAccountId;
        }

        if (i.InReplyToId != null)
        {
            v.InReplyToId = i.InReplyToId;
        }

        if (i.Language != null)
        {
            v.Language = i.Language;
        }

        if (i.Text != null)
        {
            v.Text = i.Text;
        }

        v.Tags.AddRange(i.Tags.Select(t => t.ToGrpc()));

        return v;
    }
}
