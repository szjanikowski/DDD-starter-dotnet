using System.Collections.Generic;
using JetBrains.Annotations;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Database.Sql.EF
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DbOrder : Order.Data
    {
        public OrderId Id { get; set; }
        public bool IsPlaced { get; set; }
        public int Version { get; set; }
        public List<Order.Item> Items { get; set; }
    }
}