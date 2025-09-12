using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Products;
using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts;

[DddRepository]
public interface DiscountsRepository
{
    Task<ClientLevelDiscounts> GetFor(ClientId clientId);
    Task<ProductLevelDiscounts> GetFor(ImmutableArray<ProductAmount> productAmounts);
}