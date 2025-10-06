using MyCompany.ECommerce.Sales.Clients;
using P3Model.Annotations.Domain.DDD;

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