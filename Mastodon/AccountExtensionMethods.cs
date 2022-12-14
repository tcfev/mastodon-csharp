using Mastodon.Grpc;

namespace Mastodon;

public static class AccountExtensionMethods
{
    public static Grpc.Account ToGrpc(this Mastodon.Models.Account i)
    {
        return new Account
        {
            Id = i.Id,
        };
    }
}
