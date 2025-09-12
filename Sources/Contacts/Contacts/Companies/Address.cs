using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Noesis.P3.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Contacts.Companies;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[DddEntity]
public class Address
{
    [BindNever]
    [JsonIgnore]
    public Guid CompanyId { get; set; }

    [BindNever]
    [JsonIgnore]
    public Company Company { get; set; }

    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
}