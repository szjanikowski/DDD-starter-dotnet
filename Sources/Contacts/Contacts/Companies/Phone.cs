using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Contacts.Companies;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[DddEntity]
public class Phone
{
    [BindNever]
    [JsonIgnore]
    public Guid CompanyId { get; set; }

    [BindRequired]
    public string Number { get; set; }
}