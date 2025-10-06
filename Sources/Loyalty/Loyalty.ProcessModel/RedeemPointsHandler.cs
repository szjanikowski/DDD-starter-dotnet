using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using NoesisVision.Annotations.Domain;
using NoesisVision.Annotations.People;

namespace MyCompany.ECommerce.Loyalty;

[UsedImplicitly]
public class RedeemPointsHandler(
    LoyaltyAccount.Repository accountRepository,
    LoyaltyConfigurationRepository configurationRepository,
    LoyaltyEventsOutbox eventsOutbox)
    : CommandHandler<RedeemPoints, PointRedemptionResult>
{
    [PublicContract]
    [Actor("Customer")]
    public async Task<PointRedemptionResult> Handle(RedeemPoints command)
    {
        var clientId = ClientId.From(command.ClientId);
        var configuration = await configurationRepository.GetCurrent();
        
        if (!configuration.IsActive)
            throw new DomainError();

        var account = await accountRepository.GetByClientId(clientId);
        if (account == null)
            return PointRedemptionResult.InsufficientPoints(0, command.PointsToRedeem);

        var redemptionResult = account.RedeemPoints(
            command.PointsToRedeem, 
            command.OrderId, 
            configuration, 
            command.RedeemedAt);

        if (!redemptionResult.IsSuccess)
            return PointRedemptionResult.FromDomain(redemptionResult);

        await accountRepository.Save(account);

        var domainEvent = new PointsRedeemedEvent(
            command.ClientId,
            redemptionResult.PointsRedeemed,
            redemptionResult.DiscountAmount,
            command.OrderId,
            command.RedeemedAt);

        eventsOutbox.Add(domainEvent);
        return PointRedemptionResult.FromDomain(redemptionResult);
    }
}