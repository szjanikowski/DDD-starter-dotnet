namespace MyCompany.ECommerce.Loyalty;

public readonly struct LoyaltyReportDto(
    DateTime fromDate,
    DateTime toDate,
    LoyaltyReportType reportType,
    LoyaltyMetricsDto metrics)
{
    public DateTime FromDate { get; } = fromDate;
    public DateTime ToDate { get; } = toDate;
    public LoyaltyReportType ReportType { get; } = reportType;
    public LoyaltyMetricsDto Metrics { get; } = metrics;
}

public readonly struct LoyaltyMetricsDto(
    int totalPointsIssued,
    int totalPointsRedeemed,
    int totalPointsExpired,
    int activeCustomers,
    int totalCustomers,
    decimal participationRate,
    decimal averagePointsPerCustomer,
    decimal redemptionRate)
{
    public int TotalPointsIssued { get; } = totalPointsIssued;
    public int TotalPointsRedeemed { get; } = totalPointsRedeemed;
    public int TotalPointsExpired { get; } = totalPointsExpired;
    public int ActiveCustomers { get; } = activeCustomers;
    public int TotalCustomers { get; } = totalCustomers;
    public decimal ParticipationRate { get; } = participationRate;
    public decimal AveragePointsPerCustomer { get; } = averagePointsPerCustomer;
    public decimal RedemptionRate { get; } = redemptionRate;
}