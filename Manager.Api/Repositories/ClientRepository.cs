using Manager.Api.Data;
using Manager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manager.Api.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ManagerDbContext _dbContextContext;

    public ClientRepository(ManagerDbContext dbContextContext)
    {
        _dbContextContext = dbContextContext;
    }

    public async Task<List<Client>> GetClientsAsync()
    {
        return await _dbContextContext.Clients
            .AsNoTracking()
            .OrderBy(c => c.CreatedAtUtc)
            .ToListAsync();
    }

    public async Task<Client?> GetClientByIdAsync(Guid id) =>
        await _dbContextContext.Clients.FirstOrDefaultAsync(c => c.Id == id);

    public void Add(Client client) =>
        _dbContextContext.Clients.Add(client);

    public void Remove(Client client) =>
        _dbContextContext.Clients.Remove(client);

    public async Task SaveChangesAsync() =>
        await _dbContextContext.SaveChangesAsync();
    
    public async Task<bool>  ExistsAsync(Guid id) =>
        await _dbContextContext.Clients.AnyAsync(c => c.Id == id);
}