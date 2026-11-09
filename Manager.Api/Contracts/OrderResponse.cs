using Manager.Api.Entities;
namespace Manager.Api.Contracts;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string? Note { get; set; }
    
    public Guid ClientId { get; set; }
}