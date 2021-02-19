using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;
using System;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer;
        private Order _order;
        private readonly Product _product;
        private readonly Discount _discount;

        public OrderTests()
        {
            _customer = new Customer("Michael Peter", "michael_piterct@hotmail.com");
            _order = new Order(_customer, 0, null);
            _product = new Product("Produto 1", 10, true);
            _discount = new Discount(10, DateTime.Now.AddDays(5));

        }
        [TestMethod]
        [TestCategory("Domain")]
        public void Have_a_new_valid_order_it_was_must_generate_a_number_with_8_characters()
        {
            Assert.AreEqual(8, _order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Have_a_new_order_your_status_must_be_waiting_payment()
        {
            Assert.AreEqual(_order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Have_a_payment_order_your_status_must_be_waiting_delivery()
        {
            _order.AddItem(_product, 1);
            _order.Pay(10);
            Assert.AreEqual(_order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void The_status_order_must_be_canceled_when_the_order_was_cancel()
        {
            _order.AddItem(_product, 1);
            _order.Pay(10);
            _order.Cancel();
            Assert.AreEqual(_order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void There_no_product_in_item_not_add_item()
        {
            _order.AddItem(null, 10);
            Assert.AreEqual(_order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void There_is_a_item_order_with_quantity_less_or_equal_zero_not_must_add_item()
        {
            _order.AddItem(_product, -10);
            Assert.AreEqual(_order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void There_is_a_valid_order_the_total_order_must_be_equal_50()
        {
            _order.AddItem(_product, 5);
            Assert.AreEqual(_order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void There_is_a_expired_discount_total_order_must_be_equal_60()
        {
            _discount.SetExpireDate(DateTime.Now.AddDays(-10));
            _discount.Value();
            _order = new Order(_customer, 0, _discount);
            _order.AddItem(_product, 6);
            Assert.AreEqual(_order.Total(), 60);
        }


    }
}
