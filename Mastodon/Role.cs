
namespace Mastodon;

public sealed class Role
{
    /// <summary>
    /// The ID of the Role in the database.
    /// </summary>
    public required int Id { get; set; }

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
    public required int Position { get; set; }

    /// <summary>
    /// A bitmask that represents the sum of all permissions granted to the role.
    /// </summary>
    public required int Permissions { get; set; }

    /// <summary>
    /// Whether the role is publicly visible as a badge on user profiles.
    /// </summary>
    public required bool Highlighted { get; set; }

    /// <summary>
    /// The date that the role was created.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date that the role was updated.
    /// </summary>
    public required DateTime UpdatedAt { get; set; }
}
