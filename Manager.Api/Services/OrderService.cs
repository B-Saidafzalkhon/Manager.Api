using Manager.Api.Contracts;
using Manager.Api.Entities;
using Manager.Api.Repositories;

namespace Manager.Api.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IClientRepository _clientRepository;

    public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository)
    {
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
    }

    public async Task<OrderResponse?> CreateAsync(Guid clientId, OrderCreateRequest request)
    {
        if (!await _clientRepository.ExistsAsync(clientId))
            return null;

        var order = new Order
        {
            Note = request.Note,
            CreatedAtUtc = DateTime.UtcNow,
            ClientId = clientId
        };

        _orderRepository.Add(order);
        await _orderRepository.SaveChangesAsync();

        return order.ToResponse();
    }

    public async Task<List<OrderResponse>?> GetByClientAsync(Guid clientId)
    {
        if (!await _clientRepository.ExistsAsync(clientId))
            return null;
        
        var list = await _orderRepository.GetByClientIdAsync(clientId);
        return list.Select(o => o.ToResponse()).ToList();
    }

    public async Task<OrderResponse?> GetByIdAsync(Guid clientId, Guid orderId)
    {
        var order = await _orderRepository.GetByIdAsync(clientId, orderId);
        return order?.ToResponse();
    }
}