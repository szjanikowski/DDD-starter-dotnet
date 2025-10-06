using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddDomainService]
public interface ExpirationPolicyService
{
    /// <summary>
    /// Calculates expiration date for newly earned points
    /// </summary>
    /// <param name="earnedDate">Date when points were earned</param>
    /// <param name="config">Current loyalty configuration with expiration policy</param>
    /// <returns>Date when points will expire</returns>
    DateTime CalculateExpirationDate(DateTime earnedDate, LoyaltyConfiguration config);
    
    /// <summary>
    /// Determines which points should be used first when redeeming (FIFO logic)
    /// </summary>
    /// <param name="availableTransactions">List of earned transactions with remaining points</param>
    /// <param name="pointsToRedeem">Number of points to redeem</param>
    /// <param name="asOfDate">Date of redemption for expiration checking</param>
    /// <returns>Ordered list of transactions to use for redemption</returns>
    IEnumerable<PointRedemptionAllocation> AllocatePointsForRedemption(
        IEnumerable<PointTransaction> availableTransactions, 
        int pointsToRedeem, 
        DateTime asOfDate);
    
    /// <summary>
    /// Identifies points that have expired as of a given date
    /// </summary>
    /// <param name="transactions">All point transactions for an account</param>
    /// <param name="asOfDate">Date to check for expiration</param>
    /// <returns>List of expired point amounts with their original transactions</returns>
    IEnumerable<ExpiredPointsInfo> GetExpiredPoints(
        IEnumerable<PointTransaction> transactions, 
        DateTime asOfDate);
    
    /// <summary>
    /// Extends expiration dates for existing points when customer makes new purchases
    /// </summary>
    /// <param name="existingTransactions">Current earned transactions</param>
    /// <param name="extensionDate">Date of new purchase</param>
    /// <param name="config">Current loyalty configuration with extension policy</param>
    /// <returns>Updated expiration dates for existing points</returns>
    IEnumerable<PointExpirationExtension> CalculateExpirationExtensions(
        IEnumerable<PointTransaction> existingTransactions,
        DateTime extensionDate,
        LoyaltyConfiguration config);
}

/// <summary>
/// Represents allocation of points from a specific earned transaction for redemption
/// </summary>
public readonly struct PointRedemptionAllocation
{
    public PointTransaction SourceTransaction { get; }
    public int PointsToUse { get; }
    
    public PointRedemptionAllocation(PointTransaction sourceTransaction, int pointsToUse)
    {
        SourceTransaction = sourceTransaction;
        PointsToUse = pointsToUse;
    }
}

/// <summary>
/// Information about expired points from a specific transaction
/// </summary>
public readonly struct ExpiredPointsInfo
{
    public PointTransaction OriginalTransaction { get; }
    public int ExpiredAmount { get; }
    public DateTime ExpiredOn { get; }
    
    public ExpiredPointsInfo(PointTransaction originalTransaction, int expiredAmount, DateTime expiredOn)
    {
        OriginalTransaction = originalTransaction;
        ExpiredAmount = expiredAmount;
        ExpiredOn = expiredOn;
    }
}

/// <summary>
/// Information about extending expiration dates for existing points
/// </summary>
public readonly struct PointExpirationExtension
{
    public PointTransaction OriginalTransaction { get; }
    public DateTime NewExpirationDate { get; }
    
    public PointExpirationExtension(PointTransaction originalTransaction, DateTime newExpirationDate)
    {
        OriginalTransaction = originalTransaction;
        NewExpirationDate = newExpirationDate;
    }
}