using System.Diagnostics.Contracts;
using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing;

[DddDomainService]
internal interface QuoteModifier
{
    [Pure]
    Quote ApplyOn(Quote quote);
}