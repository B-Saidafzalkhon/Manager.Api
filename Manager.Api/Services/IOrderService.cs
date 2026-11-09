using Manager.Api.Contracts;

namespace Manager.Api.Services;

public interface IOrderService
{
    Task<OrderResponse?> CreateAsync(Guid clientId, OrderCreateRequest request);
    Task<List<OrderResponse>?> GetByClientAsync(Guid clientId);
    Task<OrderResponse?> GetByIdAsync(Guid clientId, Guid orderId);
}