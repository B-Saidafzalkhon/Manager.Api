using Manager.Api.Contracts;
namespace Manager.Api.Services;

public interface IClientService
{
    Task<List<ClientResponse>> GetClientsAsync();
    Task<ClientResponse?> GetClientByIdAsync(Guid id);
    Task<ClientResponse> CreateAsync(ClientCreateRequest request);
    Task<bool> UpdateAsync(Guid id, ClientUpdateRequest request);
    Task<bool> DeleteAsync(Guid id);
}