using Mastodon.Grpc;

namespace Mastodon;

public static class RoleExtensionMethods
{
    public static Grpc.Role ToGrpc(this Mastodon.Models.Role i)
    {
        return new Role
        {
            Id = i.Id,
        };
    }
}
