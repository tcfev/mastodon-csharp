using Google.Protobuf.WellKnownTypes;

namespace Mastodon;

public static class DateTimeExtensionMethods
{
    public static Timestamp ToGrpc(this System.DateTime i)
    {
        return Timestamp.FromDateTime(i.ToUniversalTime());
    }
}
