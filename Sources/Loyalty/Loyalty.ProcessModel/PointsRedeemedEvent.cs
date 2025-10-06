using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Loyalty;

[Event]
public class PointsRedeemedEvent(
    Guid clientId,
    int pointsRedeemed,
    decimal discountAmount,
    Guid orderId,
    DateTime redeemedAt)
    : DomainEvent
{
    public Guid ClientId { get; } = clientId;
    public int PointsRedeemed { get; } = pointsRedeemed;
    public decimal DiscountAmount { get; } = discountAmount;
    public Guid OrderId { get; } = orderId;
    public DateTime RedeemedAt { get; } = redeemedAt;
}