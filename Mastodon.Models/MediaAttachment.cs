namespace Mastodon.Models;

/// <summary>
/// Represents a file or media attachment that can be added to a status.
/// </summary>
public sealed partial class MediaAttachment
{
    /// <summary>
    /// The ID of the attachment in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The type of the attachment.
    /// <para>unknown = unsupported or unrecognized file type.</para>
    /// <para>image = Static image.</para>
    /// <para>gifv = Looping, soundless animation.</para>
    /// <para>video = Video clip.</para>
    /// <para>audio = Audio track.</para>
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// The location of the original full-size attachment.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// The location of a scaled-down preview of the attachment.
    /// </summary>
    public required string PreviewUrl { get; set; }

    /// <summary>
    /// The location of the full-size original attachment on the remote website.
    /// </summary>
    public string? RemoteUrl { get; set; }

    /// <summary>
    /// Metadata returned by Paperclip.
    /// </summary>
    public required MetaHash Meta { get; set; }

    /// <summary>
    /// Alternate text that describes what is in the media attachment, to be used for the visually impaired or when media attachments do not load.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// A hash computed by the BlurHash algorithm, for generating colorful preview thumbnails when media has not been downloaded yet.
    /// </summary>
    public string? Blurhash { get; set; }

    /// <summary>
    /// A shorter URL for the attachment.
    /// </summary>
    [Obsolete]
    public string? TextUrl { get; set; }

    /// <summary>
    /// May contain subtrees small and original, as well as various other top-level properties.
    /// More importantly, there may be another topl-level focus Hash object on images as of 2.3.0, with coordinates can be used for smart thumbnail cropping – see Focal points for cropped media thumbnails for more.
    /// </summary>
    public sealed partial class MetaHash
    {
        public string? Length { get; set; }
        public float? Duration { get; set; }
        public int? Fps { get; set; }
        public string? Size { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public float? Aspect { get; set; }
        public string? AudioEncode { get; set; }
        public string? AudioBitrate { get; set; }
        public string? AudioChannels { get; set; }
        public OriginalHash? Original { get; set; }
        public SmallHash? Small { get; set; }

        public sealed partial class OriginalHash
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public string? FrameRate { get; set; }
            public float? Duration { get; set; }
            public int? Bitrate { get; set; }
        }

        public sealed partial class SmallHash
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public string? Size { get; set; }
            public required float Aspect { get; set; }
        }
    }
}
