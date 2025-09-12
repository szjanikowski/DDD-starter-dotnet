using System.Reflection;
using JetBrains.Annotations;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Payments;

[UsedImplicitly]
public class PaymentsProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(PaymentsProcessModelLayerInfo).Assembly;
}