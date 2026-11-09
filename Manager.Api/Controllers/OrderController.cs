using Manager.Api.Contracts;
using Manager.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Manager.Api.Controllers;

[ApiController]
[Route("api/clients/{clientId:guid}/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderResponse>?>> GetAll(Guid clientId)
    {
        if(await _orderService.GetByClientAsync(clientId) is null)
            return NotFound();
        
        return Ok(await _orderService.GetByClientAsync(clientId));
    }

    [HttpGet("{orderId:guid}")]
    public async Task<ActionResult<OrderResponse?>> GetById(Guid clientId, Guid orderId)
    {
        if (await _orderService.GetByIdAsync(clientId, orderId) is null)
            return NotFound();
        
        return Ok(await _orderService.GetByIdAsync(clientId, orderId));
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create(Guid clientId, OrderCreateRequest request)
    {
        var order = await _orderService.CreateAsync(clientId, request);

        if (order is null)
            return NotFound($"Client {clientId} not found.");

        return CreatedAtAction(nameof(GetById), new { clientId, orderId = order.Id }, order);
    }
}