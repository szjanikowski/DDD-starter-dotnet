using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using NoesisVision.Annotations.Domain;

namespace MyCompany.ECommerce.Loyalty;

[PublicContract]
[Command]
public readonly struct AwardPoints(
    Guid clientId,
    decimal orderAmount,
    Guid orderId,
    DateTime awardedAt)
    : Command
{
    public Guid ClientId { get; } = clientId;
    public decimal OrderAmount { get; } = orderAmount;
    public Guid OrderId { get; } = orderId;
    public DateTime AwardedAt { get; } = awardedAt;
}