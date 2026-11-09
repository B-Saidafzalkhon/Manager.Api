using Manager.Api.Entities;

namespace Manager.Api.Contracts;

public static class ClientMapping
{
    public static ClientResponse ToResponse(this Client client)
    {
        return new ClientResponse
        {
            Id = client.Id,
            Name = client.Name,
            Surname = client.Surname,
            Email = client.Email,
            IsActive = client.IsActive,
        };
    }
}