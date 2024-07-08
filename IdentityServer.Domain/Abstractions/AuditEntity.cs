namespace IdentityServer.Domain.Abstractions;

/// <summary>
///     Represents the base class for all auditable entities in the IdentityServer domain.
///     Inherits from <see cref="BaseEntity" />.
/// </summary>
public abstract class AuditEntity : BaseEntity
{
    /// <summary>
    ///     Gets or sets the identifier of the user who created the entity.
    /// </summary>
    public Guid CreatedBy { get; set; }

    /// <summary>
    ///     Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Gets or sets the identifier of the user who last updated the entity.
    ///     Nullable to indicate that the entity might not have been updated.
    /// </summary>
    public Guid? UpdatedBy { get; set; }

    /// <summary>
    ///     Gets or sets the date and time when the entity was last updated.
    ///     Nullable to indicate that the entity might not have been updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    ///     Gets or sets the identifier of the user who deleted the entity.
    ///     Nullable to indicate that the entity might not have been deleted.
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    ///     Gets or sets the date and time when the entity was deleted.
    ///     Nullable to indicate that the entity might not have been deleted.
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}