using Noesis.P3.Annotations.Domain;

namespace MyCompany.ECommerce.RiskManagement.Calculation;

[Process(Name, ApplyOnNamespace = true)]
public static class RiskScoreCalculationProcess
{
    public const string Name = "Risk score calculation";
}