using System.Reflection;
using JetBrains.Annotations;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology.CleanArchitecture;

[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.RiskManagement;

[UsedImplicitly]
public class RiskManagementDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(RiskManagementDeepModelLayerInfo).Assembly;
}