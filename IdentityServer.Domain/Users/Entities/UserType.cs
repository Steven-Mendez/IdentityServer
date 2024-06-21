using IdentityServer.Domain.Abstractions;

namespace IdentityServer.Domain.Users.Entities;

public class UserType : AuditEntity
{
    public UserType()
    {
        Users = new HashSet<User>();
    }
    
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; set; } = null!;
}
