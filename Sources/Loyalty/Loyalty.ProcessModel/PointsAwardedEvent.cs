using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using NoesisVision.Annotations.Domain;

namespace MyCompany.ECommerce.Loyalty;

[Event]
public class PointsAwardedEvent(
    Guid clientId,
    int pointsEarned,
    Guid orderId,
    DateTime awardedAt,
    DateTime expiresAt)
    : DomainEvent
{
    public Guid ClientId { get; } = clientId;
    public int PointsEarned { get; } = pointsEarned;
    public Guid OrderId { get; } = orderId;
    public DateTime AwardedAt { get; } = awardedAt;
    public DateTime ExpiresAt { get; } = expiresAt;
}