using MyCompany.ECommerce.Sales.Clients;

namespace MyCompany.ECommerce.Loyalty;

public partial class LoyaltyAccount
{
    private readonly Data _data;

    private LoyaltyAccount(Data data) => _data = data;

    public static LoyaltyAccount RestoreFrom(Data data) => new(data);

    public interface Data : IEquatable<Data>
    {
        ClientId ClientId { get; }
        int CurrentBalance { get; set; }
        int TotalEarned { get; set; }
        int TotalRedeemed { get; set; }
        IReadOnlyList<PointTransaction> Transactions { get; }
        
        void AddTransaction(PointTransaction transaction);

        bool IEquatable<Data>.Equals(Data? other) =>
            other is not null &&
            ClientId.Equals(other.ClientId) &&
            CurrentBalance == other.CurrentBalance &&
            TotalEarned == other.TotalEarned &&
            TotalRedeemed == other.TotalRedeemed &&
            Transactions.SequenceEqual(other.Transactions);
    }
}