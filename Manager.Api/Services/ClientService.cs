using Manager.Api.Contracts;
using Manager.Api.Entities;
using Manager.Api.Repositories;

namespace Manager.Api.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ClientResponse>> GetClientsAsync()
    {
        var clients = await _repository.GetClientsAsync();
        return clients.Select(c => c.ToResponse()).ToList();
    }

    public async Task<ClientResponse?> GetClientByIdAsync(Guid id)
    {
        var client = await _repository.GetClientByIdAsync(id);
        return client?.ToResponse();
    }

    public async Task<ClientResponse> CreateAsync(ClientCreateRequest request)
    {
        var client = new Client
        {
            Name = request.Name,
            Surname =  request.Surname,
            Email =  request.Email,
            CreatedAtUtc =  DateTime.UtcNow,
        };
        
        _repository.Add(client);
        await _repository.SaveChangesAsync();
        
        return client.ToResponse();
    }

    public async Task<bool> UpdateAsync(Guid id, ClientUpdateRequest request)
    {
        var client = await _repository.GetClientByIdAsync(id);
        
        if (client is null)
            return false;
        
        client.Name = request.Name;
        client.Surname = request.Surname;
        client.Email = request.Email;
        
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var client = await _repository.GetClientByIdAsync(id);
        
        if (client is null)
            return false;
        
        _repository.Remove(client);
        await _repository.SaveChangesAsync();
        return true;
    }
}