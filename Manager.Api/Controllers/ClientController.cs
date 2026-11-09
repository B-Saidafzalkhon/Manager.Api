using Manager.Api.Contracts;
using Manager.Api.Repositories;
using Manager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClientResponse>>> GetAllAsync() =>
        Ok(await _service.GetClientsAsync());

    [HttpGet("{id:guid}", Name = "GetClientById")]
    public async Task<ActionResult<ClientResponse?>> GetByIdAsync(Guid id) =>
        Ok(await _service.GetClientByIdAsync(id));
    
    [HttpPost]
    public async Task<ActionResult<ClientResponse>> CreateAsync(ClientCreateRequest request)
    {
        var client = await _service.CreateAsync(request);
        return CreatedAtRoute("GetClientById", new { id = client.Id }, client);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, ClientUpdateRequest request)
    {
        var updated = await _service.UpdateAsync(id, request);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}