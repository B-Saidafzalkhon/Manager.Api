using Manager.Api.Contracts;
using Manager.Api.Data;
using Manager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manager.Api.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ManagerDbContext _dbContext;
    public OrderRepository(ManagerDbContext dbContext) => _dbContext = dbContext;

    public void Add(Order order) =>
        _dbContext.Orders.Add(order);

    public async Task<List<Order>> GetByClientIdAsync(Guid clientId) =>
        await _dbContext.Orders.AsNoTracking()
            .OrderBy(o => o.CreatedAtUtc)
            .Where(o => o.ClientId == clientId)
            .ToListAsync();

    public Task<Order?> GetByIdAsync(Guid clientId, Guid orderId) =>
        _dbContext.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.ClientId == clientId && o.Id == orderId);

    public async Task SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync();
}