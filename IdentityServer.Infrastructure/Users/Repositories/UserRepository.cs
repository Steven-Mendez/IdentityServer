using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.DatabaseContexts;

namespace IdentityServer.Infrastructure.Users.Repositories;

public partial class UserRepository(IdentityServerContext context, IPasswordHasher passwordHasher) : IUserRepository;
