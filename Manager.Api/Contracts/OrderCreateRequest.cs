using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Api.Contracts;

public class OrderCreateRequest
{
    [Required, StringLength(500, MinimumLength = 2)]
    public string Note { get; set; }
}