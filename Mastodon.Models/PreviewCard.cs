namespace Mastodon.Models;

/// <summary>
/// Represents a rich preview card that is generated using OpenGraph tags from a URL.
/// </summary>
public sealed partial class PreviewCard
{
    /// <summary>
    /// Location of linked resource.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Title of linked resource.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Description of preview.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// The type of the preview card.
    /// <para>link = Link OEmbed</para>
    /// <para>photo = Photo OEmbed</para>
    /// <para>video = Video OEmbed</para>
    /// <para>rich = iframe OEmbed. Not currently accepted, so won’t show up in practice.</para>
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// The author of the original resource.
    /// </summary>
    public required string AuthorName { get; set; }

    /// <summary>
    /// A link to the author of the original resource.
    /// </summary>
    public required string AuthorUrl { get; set; }

    /// <summary>
    /// The provider of the original resource.
    /// </summary>
    public required string ProviderName { get; set; }

    /// <summary>
    /// A link to the provider of the original resource.
    /// </summary>
    public required string ProviderUrl { get; set; }

    /// <summary>
    /// HTML to be used for generating the preview card.
    /// </summary>
    public required string Html { get; set; }

    /// <summary>
    /// Width of preview, in pixels.
    /// </summary>
    public required int Width { get; set; }

    /// <summary>
    /// Height of preview, in pixels.
    /// </summary>
    public required int Height { get; set; }

    /// <summary>
    /// Preview thumbnail.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Used for photo embeds, instead of custom html.
    /// </summary>
    public required string EmbedUrl { get; set; }

    /// <summary>
    /// A hash computed by the BlurHash algorithm, for generating colorful preview thumbnails when media has not been downloaded yet.
    /// </summary>
    public string? Blurhash { get; set; }
}
