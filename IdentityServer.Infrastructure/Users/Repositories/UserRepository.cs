using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.DatabaseContexts;

namespace IdentityServer.Infrastructure.Users.Repositories;

/// <summary>
///     Represents a repository for managing user entities within the IdentityServer infrastructure.
///     This class is a part of the repository pattern implementation specific to user entities,
///     providing an abstraction layer over the underlying data access technology (e.g., Entity Framework Core).
/// </summary>
/// <remarks>
///     This class is marked as partial, indicating it's split across multiple files to organize functionality
///     (e.g., CRUD operations, helper methods) logically. This approach helps in maintaining a clean codebase,
///     especially for large classes.
/// </remarks>
public partial class UserRepository(IdentityServerContext context, IPasswordHasher passwordHasher) : IUserRepository;