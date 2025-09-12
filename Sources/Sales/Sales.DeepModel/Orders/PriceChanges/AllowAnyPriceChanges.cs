using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Pricing;
using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders.PriceChanges;

[DddDomainService]
public class AllowAnyPriceChanges : PriceChangesPolicy
{
    public bool CanChangePrices(ImmutableArray<Quote> oldQuotes, ImmutableArray<Quote> newQuotes) => true;
}