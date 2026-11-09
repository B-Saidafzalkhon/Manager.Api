using System.ComponentModel.DataAnnotations;

namespace Manager.Api.Contracts;

public class ClientCreateRequest
{
    [Required, StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required, StringLength(50, MinimumLength = 2)]
    public string Surname { get; set; }
    
    [Required, StringLength(50, MinimumLength = 2)]
    public string Email { get; set; }
}