using Google.Protobuf.WellKnownTypes;
using Mastodon.Grpc;

namespace Mastodon;

public static class AccountExtensionMethods
{
    public static Grpc.Account ToGrpc(this Mastodon.Models.Account i)
    {
        var v = new Account
        {
            Id = i.Id,
            Acct = i.Acct,
            Avatar = i.Avatar,
            AvatarStatic = i.AvatarStatic,
            DisplayName = i.DisplayName,
            Header = i.Header,
            HeaderStatic = i.HeaderStatic,
            Locked = i.Locked,
            Note = i.Note,
            Url = i.Url,
            Username = i.Username,
            Bot = i.Bot,
            Group = i.Group,
            Limited = i.Limited,
            Suspended = i.Suspended,
            Role = i.Role?.ToGrpc(),
            Source = i.Source?.ToGrpc(),
            Moved = i.Moved?.ToGrpc(),
            CreatedAt = i.CreatedAt?.ToGrpc(),
            LastStatusAt = i.LastStatusAt?.ToGrpc(),
        };

        if (i.Discoverable != null)
        {
            v.Discoverable = i.Discoverable.Value;
        }

        if (i.FollowersCount != null)
        {
            v.FollowersCount = i.FollowersCount.Value;
        }

        if (i.FollowingCount != null)
        {
            v.FollowingCount = i.FollowingCount.Value;
        }

        if (i.StatusesCount != null)
        {
            v.StatusesCount = i.StatusesCount.Value;
        }


        v.Fields.AddRange(i.Fields.Select(x => x.ToGrpc()));
        v.Emojis.AddRange(i.Emojis.Select(x => x.ToGrpc()));

        return v;
    }

    public static Grpc.Account.Types.Source ToGrpc(this Mastodon.Models.Account.SourceHash i)
    {
        var v = new Account.Types.Source
        {
            FollowRequestsCount = i.FollowRequestsCount,
            Language = i.Language,
            Note = i.Note,
            Privacy = i.Privacy,
            Sensitive = i.Sensitive,
        };

        v.Fields.AddRange(i.Fields.Select(x => x.ToGrpc()));

        return v;
    }

    public static Grpc.Account.Types.Field ToGrpc(this Mastodon.Models.Account.FieldHash i)
    {
        var v = new Account.Types.Field
        {
            Name = i.Name,
            Value = i.Value,
        };

        if (i.VerifiedAt != null)
        {
            v.VerifiedAt = Timestamp.FromDateTime(i.VerifiedAt.Value.ToUniversalTime());
        }

        return v;
    }
}
