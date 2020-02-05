using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        /*
         *
         * 67. Testing EmployeeController
         */

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            // Arrange
            var mockStorage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(mockStorage.Object);

            // Act
            controller.DeleteEmployee(1);

            // Assert
            mockStorage.Verify(s => s.DeleteEmployee(1));
        }
    }
}