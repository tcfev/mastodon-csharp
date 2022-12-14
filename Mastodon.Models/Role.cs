namespace Mastodon.Models;

public sealed partial class Role
{
    /// <summary>
    /// The ID of the Role in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// The name of the role.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The hex code assigned to this role. If no hex code is assigned, the string will be empty.
    /// </summary>
    public required string Color { get; set; }

    /// <summary>
    /// An index for the role’s position. The higher the position, the more priority the role has over other roles.
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// A bitmask that represents the sum of all permissions granted to the role.
    /// </summary>
    public int? Permissions { get; set; }

    /// <summary>
    /// Whether the role is publicly visible as a badge on user profiles.
    /// </summary>
    public bool? Highlighted { get; set; }

    /// <summary>
    /// The date that the role was created.
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The date that the role was updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
