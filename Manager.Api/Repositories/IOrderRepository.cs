using Manager.Api.Contracts;
using Manager.Api.Entities;

namespace Manager.Api.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task<List<Order>> GetByClientIdAsync(Guid clientId);
    Task<Order?> GetByIdAsync(Guid clientId, Guid orderId);
    Task SaveChangesAsync();
}