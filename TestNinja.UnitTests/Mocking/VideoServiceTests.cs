using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class VideoServiceTests
    {
        private Mock<IFileReader> _mockFileReader;
        private VideoService _service;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _mockFileReader = new Mock<IFileReader>();
            _service = new VideoService(_mockFileReader.Object);
        }

        /*
         *
         * 48. Dependency Injection via Method Parameters
         */

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // .. continue Arrange
            //var service = new VideoService();
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            // Act
            //var result = service.ReadVideoTitle(new FakeFileReader());
            var result = _service.ReadVideoTitle();

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}