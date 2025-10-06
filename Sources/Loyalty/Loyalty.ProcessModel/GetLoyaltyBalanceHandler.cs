using System.Collections.Immutable;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using NoesisVision.Annotations.People;

namespace MyCompany.ECommerce.Loyalty;

[UsedImplicitly]
public class GetLoyaltyBalanceHandler(LoyaltyAccount.Repository accountRepository)
    : QueryHandler<GetLoyaltyBalance, LoyaltyBalanceDto>
{
    [Actor("Customer")]
    public async Task<LoyaltyBalanceDto> Handle(GetLoyaltyBalance query)
    {
        var clientId = ClientId.From(query.ClientId);
        var account = await accountRepository.GetByClientId(clientId);

        if (account == null)
        {
            return new LoyaltyBalanceDto(
                query.ClientId,
                currentBalance: 0,
                totalEarned: 0,
                totalRedeemed: 0,
                recentTransactions: ImmutableArray<PointTransactionDto>.Empty,
                totalTransactionCount: 0);
        }

        var allTransactions = account.Transactions
            .OrderByDescending(t => t.CreatedAt)
            .ToList();

        var totalTransactionCount = allTransactions.Count;
        
        var skip = (query.PageNumber - 1) * query.PageSize;
        var recentTransactions = allTransactions
            .Skip(skip)
            .Take(query.PageSize)
            .Select(PointTransactionDto.FromDomain)
            .ToImmutableArray();

        return new LoyaltyBalanceDto(
            query.ClientId,
            account.CurrentBalance,
            account.TotalEarned,
            account.TotalRedeemed,
            recentTransactions,
            totalTransactionCount);
    }
}