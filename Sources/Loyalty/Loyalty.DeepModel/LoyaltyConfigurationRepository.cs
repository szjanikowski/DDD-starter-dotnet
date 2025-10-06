using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddRepository]
public interface LoyaltyConfigurationRepository
{
    Task<LoyaltyConfiguration> GetCurrent();
    Task Save(LoyaltyConfiguration configuration);
}