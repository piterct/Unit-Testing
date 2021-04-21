using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Tests.Repositories;
using System;
using System.Collections.Generic;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private CreateOrderCommand _orderCreateCommand;

        public CreateOrderCommandTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _productRepository = new FakeProductRepository();
            _orderRepository = new FakeOrderRepository();

            List<CreateOrderItemCommand> itemsOrder = new List<CreateOrderItemCommand>();
            itemsOrder.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            itemsOrder.Add(new CreateOrderItemCommand(Guid.NewGuid(), 3));

            _orderCreateCommand = new CreateOrderCommand("", "05465845", "Azure", itemsOrder);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void There_is_an_invalid_command_doesnt_create_order()
        {
            _orderCreateCommand.Validate();
            Assert.AreEqual(_orderCreateCommand.Valid, false);
        }


    }
}
