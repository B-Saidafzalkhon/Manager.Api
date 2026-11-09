namespace Manager.Api.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;
}