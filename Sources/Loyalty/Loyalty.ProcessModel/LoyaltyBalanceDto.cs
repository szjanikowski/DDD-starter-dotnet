using System.Collections.Immutable;

namespace MyCompany.ECommerce.Loyalty;

public readonly struct LoyaltyBalanceDto(
    Guid clientId,
    int currentBalance,
    int totalEarned,
    int totalRedeemed,
    ImmutableArray<PointTransactionDto> recentTransactions,
    int totalTransactionCount)
{
    public Guid ClientId { get; } = clientId;
    public int CurrentBalance { get; } = currentBalance;
    public int TotalEarned { get; } = totalEarned;
    public int TotalRedeemed { get; } = totalRedeemed;
    public ImmutableArray<PointTransactionDto> RecentTransactions { get; } = recentTransactions;
    public int TotalTransactionCount { get; } = totalTransactionCount;
}