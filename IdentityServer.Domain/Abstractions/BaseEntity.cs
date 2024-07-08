namespace IdentityServer.Domain.Abstractions;

/// <summary>
///     Represents the base class for all entities in the IdentityServer domain.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    ///     Gets or sets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; set; }
}