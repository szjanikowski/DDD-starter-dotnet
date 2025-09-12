using System.Reflection;
using JetBrains.Annotations;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.RiskManagement;

[UsedImplicitly]
public class RiskManagementProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(RiskManagementProcessModelLayerInfo).Assembly;
}