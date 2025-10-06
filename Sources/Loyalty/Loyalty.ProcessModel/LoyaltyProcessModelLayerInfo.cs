using System.Reflection;
using NoesisVision.Annotations.Domain;
using NoesisVision.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Loyalty;

public static class LoyaltyProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(LoyaltyProcessModelLayerInfo).Assembly;
}