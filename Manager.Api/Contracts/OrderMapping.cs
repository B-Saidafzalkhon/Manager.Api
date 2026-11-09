using Manager.Api.Entities;

namespace Manager.Api.Contracts;

public static class OrderMapping
{
    public static OrderResponse ToResponse(this Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            Note = order.Note,
            ClientId = order.ClientId
        };
    }
}