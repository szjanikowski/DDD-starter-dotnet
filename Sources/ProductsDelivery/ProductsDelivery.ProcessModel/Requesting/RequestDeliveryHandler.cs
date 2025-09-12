using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using Noesis.P3.Annotations.Domain;

namespace MyCompany.ECommerce.ProductsDelivery.Requesting;

[UsedImplicitly]
public class RequestDeliveryHandler : CommandHandler<RequestDelivery>
{
    [EntryPoint(nameof(RequestDelivery), Process = ProductsDeliveryProcess.Name)]
    public Task Handle(RequestDelivery command)
    {
        throw new NotImplementedException();
    }
}