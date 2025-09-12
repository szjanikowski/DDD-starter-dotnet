using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Products;

[DddValueObject]
public enum AmountUnit
{
    Unit,
    Box,
    Palette
}