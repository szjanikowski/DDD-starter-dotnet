using System.Reflection;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Sales;

public static class SalesProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(SalesProcessModelLayerInfo).Assembly;
}