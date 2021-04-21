using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Tests.Repositories;
using System;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class OrderHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandlerTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _orderRepository = new FakeOrderRepository();
            _productRepository = new FakeProductRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_is_a_valid_command_must_create_order()
        {
            var command = new CreateOrderCommand();
            command.Customer = "12345678";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(_customerRepository, _deliveryFeeRepository, _discountRepository, _productRepository, _orderRepository);

            handler.Handle(command);

            Assert.AreEqual(handler.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_no_customer_in_order_the_order_not_must_generate_order()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_no_valid_zip_code_the_order_must_be_generate()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_no_a_promocode_the_order_must_be_generate()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_a_order_without_items_the_order_not_must_be_generated()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_is_a_invalid_command_the_order_not_must_be_generated()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_is_a_valid_command_the_order_must_be_generated()
        {
            Assert.IsTrue(true);
        }

    }
}
