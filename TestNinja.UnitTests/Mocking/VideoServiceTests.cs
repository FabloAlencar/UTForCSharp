using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class VideoServiceTests
    {
        private Mock<IFileReader> _mockFileReader;
        private Mock<IVideoRepository> _repository;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _mockFileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_mockFileReader.Object, _repository.Object);
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
            var result = _videoService.ReadVideoTitle();

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        /*
         *
         * 59. Exercise- VideoService
         */

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            // .. continue Arrange
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            // .. continue Arrange
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3}
            });

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}