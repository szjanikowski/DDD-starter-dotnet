using System.Reflection;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Loyalty;

public static class LoyaltyProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(LoyaltyProcessModelLayerInfo).Assembly;
}