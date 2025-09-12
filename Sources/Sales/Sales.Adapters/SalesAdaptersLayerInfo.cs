using System.Reflection;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: AdaptersLayer]

namespace MyCompany.ECommerce.Sales;

public static class SalesAdaptersLayerInfo
{
    public static Assembly Assembly => typeof(SalesAdaptersLayerInfo).Assembly;
}