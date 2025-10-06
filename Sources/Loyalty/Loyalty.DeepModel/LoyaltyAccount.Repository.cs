using MyCompany.ECommerce.Sales.Clients;
using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

public partial class LoyaltyAccount
{
    [DddRepository]
    public interface Repository
    {
        Task<LoyaltyAccount?> GetByClientId(ClientId clientId);
        Task Save(LoyaltyAccount account);
    }
}