namespace Tactical.Orders.Query.Contract.MenuItems
{
    public class ItemPriceContract
    {
        public ItemPriceContract() { }
        public ItemPriceContract(Guid id, long price, int count)
        {
            Id = id;
            Price = price;
            Count = count;
        }

        public Guid Id { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }
    }
}
