using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Loyalty;

public interface LoyaltyEventsOutbox
{
    void Add(DomainEvent loyaltyEvent);
}