using MyCompany.ECommerce.Sales.Clients;
using NoesisVision.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Loyalty;

[DddValueObject]
public readonly struct PointTransaction : IEquatable<PointTransaction>
{
    public TransactionType Type { get; }
    public int Amount { get; }
    public Guid? OrderId { get; }
    public DateTime CreatedAt { get; }
    public DateTime? ExpiresAt { get; }
    public string Description { get; }

    public static PointTransaction Earned(int amount, Guid orderId, DateTime createdAt, DateTime expiresAt, string description = "") =>
        new(TransactionType.Earned, amount, orderId, createdAt, expiresAt, description);

    public static PointTransaction Redeemed(int amount, Guid orderId, DateTime createdAt, string description = "") =>
        new(TransactionType.Redeemed, amount, orderId, createdAt, null, description);

    public static PointTransaction Expired(int amount, DateTime createdAt, string description = "") =>
        new(TransactionType.Expired, amount, null, createdAt, null, description);

    private PointTransaction(TransactionType type, int amount, Guid? orderId, DateTime createdAt, DateTime? expiresAt, string description)
    {
        if (amount <= 0)
            throw new ArgumentException("Point amount must be positive", nameof(amount));
        
        if (type == TransactionType.Earned && !expiresAt.HasValue)
            throw new ArgumentException("Earned points must have expiration date", nameof(expiresAt));
        
        if (type != TransactionType.Earned && expiresAt.HasValue)
            throw new ArgumentException("Only earned points can have expiration date", nameof(expiresAt));

        Type = type;
        Amount = amount;
        OrderId = orderId;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
        Description = description ?? string.Empty;
    }

    public bool IsExpiredOn(DateTime date) => ExpiresAt.HasValue && ExpiresAt.Value <= date;

    public bool Equals(PointTransaction other) =>
        Type == other.Type &&
        Amount == other.Amount &&
        OrderId == other.OrderId &&
        CreatedAt == other.CreatedAt &&
        ExpiresAt == other.ExpiresAt &&
        Description == other.Description;

    public override bool Equals(object? obj) => obj is PointTransaction other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Type, Amount, OrderId, CreatedAt, ExpiresAt, Description);

    public override string ToString() => $"{Type} {Amount} points" + (OrderId.HasValue ? $" (Order: {OrderId})" : "");
}

public enum TransactionType
{
    Earned,
    Redeemed,
    Expired
}