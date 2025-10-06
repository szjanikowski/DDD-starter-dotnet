using System.Reflection;
using NoesisVision.Annotations.Technology.CleanArchitecture;

[assembly: AdaptersLayer]

namespace MyCompany.ECommerce.Loyalty;

public static class LoyaltyAdaptersLayerInfo
{
    public static Assembly Assembly => typeof(LoyaltyAdaptersLayerInfo).Assembly;
}