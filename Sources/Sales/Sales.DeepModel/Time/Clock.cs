using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Time;

[DddDomainService]
public interface Clock
{
    DateTime Now { get; }
}