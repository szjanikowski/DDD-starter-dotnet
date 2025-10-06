using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Loyalty;

[UsedImplicitly]
public class UpdateLoyaltyConfigurationHandler(
    LoyaltyConfigurationRepository configurationRepository,
    LoyaltyConfigurationValidationService validationService)
    : CommandHandler<UpdateLoyaltyConfiguration>
{
    [PublicContract]
    [Actor("Administrator")]
    public async Task Handle(UpdateLoyaltyConfiguration command)
    {
        var newConfiguration = LoyaltyConfiguration.Create(
            command.EarningRatio,
            command.RedemptionRatio,
            command.ExpirationMonths,
            command.MinimumOrderAmount,
            command.IsActive);

        var currentConfiguration = await configurationRepository.GetCurrent();
        
        validationService.ValidateConfigurationChange(currentConfiguration, newConfiguration);
        
        await configurationRepository.Save(newConfiguration);
    }
}