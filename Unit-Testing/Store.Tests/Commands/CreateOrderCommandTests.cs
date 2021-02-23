using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;
using System;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        [TestMethod]
        [TestCategory("Handlers")]
        public void There_is_an_invalid_command_doesnt_create_order()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "131100782";
            command.PromoCode = "215445";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }
    }
}
