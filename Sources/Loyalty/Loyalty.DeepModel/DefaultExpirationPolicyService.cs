using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddDomainService]
internal class DefaultExpirationPolicyService : ExpirationPolicyService
{
    public DateTime CalculateExpirationDate(DateTime earnedDate, LoyaltyConfiguration config)
    {
        if (!config.IsActive)
            throw new InvalidOperationException("Cannot calculate expiration for inactive configuration");
            
        return earnedDate.AddMonths(config.ExpirationMonths);
    }

    public IEnumerable<PointRedemptionAllocation> AllocatePointsForRedemption(
        IEnumerable<PointTransaction> availableTransactions, 
        int pointsToRedeem, 
        DateTime asOfDate)
    {
        if (pointsToRedeem <= 0)
            yield break;
            
        var remainingToRedeem = pointsToRedeem;
        
        // Sort by creation date (FIFO - First In, First Out)
        var sortedTransactions = availableTransactions
            .Where(t => t.Type == TransactionType.Earned && !t.IsExpiredOn(asOfDate))
            .OrderBy(t => t.CreatedAt)
            .ToList();
            
        foreach (var transaction in sortedTransactions)
        {
            if (remainingToRedeem <= 0)
                break;
                
            var availableFromTransaction = CalculateAvailablePointsFromTransaction(
                transaction, availableTransactions, asOfDate);
                
            if (availableFromTransaction <= 0)
                continue;
                
            var pointsToUseFromThis = Math.Min(remainingToRedeem, availableFromTransaction);
            
            yield return new PointRedemptionAllocation(transaction, pointsToUseFromThis);
            
            remainingToRedeem -= pointsToUseFromThis;
        }
    }

    public IEnumerable<ExpiredPointsInfo> GetExpiredPoints(
        IEnumerable<PointTransaction> transactions, 
        DateTime asOfDate)
    {
        var transactionList = transactions.ToList();
        
        var expiredEarnedTransactions = transactionList
            .Where(t => t.Type == TransactionType.Earned && t.IsExpiredOn(asOfDate))
            .ToList();
            
        foreach (var expiredTransaction in expiredEarnedTransactions)
        {
            var remainingPoints = CalculateAvailablePointsFromTransaction(
                expiredTransaction, transactionList, asOfDate);
                
            if (remainingPoints > 0)
            {
                yield return new ExpiredPointsInfo(
                    expiredTransaction, 
                    remainingPoints, 
                    expiredTransaction.ExpiresAt!.Value);
            }
        }
    }

    public IEnumerable<PointExpirationExtension> CalculateExpirationExtensions(
        IEnumerable<PointTransaction> existingTransactions,
        DateTime extensionDate,
        LoyaltyConfiguration config)
    {
        if (!config.IsActive)
            yield break;
            
        var earnedTransactions = existingTransactions
            .Where(t => t.Type == TransactionType.Earned && !t.IsExpiredOn(extensionDate))
            .ToList();
            
        foreach (var transaction in earnedTransactions)
        {
            // Extend expiration by the configured extension period
            var newExpirationDate = CalculateExpirationDate(extensionDate, config);
            
            // Only extend if the new date is later than current expiration
            if (transaction.ExpiresAt.HasValue && newExpirationDate > transaction.ExpiresAt.Value)
            {
                yield return new PointExpirationExtension(transaction, newExpirationDate);
            }
        }
    }
    
    private int CalculateAvailablePointsFromTransaction(
        PointTransaction earnedTransaction,
        IEnumerable<PointTransaction> allTransactions,
        DateTime asOfDate)
    {
        if (earnedTransaction.Type != TransactionType.Earned)
            return 0;
            
        if (earnedTransaction.IsExpiredOn(asOfDate))
            return 0;
            
        var originalAmount = earnedTransaction.Amount;
        
        // Calculate points already used from this transaction
        // This is a simplified approach - in a real system, you'd need more sophisticated tracking
        var usedPoints = allTransactions
            .Where(t => t.Type == TransactionType.Redeemed && 
                       t.CreatedAt >= earnedTransaction.CreatedAt)
            .Sum(t => t.Amount);
            
        var expiredPoints = allTransactions
            .Where(t => t.Type == TransactionType.Expired && 
                       t.CreatedAt >= earnedTransaction.CreatedAt)
            .Sum(t => t.Amount);
            
        return Math.Max(0, originalAmount - usedPoints - expiredPoints);
    }
}