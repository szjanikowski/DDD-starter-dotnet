using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using NoesisVision.Annotations.Domain;
using NoesisVision.Annotations.People;

namespace MyCompany.ECommerce.Loyalty;

[UsedImplicitly]
public class AwardPointsHandler(
    LoyaltyAccount.Repository accountRepository,
    LoyaltyAccount.Factory accountFactory,
    LoyaltyConfigurationRepository configurationRepository,
    PointCalculationService pointCalculationService,
    LoyaltyEventsOutbox eventsOutbox)
    : CommandHandler<AwardPoints, PointsAwardedEvent?>
{
    [PublicContract]
    [Actor("System")]
    public async Task<PointsAwardedEvent?> Handle(AwardPoints command)
    {
        var clientId = ClientId.From(command.ClientId);
        var configuration = await configurationRepository.GetCurrent();
        
        if (!configuration.IsActive || command.OrderAmount < configuration.MinimumOrderAmount)
            return null;

        var pointsToAward = pointCalculationService.CalculatePointsEarned(command.OrderAmount, configuration);
        if (pointsToAward <= 0)
            return null;

        var account = await accountRepository.GetByClientId(clientId) 
                     ?? accountFactory.NewFor(clientId);

        account.AwardPoints(pointsToAward, command.OrderId, configuration, command.AwardedAt);
        await accountRepository.Save(account);

        var expirationDate = configuration.CalculateExpirationDate(command.AwardedAt);
        var domainEvent = new PointsAwardedEvent(
            command.ClientId,
            pointsToAward,
            command.OrderId,
            command.AwardedAt,
            expirationDate);

        eventsOutbox.Add(domainEvent);
        return domainEvent;
    }
}