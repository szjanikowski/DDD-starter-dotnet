using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Loyalty;

public readonly struct GetLoyaltyBalance(Guid clientId, int pageSize = 20, int pageNumber = 1) : Query
{
    public Guid ClientId { get; } = clientId;
    public int PageSize { get; } = pageSize;
    public int PageNumber { get; } = pageNumber;
}