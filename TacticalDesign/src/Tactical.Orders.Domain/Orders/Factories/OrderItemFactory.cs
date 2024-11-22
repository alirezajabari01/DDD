using System.Linq;
using Tactical.Orders.Domain.Orders.Arguments;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Entities;

namespace Tactical.Orders.Domain.Orders.Factories
{
    public static class OrderItemFactory
    {
        public async static Task<List<OrderItem>> Create(List<Guid> orderItemIds, IMenuItemDomainService menuItemDomainService, CancellationToken cancellationToken)
        {
            return await menuItemDomainService.GetOrderItemAsync(orderItemIds, cancellationToken);
        }

        public async static Task<List<OrderItem>> Create(List<OrderItemArg> Items, IMenuItemDomainService menuItemDomainService, IToppingDomainService toppingDomainService, CancellationToken cancellationToken)
        {
            var orderItems = await menuItemDomainService.GetOrderItemAsync(Items.Select(x => x.ItemId).ToList(), cancellationToken);

            var orderItemToppings = await GetToppingAsync(Items, toppingDomainService, cancellationToken);

            CreateOrderItems(Items, orderItems, orderItemToppings);

            return orderItems;
        }

        private static void CreateOrderItems(List<OrderItemArg> Items, List<OrderItem> orderItems, List<OrderItemToppingContract> orderItemToppings)
        {
            Items.ForEach(x =>
            {
                var orderItem = orderItems.FirstOrDefault(i => i.MenuItemId == x.ItemId) ?? throw new Exception();
                orderItem.SetCount(x.Count);

                if (x.Toppings is not null)
                {
                    var result = new List<OrderItemTopping>();

                    x.Toppings.ForEach(y =>
                    {
                        var topping = orderItemToppings.FirstOrDefault(z => z.ToppingId == y.ToppingId)!;
                        result.Add(new OrderItemTopping(topping.ToppingId, topping.Title, topping.Price, y.Count));
                    });

                    orderItem.SetToppings(result);
                }
            });
        }

        private static async Task<List<OrderItemToppingContract>> GetToppingAsync(List<OrderItemArg> Items, IToppingDomainService toppingDomainService, CancellationToken cancellationToken)
        {


            var toppingArg = Items.Select(x => x.Toppings?.Select(t => new { t.Count, t.ToppingId }))
                .Where(y => y.Any())
                .SelectMany(i => i)
                .ToList();

            var toppingContracts = await toppingDomainService.GetToppingAsync(toppingArg.Select(x => x.ToppingId).ToList(), cancellationToken);

            return toppingContracts.DistinctBy(x => x.ToppingId).ToList();
        }
    }
}
