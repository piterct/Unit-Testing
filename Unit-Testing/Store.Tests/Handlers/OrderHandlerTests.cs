using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Repositories;
using Store.Tests.Repositories;

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
        public void There_no_customer_in_order_the_order_not_must_generate_order()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_no_valid_zip_code_the_order_must_be_generate()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_no_a_promocode_the_order_must_be_generate()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_a_order_without_items_the_order_not_must_be_generated()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_is_a_invalid_command_the_order_not_must_be_generated()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void There_is_a_valid_command_the_order_must_be_generated()
        {
            Assert.Fail();
        }

    }
}
