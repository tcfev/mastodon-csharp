using Mastodon.Grpc;

namespace Mastodon;

public static class EmojiExtensionMethods
{
    public static Grpc.CustomEmoji ToGrpc(this Mastodon.Models.CustomEmoji i)
    {
        return new CustomEmoji { Shortcode = i.Shortcode };
    }
}
