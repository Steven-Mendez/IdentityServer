using IdentityServer.Domain.Abstractions;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<(IEnumerable<T> Items, int TotalRecords)> GetByCriteriaAsync(ISpecification<T> specification);

    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}