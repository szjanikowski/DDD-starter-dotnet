using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Loyalty;

public readonly struct GetLoyaltyReports(
    DateTime fromDate,
    DateTime toDate,
    LoyaltyReportType reportType = LoyaltyReportType.Summary) : Query
{
    public DateTime FromDate { get; } = fromDate;
    public DateTime ToDate { get; } = toDate;
    public LoyaltyReportType ReportType { get; } = reportType;
}

public enum LoyaltyReportType
{
    Summary,
    CustomerParticipation,
    PointsExpiration,
    RedemptionAnalysis
}