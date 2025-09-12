using Noesis.P3.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.Fulfillment;

[Process(Name, ApplyOnNamespace = true)]
public static class FulfillmentProcess
{
    public const string Name = "Order fulfillment";
}