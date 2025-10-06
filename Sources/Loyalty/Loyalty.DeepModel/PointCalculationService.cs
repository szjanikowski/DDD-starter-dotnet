using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddDomainService]
public interface PointCalculationService
{
    /// <summary>
    /// Calculates loyalty points earned based on order amount and current configuration
    /// </summary>
    /// <param name="orderAmount">The total amount of the order</param>
    /// <param name="config">Current loyalty configuration with earning ratios</param>
    /// <returns>Number of points to be awarded</returns>
    int CalculatePointsEarned(decimal orderAmount, LoyaltyConfiguration config);
    
    /// <summary>
    /// Calculates discount amount for a given number of points
    /// </summary>
    /// <param name="pointsToRedeem">Number of points to redeem</param>
    /// <param name="config">Current loyalty configuration with redemption ratios</param>
    /// <returns>Discount amount in currency</returns>
    decimal CalculateDiscountAmount(int pointsToRedeem, LoyaltyConfiguration config);
    
    /// <summary>
    /// Validates if an order amount qualifies for point earning
    /// </summary>
    /// <param name="orderAmount">The total amount of the order</param>
    /// <param name="config">Current loyalty configuration with minimum order requirements</param>
    /// <returns>True if order qualifies for points</returns>
    bool IsEligibleForPoints(decimal orderAmount, LoyaltyConfiguration config);
}