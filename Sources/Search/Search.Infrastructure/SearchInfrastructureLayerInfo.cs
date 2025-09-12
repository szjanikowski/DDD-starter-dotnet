using System.Reflection;
using System.Runtime.CompilerServices;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology;

[assembly: InternalsVisibleTo("MyCompany.ECommerce.Search.Startup")]
[assembly: Layer("Infrastructure")]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Search;

public static class SearchInfrastructureLayerInfo
{
    public static Assembly Assembly => typeof(SearchInfrastructureLayerInfo).Assembly;
}