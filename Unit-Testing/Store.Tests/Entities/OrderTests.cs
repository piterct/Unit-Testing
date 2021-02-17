﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;
using System;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {

        private readonly Customer _customer;
        private readonly Order _order;
        private readonly Product _product;

        public OrderTests()
        {
            _customer = new Customer("Michael Peter", "michael_piterct@hotmail.com");
            _order = new Order(_customer, 0, null);
            _product = new Product("Produto 1", 10, true);
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
    }
}
