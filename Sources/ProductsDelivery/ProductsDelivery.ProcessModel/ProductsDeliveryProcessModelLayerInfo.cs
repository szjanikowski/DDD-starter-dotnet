using System.Reflection;
using JetBrains.Annotations;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.ProductsDelivery;

[UsedImplicitly]
public class ProductsDeliveryProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(ProductsDeliveryProcessModelLayerInfo).Assembly;
}