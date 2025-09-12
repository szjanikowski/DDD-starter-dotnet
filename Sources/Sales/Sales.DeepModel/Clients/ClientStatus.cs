using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Clients;

[DddValueObject]
public enum ClientStatus
{
    Normal,
    Vip
}