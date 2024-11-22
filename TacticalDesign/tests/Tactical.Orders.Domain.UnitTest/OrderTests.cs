using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Entities;
using Tactical.Orders.Domain.Orders.Exceptions;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.UnitTest
{
    public class OrderTests : OrderSelfShunt

    {
        private VendorId vendorId;
        private string couponCode = "";
        public OrderTests()
        {
            vendorId = new VendorId(1);
        }

        [Fact]
        public void Create_Order_With_null_Items_Test_Should_Be_Throw_Exception()
        {
            Assert.Throws<EmptyOrderItemsException>(() => new Order(null, vendorId, couponCode, this, this, this));
        }

        [Fact]
        public void Create_Order_With_Out_Items_Test_Should_Be_Throw_Exception()
        {
            Assert.Throws<EmptyOrderItemsException>(() => new Order(new List<OrderItem>(), vendorId, couponCode, this, this, this));
        }

        //[Fact]
        //public void Create_Valid_Order_Test_Order_Should_Be_Created()
        //{
        //    var menuItemId = Guid.NewGuid();
        //    var menuItemId2 = Guid.NewGuid();
        //    var Items = new List<OrderItem>()
        //    {
        //        new OrderItem(menuItemId,"چلو کباب",200000),
        //        new OrderItem(menuItemId2,"جوجه کباب",300000),
        //    };
        //    var order = new Order(Items, vendorId, this, this, this);
        //}

     
    }
}