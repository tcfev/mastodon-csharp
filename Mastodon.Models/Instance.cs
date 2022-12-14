using System.Text.Json.Serialization;

namespace Mastodon.Models;

public sealed partial class Instance
{
    /// <summary>
    /// The domain name of the instance.
    /// </summary>
    public required string Domain { get; set; }

    /// <summary>
    /// The title of the website.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// The version of Mastodon installed on the instance.
    /// </summary>
    public required string Version { get; set; }

    /// <summary>
    /// The URL for the source code of the software running on this instance, in keeping with AGPL license requirements.
    /// </summary>
    public string? SourceUrl { get; set; }

    /// <summary>
    /// A short, plain-text description defined by the admin.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Usage data for this instance.
    /// </summary>
    public required UsageHash Usage { get; set; }

    /// <summary>
    /// An image used to represent this instance.
    /// </summary>
    public required ThumbnailHash Thumbnail { get; set; }

    /// <summary>
    /// Primary languages of the website and its staff.
    /// </summary>
    public required List<string> Languages { get; set; }

    /// <summary>
    /// Configured values and limits for this website.
    /// </summary>
    public required ConfigurationHash Configuration { get; set; }

    /// <summary>
    /// Information about registering for this website.
    /// </summary>
    public required RegistrationsHash Registrations { get; set; }

    /// <summary>
    /// Hints related to contacting a representative of the website.
    /// </summary>
    public required ContactHash Contact { get; set; }

    /// <summary>
    /// An itemized list of rules for this website.
    /// </summary>
    public required Rule[] Rules { get; set; }

    /// <summary>
    /// Usage data for this instance.
    /// </summary>
    public sealed partial class UsageHash
    {
        /// <summary>
        /// Usage data related to users on this instance.
        /// </summary>

        public required UsersHash Users { get; set; }

        /// <summary>
        /// Usage data related to users on this instance.
        /// </summary>
        public sealed partial class UsersHash
        {
            /// <summary>
            /// The number of active users in the past 4 weeks.
            /// </summary>
            public uint ActiveMonth { get; set; }
        }
    }

    /// <summary>
    /// An image used to represent this instance.
    /// </summary>
    public sealed partial class ThumbnailHash
    {
        /// <summary>
        /// The URL for the thumbnail image.
        /// </summary>
        public required string Url { get; set; }

        /// <summary>
        /// A hash computed by the BlurHash algorithm, for generating colorful preview thumbnails when media has not been downloaded yet.
        /// </summary>
        public string? Blurhash { get; set; }

        /// <summary>
        /// Links to scaled resolution images, for high DPI screens.
        /// </summary>
        public VersionsHash? Versions { get; set; }

        public sealed partial class VersionsHash
        {
            /// <summary>
            /// The URL for the thumbnail image at 1x resolution.
            /// </summary>
            [JsonPropertyName("@1x")]
            public string? _1x { get; set; }

            /// <summary>
            /// The URL for the thumbnail image at 2x resolution.
            /// </summary>
            [JsonPropertyName("@2x")]
            public string? _2x { get; set; }
        }
    }

    /// <summary>
    /// Hints related to contacting a representative of the website.
    /// </summary>
    public sealed partial class ContactHash
    {
        /// <summary>
        /// An email address that can be messaged regarding inquiries or issues.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// An account that can be contacted natively over the network regarding inquiries or issues.
        /// </summary>
        public required Account Account { get; set; }
    }

    /// <summary>
    /// Configured values and limits for this website.
    /// </summary>
    public sealed partial class ConfigurationHash
    {
        /// <summary>
        /// URLs of interest for clients apps.
        /// </summary>
        public required UrlsHash Urls { get; set; }

        /// <summary>
        /// Limits related to accounts.
        /// </summary>
        public required AccountsHash Accounts { get; set; }

        /// <summary>
        /// Limits related to authoring statuses.
        /// </summary>
        public required StatusesHash Statuses { get; set; }

        /// <summary>
        /// Hints for which attachments will be accepted.
        /// </summary>
        public MediaAttachmentsHash? MediaAttachments { get; set; }

        /// <summary>
        /// Limits related to polls.
        /// </summary>
        public required PollsHash Polls { get; set; }

        /// <summary>
        /// Hints related to translation.
        /// </summary>
        public required TranslationHash Translation { get; set; }

        /// <summary>
        /// URLs of interest for clients apps.
        /// </summary>
        public sealed partial class UrlsHash
        {
            /// <summary>
            /// The Websockets URL for connecting to the streaming API.
            /// </summary>
            public required string Streaming { get; set; }
        }

        /// <summary>
        /// Limits related to accounts.
        /// </summary>
        public sealed partial class AccountsHash
        {
            /// <summary>
            /// The maximum number of featured tags allowed for each account.
            /// </summary>
            public uint? MaxFeaturedTags { get; set; }
        }

        /// <summary>
        /// Limits related to authoring statuses.
        /// </summary>
        public sealed partial class StatusesHash
        {
            /// <summary>
            /// The maximum number of allowed characters per status.
            /// </summary>
            public uint? MaxCharacters { get; set; }

            /// <summary>
            /// The maximum number of media attachments that can be added to a status.
            /// </summary>
            public uint? MaxMediaAttachments { get; set; }

            /// <summary>
            /// Each URL in a status will be assumed to be exactly this many characters.
            /// </summary>
            public uint? CharactersReservedPerUrl { get; set; }
        }

        /// <summary>
        /// Hints for which attachments will be accepted.
        /// </summary>
        public sealed partial class MediaAttachmentsHash
        {
            /// <summary>
            /// Contains MIME types that can be uploaded.
            /// </summary>
            public required List<string> SupportedMimeTypes { get; set; }

            /// <summary>
            /// The maximum size of any uploaded image, in bytes.
            /// </summary>
            public required uint ImageSizeLimit { get; set; }

            /// <summary>
            /// The maximum number of pixels (width times height) for image uploads.
            /// </summary>
            public required uint ImageMatrixLimit { get; set; }

            /// <summary>
            /// The maximum size of any uploaded video, in bytes.
            /// </summary>
            public required uint VideoSizeLimit { get; set; }

            /// <summary>
            /// The maximum frame rate for any uploaded video.
            /// </summary>
            public required uint VideoFrameRateLimit { get; set; }

            /// <summary>
            /// The maximum number of pixels (width times height) for video uploads.
            /// </summary>
            public required uint VideoMatrixLimit { get; set; }
        }

        /// <summary>
        /// Limits related to polls.
        /// </summary>
        public sealed partial class PollsHash
        {
            /// <summary>
            /// Each poll is allowed to have up to this many options.
            /// </summary>
            public uint? MaxOptions { get; set; }

            /// <summary>
            /// Each poll option is allowed to have this many characters.
            /// </summary>
            public uint? MaxCharactersPerOption { get; set; }

            /// <summary>
            /// The shortest allowed poll duration, in seconds.
            /// </summary>
            public uint? MinExpiration { get; set; }

            /// <summary>
            /// The longest allowed poll duration, in seconds.
            /// </summary>
            public uint? MaxExpiration { get; set; }
        }

        /// <summary>
        /// Hints related to translation.
        /// </summary>
        public sealed partial class TranslationHash
        {
            /// <summary>
            /// Whether the Translations API is available on this instance.
            /// </summary>
            public required bool Enabled { get; set; }
        }
    }

    /// <summary>
    /// Information about registering for this website.
    /// </summary>
    public sealed partial class RegistrationsHash
    {
        /// <summary>
        /// Whether registrations are enabled.
        /// </summary>
        public required bool Enabled { get; set; }

        /// <summary>
        /// Whether registrations require moderator approval.
        /// </summary>
        public bool? ApprovalRequired { get; set; }

        /// <summary>
        /// A custom message to be shown when registrations are closed.
        /// </summary>
        public string? Message { get; set; }
    }
}
