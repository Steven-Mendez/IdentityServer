using System.Security.Cryptography;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Infrastructure.Cryptography;

/// <summary>
///     Provides functionality for hashing passwords and verifying hashed passwords.
/// </summary>
public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private const char Delimiter = ';';
    private static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;

    /// <summary>
    ///     Hashes a password using PBKDF2 with a randomly generated salt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>A hashed password string containing the salt and hash, separated by a delimiter.</returns>
    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);
        var result = string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        return result;
    }

    /// <summary>
    ///     Verifies a password against a hashed password.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="passwordHash">The hashed password string containing the salt and hash, separated by a delimiter.</param>
    /// <returns>True if the password matches the hashed password; otherwise, false.</returns>
    public bool Verify(string password, string passwordHash)
    {
        var parts = passwordHash.Split(Delimiter);
        var salt = Convert.FromBase64String(parts[0]);
        var hash = Convert.FromBase64String(parts[1]);

        var hasInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);

        var result = CryptographicOperations.FixedTimeEquals(hash, hasInput);

        return result;
    }
}