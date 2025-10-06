using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: AdaptersLayer]

namespace MyCompany.ECommerce.Loyalty;

[UsedImplicitly]
public static class LoyaltyRestApiLayerInfo
{
    public static Assembly Assembly => typeof(LoyaltyRestApiLayerInfo).Assembly;
}