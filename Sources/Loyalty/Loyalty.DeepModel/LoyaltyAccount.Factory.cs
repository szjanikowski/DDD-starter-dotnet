using MyCompany.ECommerce.Sales.Clients;
using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

public partial class LoyaltyAccount
{
    [DddFactory]
    public abstract class Factory
    {
        public LoyaltyAccount NewFor(ClientId clientId)
        {
            var data = CreateData(clientId);
            return new LoyaltyAccount(data);
        }

        protected abstract Data CreateData(ClientId clientId);
    }
}