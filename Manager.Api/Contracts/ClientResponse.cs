namespace Manager.Api.Contracts;

public class ClientResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}