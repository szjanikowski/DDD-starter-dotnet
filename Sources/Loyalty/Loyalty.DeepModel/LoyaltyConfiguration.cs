using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddValueObject]
public readonly struct LoyaltyConfiguration : IEquatable<LoyaltyConfiguration>
{
    public decimal EarningRatio { get; }
    public decimal RedemptionRatio { get; }
    public int ExpirationMonths { get; }
    public decimal MinimumOrderAmount { get; }
    public bool IsActive { get; }

    public static LoyaltyConfiguration Default() => new(
        earningRatio: 1.0m,           // 1 point per $1 spent
        redemptionRatio: 100.0m,      // 100 points = $1 discount
        expirationMonths: 24,         // 2 years
        minimumOrderAmount: 0.0m,     // No minimum
        isActive: true
    );

    public static LoyaltyConfiguration Create(
        decimal earningRatio,
        decimal redemptionRatio,
        int expirationMonths,
        decimal minimumOrderAmount,
        bool isActive = true)
    {
        ValidateConfiguration(earningRatio, redemptionRatio, expirationMonths, minimumOrderAmount);
        return new LoyaltyConfiguration(earningRatio, redemptionRatio, expirationMonths, minimumOrderAmount, isActive);
    }

    private LoyaltyConfiguration(decimal earningRatio, decimal redemptionRatio, int expirationMonths, decimal minimumOrderAmount, bool isActive)
    {
        EarningRatio = earningRatio;
        RedemptionRatio = redemptionRatio;
        ExpirationMonths = expirationMonths;
        MinimumOrderAmount = minimumOrderAmount;
        IsActive = isActive;
    }

    private static void ValidateConfiguration(decimal earningRatio, decimal redemptionRatio, int expirationMonths, decimal minimumOrderAmount)
    {
        if (earningRatio <= 0)
            throw new ArgumentException("Earning ratio must be positive", nameof(earningRatio));
        
        if (redemptionRatio <= 0)
            throw new ArgumentException("Redemption ratio must be positive", nameof(redemptionRatio));
        
        if (expirationMonths <= 0)
            throw new ArgumentException("Expiration months must be positive", nameof(expirationMonths));
        
        if (minimumOrderAmount < 0)
            throw new ArgumentException("Minimum order amount cannot be negative", nameof(minimumOrderAmount));
    }

    public int CalculatePointsEarned(decimal orderAmount)
    {
        if (!IsActive || orderAmount < MinimumOrderAmount)
            return 0;
        
        return (int)Math.Floor(orderAmount * EarningRatio);
    }

    public decimal CalculateDiscountAmount(int pointsToRedeem)
    {
        if (!IsActive || pointsToRedeem <= 0)
            return 0;
        
        return pointsToRedeem / RedemptionRatio;
    }

    public DateTime CalculateExpirationDate(DateTime earnedDate) =>
        earnedDate.AddMonths(ExpirationMonths);

    public bool Equals(LoyaltyConfiguration other) =>
        EarningRatio == other.EarningRatio &&
        RedemptionRatio == other.RedemptionRatio &&
        ExpirationMonths == other.ExpirationMonths &&
        MinimumOrderAmount == other.MinimumOrderAmount &&
        IsActive == other.IsActive;

    public override bool Equals(object? obj) => obj is LoyaltyConfiguration other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(EarningRatio, RedemptionRatio, ExpirationMonths, MinimumOrderAmount, IsActive);

    public override string ToString() => 
        $"Earning: {EarningRatio:F2} pts/$, Redemption: {RedemptionRatio:F0} pts/$1, Expires: {ExpirationMonths}mo, Min: ${MinimumOrderAmount:F2}, Active: {IsActive}";
}