using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tactical.Framework.Persistence.EF;
using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Persistence.EF.Contexts;

namespace Tactical.Orders.Persistence.EF.Orders
{
    public class OrderRepository : BaseRepository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }

        //protected override Expression<Func<Order, object>>[] GetIncludeExpressions()
        //{
        //    return new Expression<Func<Order, object>>[]
        //    {
        //        x => x.OrderItems,
        //        x => x.OrderItems.Select(t => t.OrderItemToppings)
        //    };
        //}
    }
}
