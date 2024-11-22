using FluentAssertions;
using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Orders.Entities;
using Tactical.Orders.Domain.Orders.Exceptions;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.UnitTest
{
    public class OrderStateTests : OrderSelfShunt
    {
        private Order _order;
        private VendorId vendorId = new VendorId(1);
        private string couponCode = "";
        public OrderStateTests()
        {
            _order = CreateOrder();
        }

        [Fact]
        public void Change_Order_State_From_Submitted_To_Paid_State_Should_Be_Change()
        {
            _order.ChangeState(OrderStateEnum.Paid);
            _order.State.Should().Be(OrderStateEnum.Paid);
            _order.OrderHistories.OrderByDescending(x => x.CreateDate).First().State.State.Should().Be(OrderStateEnum.Paid);
        }

        [Fact]
        public void Change_Order_State_From_Submitted_To_Rejected_State_Should_Be_Change()
        {
            _order.ChangeState(OrderStateEnum.Rejected);
            _order.State.Should().Be(OrderStateEnum.Rejected);
            _order.OrderHistories.OrderByDescending(x => x.CreateDate).First().State.State.Should().Be(OrderStateEnum.Rejected);
        }

        [Fact]
        public void Change_Order_State_From_Submitted_To_Submitted_Test_Should_Be_Throw_Exception()
        {
            Assert.Throws<NotValidStateException>(() => _order.ChangeState(OrderStateEnum.Submitted));
        }

        [Fact]
        public void Change_Order_State_From_Submitted_To_Accepted_Test_Should_Be_Throw_Exception()
        {
            Assert.Throws<NotValidStateException>(() => _order.ChangeState(OrderStateEnum.Accepted));
        }

        private Order CreateOrder() => new Order(CreateOrderItems(), vendorId, couponCode, this, this, this);
        private List<OrderItem> CreateOrderItems()
        {
            return new List<OrderItem>() {
                new OrderItem(Guid.NewGuid(),"Kebab",10000),
                new OrderItem(Guid.NewGuid(),"ChickenKebab",20000),
            };
        }
    }
}
