using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.TechnicalStuff;
using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddAggregate]
public partial class LoyaltyAccount : IEquatable<LoyaltyAccount>
{
    public ClientId ClientId => _data.ClientId;
    public int CurrentBalance => _data.CurrentBalance;
    public int TotalEarned => _data.TotalEarned;
    public int TotalRedeemed => _data.TotalRedeemed;
    public IReadOnlyList<PointTransaction> Transactions => _data.Transactions;

    public void AwardPoints(int points, Guid orderId, LoyaltyConfiguration config, DateTime awardedAt)
    {
        if (!config.IsActive)
            throw new DomainError();
        
        if (points <= 0)
            throw new DomainError();

        var expirationDate = config.CalculateExpirationDate(awardedAt);
        var transaction = PointTransaction.Earned(points, orderId, awardedAt, expirationDate, $"Points earned from order {orderId}");
        
        AddAndApply(new PointsAwarded(transaction));
    }

    public RedemptionResult RedeemPoints(int pointsToRedeem, Guid orderId, LoyaltyConfiguration config, DateTime redeemedAt)
    {
        if (!config.IsActive)
            throw new DomainError();
        
        if (pointsToRedeem <= 0)
            throw new DomainError();

        var availablePoints = GetAvailablePointsOn(redeemedAt);
        if (pointsToRedeem > availablePoints)
            return RedemptionResult.InsufficientPoints(availablePoints, pointsToRedeem);

        var discountAmount = config.CalculateDiscountAmount(pointsToRedeem);
        var transaction = PointTransaction.Redeemed(pointsToRedeem, orderId, redeemedAt, $"Points redeemed for order {orderId}");
        
        AddAndApply(new PointsRedeemed(transaction, discountAmount));
        
        return RedemptionResult.Success(pointsToRedeem, discountAmount);
    }

    public void ExpirePoints(DateTime cutoffDate)
    {
        var expiredTransactions = _data.Transactions
            .Where(t => t.Type == TransactionType.Earned && t.IsExpiredOn(cutoffDate))
            .ToList();

        foreach (var expiredTransaction in expiredTransactions)
        {
            var remainingPoints = CalculateRemainingPointsFor(expiredTransaction, cutoffDate);
            if (remainingPoints > 0)
            {
                var expirationTransaction = PointTransaction.Expired(remainingPoints, cutoffDate, 
                    $"Points expired from transaction on {expiredTransaction.CreatedAt:yyyy-MM-dd}");
                AddAndApply(new PointsExpired(expirationTransaction));
            }
        }
    }

    private int GetAvailablePointsOn(DateTime date)
    {
        var earned = _data.Transactions
            .Where(t => t.Type == TransactionType.Earned && !t.IsExpiredOn(date))
            .Sum(t => t.Amount);
        
        var redeemed = _data.Transactions
            .Where(t => t.Type == TransactionType.Redeemed)
            .Sum(t => t.Amount);
        
        var expired = _data.Transactions
            .Where(t => t.Type == TransactionType.Expired)
            .Sum(t => t.Amount);

        return earned - redeemed - expired;
    }

    private int CalculateRemainingPointsFor(PointTransaction earnedTransaction, DateTime asOfDate)
    {
        if (earnedTransaction.Type != TransactionType.Earned)
            return 0;

        // Calculate how many points from this specific earned transaction have been used
        var usedPoints = _data.Transactions
            .Where(t => t.Type == TransactionType.Redeemed && t.CreatedAt >= earnedTransaction.CreatedAt)
            .Sum(t => t.Amount);

        var expiredPoints = _data.Transactions
            .Where(t => t.Type == TransactionType.Expired && t.CreatedAt >= earnedTransaction.CreatedAt)
            .Sum(t => t.Amount);

        return Math.Max(0, earnedTransaction.Amount - usedPoints - expiredPoints);
    }

    public override bool Equals(object? obj) => obj is LoyaltyAccount other && Equals(other);
    public bool Equals(LoyaltyAccount? other) => other is not null && ClientId.Equals(other.ClientId);
    public override int GetHashCode() => ClientId.GetHashCode();
}

public readonly struct RedemptionResult
{
    public bool IsSuccess { get; }
    public int PointsRedeemed { get; }
    public decimal DiscountAmount { get; }
    public int AvailablePoints { get; }
    public string? ErrorMessage { get; }

    private RedemptionResult(bool isSuccess, int pointsRedeemed, decimal discountAmount, int availablePoints, string? errorMessage)
    {
        IsSuccess = isSuccess;
        PointsRedeemed = pointsRedeemed;
        DiscountAmount = discountAmount;
        AvailablePoints = availablePoints;
        ErrorMessage = errorMessage;
    }

    public static RedemptionResult Success(int pointsRedeemed, decimal discountAmount) =>
        new(true, pointsRedeemed, discountAmount, 0, null);

    public static RedemptionResult InsufficientPoints(int availablePoints, int requestedPoints) =>
        new(false, 0, 0, availablePoints, $"Insufficient points. Available: {availablePoints}, Requested: {requestedPoints}");
}