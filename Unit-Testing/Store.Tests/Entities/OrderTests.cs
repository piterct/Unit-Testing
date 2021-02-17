using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Have_a_new_valid_order_it_was_did_must_generate_a_number_with_8_characters()
        {
            var customer = new Customer("Michael Peter", "michael_piterct@hotmail.com");
            var order = new Order(customer, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Have_a_new_order_your_status_must_be_waiting_payment()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Have_a_payment_order_your_status_must_be_waiting_delivery()
        {
            Assert.Fail();
        }
    }
}
