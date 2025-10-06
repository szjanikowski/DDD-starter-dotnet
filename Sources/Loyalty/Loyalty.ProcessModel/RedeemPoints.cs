using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Loyalty;

[PublicContract]
[Command]
public readonly struct RedeemPoints(
    Guid clientId,
    int pointsToRedeem,
    Guid orderId,
    DateTime redeemedAt)
    : Command
{
    public Guid ClientId { get; } = clientId;
    public int PointsToRedeem { get; } = pointsToRedeem;
    public Guid OrderId { get; } = orderId;
    public DateTime RedeemedAt { get; } = redeemedAt;
}