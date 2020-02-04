using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class VideoServiceTests
    {
        /*
         *
         * 48. Dependency Injection via Method Parameters
         */

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // Arrange
            var service = new VideoService();

            // Act
            //var result = service.ReadVideoTitle(new FakeFileReader());
            var result = service.ReadVideoTitle();

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}