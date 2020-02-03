using TestNinja.Fundamentals;
using NUnit.Framework;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        /*
        *
        * 32. Testing Void Methods
        */

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            // Arrange
            var logger = new ErrorLogger();

            // Action
            logger.Log("a");

            // Assert
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        /*
         *
         * 33. Testing Methods that Throw Exceptions
         */

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            // Arrange
            var logger = new ErrorLogger();

            // Action //Assert
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }

        /*
         *
         * 34. Testing Methods that Raise an Event
         */

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            // Arrange
            var logger = new ErrorLogger();
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            // Action
            logger.Log("a");

            // Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}