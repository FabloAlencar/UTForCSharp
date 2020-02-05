using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            // Arrange
            var product = new Product { ListPrice = 100 };

            // Act
            var result = product.GetPrice(new Customer { IsGold = true });

            // Assert
            Assert.That(result, Is.EqualTo(70));
        }

        /*
         *
         * 57. An Example of a Mock Abuse
         */

        //[Test]
        //public void GetPrice_GoldCustomer_Apply30PercentDiscount2()
        //{
        //    // Arrange
        //    var mockCustomer = new Mock<ICustomer>();
        //    mockCustomer.Setup(c => c.IsGold).Returns(true);

        //    var product = new Product { ListPrice = 100 };

        //    // Act
        //    var result = product.GetPrice(mockCustomer.Object);

        //    // Assert
        //    Assert.That(result, Is.EqualTo(70));
        //}
    }
}