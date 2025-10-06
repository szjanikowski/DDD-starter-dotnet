using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddDomainService]
internal class DefaultPointCalculationService : PointCalculationService
{
    public int CalculatePointsEarned(decimal orderAmount, LoyaltyConfiguration config)
    {
        if (!config.IsActive)
            return 0;
            
        if (!IsEligibleForPoints(orderAmount, config))
            return 0;
            
        // Calculate points using the earning ratio (points per currency unit)
        var points = orderAmount * config.EarningRatio;
        
        // Round down to nearest whole point
        return (int)Math.Floor(points);
    }

    public decimal CalculateDiscountAmount(int pointsToRedeem, LoyaltyConfiguration config)
    {
        if (!config.IsActive || pointsToRedeem <= 0)
            return 0;
            
        // Calculate discount using redemption ratio (points per discount unit)
        // If redemption ratio is 100 points per $1, then discount = points / 100
        return pointsToRedeem / config.RedemptionRatio;
    }

    public bool IsEligibleForPoints(decimal orderAmount, LoyaltyConfiguration config)
    {
        if (!config.IsActive)
            return false;
            
        if (orderAmount <= 0)
            return false;
            
        // Check if order meets minimum amount requirement
        return orderAmount >= config.MinimumOrderAmount;
    }
}