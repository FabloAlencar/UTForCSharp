using TestNinja.Fundamentals;
using NUnit.Framework;

/*
 * 31. Testing the Return Type of Methods
 */

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            // Arrange
            var controller = new CustomerController();

            // Action
            var result = controller.GetCustomer(0);

            // Assert - NotFound
            Assert.That(result, Is.TypeOf<NotFound>());

            // Assert - NotFound or one of its derivativer
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnNotFound()
        {
            // Arrange
            var controller = new CustomerController();

            // Action
            var result = controller.GetCustomer(1);

            // Assert - Ok
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}