namespace IdentityServer.Domain.Interfaces;

/// <summary>
///     Represents an interface for hashing and verifying passwords.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    ///     Computes the hash value of a password.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password as a string.</returns>
    string Hash(string password);

    /// <summary>
    ///     Verifies whether a password matches a given hashed password.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="passwordHash">The hashed password to compare against.</param>
    /// <returns>True if the password matches the hashed password; otherwise, false.</returns>
    bool Verify(string password, string passwordHash);
}