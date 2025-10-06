using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Loyalty;

[UsedImplicitly]
public class GetLoyaltyReportsHandler(LoyaltyReportsRepository reportsRepository)
    : QueryHandler<GetLoyaltyReports, LoyaltyReportDto>
{
    [Actor("Administrator")]
    public async Task<LoyaltyReportDto> Handle(GetLoyaltyReports query)
    {
        var metrics = await reportsRepository.GetMetrics(query.FromDate, query.ToDate, query.ReportType);
        
        return new LoyaltyReportDto(
            query.FromDate,
            query.ToDate,
            query.ReportType,
            metrics);
    }
}