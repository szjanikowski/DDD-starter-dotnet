namespace MyCompany.ECommerce.Loyalty;

public readonly struct PointTransactionDto(
    TransactionType type,
    int amount,
    Guid? orderId,
    DateTime createdAt,
    DateTime? expiresAt,
    string description)
{
    public TransactionType Type { get; } = type;
    public int Amount { get; } = amount;
    public Guid? OrderId { get; } = orderId;
    public DateTime CreatedAt { get; } = createdAt;
    public DateTime? ExpiresAt { get; } = expiresAt;
    public string Description { get; } = description;

    public static PointTransactionDto FromDomain(PointTransaction transaction) =>
        new(transaction.Type,
            transaction.Amount,
            transaction.OrderId,
            transaction.CreatedAt,
            transaction.ExpiresAt,
            transaction.Description);
}