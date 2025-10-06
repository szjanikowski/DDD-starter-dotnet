using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Loyalty;

public partial class LoyaltyAccount
{
    private readonly List<Event> _newEvents = new();
    public IReadOnlyList<Event> NewEvents => _newEvents.AsReadOnly();

    private void AddAndApply(Event @event)
    {
        @event.Apply(this);
        _newEvents.Add(@event);
    }

    public interface Event
    {
        void Apply(LoyaltyAccount account);
    }

    [Event]
    public class PointsAwarded(PointTransaction transaction) : Event
    {
        public PointTransaction Transaction { get; } = transaction;

        public void Apply(LoyaltyAccount account)
        {
            account._data.AddTransaction(Transaction);
            account._data.CurrentBalance += Transaction.Amount;
            account._data.TotalEarned += Transaction.Amount;
        }
    }

    [Event]
    public class PointsRedeemed(PointTransaction transaction, decimal discountAmount) : Event
    {
        public PointTransaction Transaction { get; } = transaction;
        public decimal DiscountAmount { get; } = discountAmount;

        public void Apply(LoyaltyAccount account)
        {
            account._data.AddTransaction(Transaction);
            account._data.CurrentBalance -= Transaction.Amount;
            account._data.TotalRedeemed += Transaction.Amount;
        }
    }

    [Event]
    public class PointsExpired(PointTransaction transaction) : Event
    {
        public PointTransaction Transaction { get; } = transaction;

        public void Apply(LoyaltyAccount account)
        {
            account._data.AddTransaction(Transaction);
            account._data.CurrentBalance -= Transaction.Amount;
        }
    }
}