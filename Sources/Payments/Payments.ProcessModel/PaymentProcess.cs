using NoesisVision.Annotations.Domain;

namespace MyCompany.ECommerce.Payments;

[Process(Name, ApplyOnNamespace = true)]
public static class PaymentProcess
{
    public const string Name = "Payment";
}