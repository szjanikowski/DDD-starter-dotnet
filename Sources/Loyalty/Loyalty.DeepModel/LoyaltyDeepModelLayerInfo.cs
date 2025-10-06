using System.Reflection;
using System.Runtime.CompilerServices;
using NoesisVision.Annotations.Domain;
using NoesisVision.Annotations.Domain.DDD;
using NoesisVision.Annotations.Technology.CleanArchitecture;

[assembly: InternalsVisibleTo("MyCompany.ECommerce.Monolith.Startup")]
[assembly: InternalsVisibleTo("MyCompany.ECommerce.Loyalty.IntegrationTests")]
[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Loyalty;

public static class LoyaltyDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(LoyaltyDeepModelLayerInfo).Assembly;
}