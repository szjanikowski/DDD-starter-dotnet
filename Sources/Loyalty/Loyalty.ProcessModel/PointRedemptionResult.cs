namespace MyCompany.ECommerce.Loyalty;

public readonly struct PointRedemptionResult(
    bool isSuccess,
    int pointsRedeemed,
    decimal discountAmount,
    int availablePoints,
    string? errorMessage = null)
{
    public bool IsSuccess { get; } = isSuccess;
    public int PointsRedeemed { get; } = pointsRedeemed;
    public decimal DiscountAmount { get; } = discountAmount;
    public int AvailablePoints { get; } = availablePoints;
    public string? ErrorMessage { get; } = errorMessage;

    public static PointRedemptionResult Success(int pointsRedeemed, decimal discountAmount) =>
        new(true, pointsRedeemed, discountAmount, 0);

    public static PointRedemptionResult InsufficientPoints(int availablePoints, int requestedPoints) =>
        new(false, 0, 0, availablePoints, $"Insufficient points. Available: {availablePoints}, Requested: {requestedPoints}");

    public static PointRedemptionResult FromDomain(RedemptionResult domainResult) =>
        domainResult.IsSuccess
            ? Success(domainResult.PointsRedeemed, domainResult.DiscountAmount)
            : InsufficientPoints(domainResult.AvailablePoints, 0);
}