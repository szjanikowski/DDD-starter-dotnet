using Noesis.P3.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[Event]
public class OrderPlaced(Guid orderId, Guid clientId, DateTime placedOn) : OrderEvent
{
    public Guid OrderId { get; } = orderId;
    public Guid ClientId { get; } = clientId;
    public DateTime PlacedOn { get; } = placedOn;
}