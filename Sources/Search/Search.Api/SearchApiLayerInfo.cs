using System.Reflection;
using System.Runtime.CompilerServices;
using Noesis.P3.Annotations.Domain;
using Noesis.P3.Annotations.Technology;

[assembly: InternalsVisibleTo("MyCompany.ECommerce.Search.Startup")]
[assembly: Layer("Api")]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Search;

public static class SearchApiLayerInfo
{
    public static Assembly Assembly => typeof(SearchApiLayerInfo).Assembly;
}