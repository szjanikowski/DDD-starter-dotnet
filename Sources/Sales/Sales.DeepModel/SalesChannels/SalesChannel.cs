using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.SalesChannels;

[DddValueObject]
public enum SalesChannel
{
    OnlineSale,
    Wholesale
}