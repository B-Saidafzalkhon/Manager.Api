using Manager.Api.Entities;

namespace Manager.Api.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetClientsAsync();
    Task<Client?> GetClientByIdAsync(Guid id);
    void Add(Client client);
    void Remove(Client client);
    Task SaveChangesAsync();
    Task<bool> ExistsAsync(Guid id);
}