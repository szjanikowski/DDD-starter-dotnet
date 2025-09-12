using System.Reflection;
using JetBrains.Annotations;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.ProductsDelivery;

[UsedImplicitly]
public class ProductsDeliveryDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(ProductsDeliveryDeepModelLayerInfo).Assembly;
}