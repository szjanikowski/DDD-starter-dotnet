using System.Reflection;
using JetBrains.Annotations;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Payments;

[UsedImplicitly]
public class PaymentsDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(PaymentsDeepModelLayerInfo).Assembly;
}