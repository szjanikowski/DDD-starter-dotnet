using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Loyalty;

[PublicContract]
[Command]
public readonly struct UpdateLoyaltyConfiguration(
    decimal earningRatio,
    decimal redemptionRatio,
    int expirationMonths,
    decimal minimumOrderAmount,
    bool isActive = true)
    : Command
{
    public decimal EarningRatio { get; } = earningRatio;
    public decimal RedemptionRatio { get; } = redemptionRatio;
    public int ExpirationMonths { get; } = expirationMonths;
    public decimal MinimumOrderAmount { get; } = minimumOrderAmount;
    public bool IsActive { get; } = isActive;
}