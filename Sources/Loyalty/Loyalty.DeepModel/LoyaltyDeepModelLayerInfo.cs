using System.Reflection;
using System.Runtime.CompilerServices;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Domain.DDD;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: InternalsVisibleTo("MyCompany.ECommerce.Monolith.Startup")]
[assembly: InternalsVisibleTo("MyCompany.ECommerce.Loyalty.IntegrationTests")]
[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Loyalty;

public static class LoyaltyDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(LoyaltyDeepModelLayerInfo).Assembly;
}