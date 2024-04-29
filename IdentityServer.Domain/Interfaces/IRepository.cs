using IdentityServer.Domain.Abstractions;
using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Interfaces;

namespace IdentityServer.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<(IEnumerable<User> Users, int TotalRecords)> GetFilteredSortedPaginatedAsync(IUserFilter filter,
        ISorter sorting, IPagination pagination);

    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}