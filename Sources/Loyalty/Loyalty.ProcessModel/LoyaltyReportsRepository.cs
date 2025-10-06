namespace MyCompany.ECommerce.Loyalty;

public interface LoyaltyReportsRepository
{
    Task<LoyaltyMetricsDto> GetMetrics(DateTime fromDate, DateTime toDate, LoyaltyReportType reportType);
}