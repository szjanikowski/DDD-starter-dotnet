using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Commons;

[DddValueObject]
public enum Currency
{
    PLN,
    USD,
    EUR
}