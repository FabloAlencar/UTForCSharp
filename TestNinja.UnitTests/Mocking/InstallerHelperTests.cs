using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _mockFileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _mockFileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_mockFileDownloader.Object);
        }

        /*
         *
         * 64. Testing InstallerHelper
         */

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            // .. continue Arrange
            _mockFileDownloader.Setup(fd =>
            fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            // Act
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {
            // Act
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            // Assert
            Assert.That(result, Is.True);
        }
    }
}