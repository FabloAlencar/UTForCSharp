using System;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-01)] // Lesser than Minimal Speed (zeros)
        [TestCase(301)] // Greater than Maximal Speed (300)
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ReturnOutOfRangeExeption(int speed)
        {
            // Action and Assert
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>()); //Assert.Throws<ArgumentOutOfRangeException>(() => _demeritPointsCalculator.CalculateDemeritPoints(-1));
        }

        [Test]
        [TestCase(00)] // Speed is equal to Minimal Speed (zeros)
        [TestCase(65)] // Speed is equal to Speed Limit (65)
        public void CalculateDemeritPoints_LimitIsNotGreaterThanSpeedLimit_Return0(int speed)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(070, 01)] // Speed is greater than Speed Limit (65)
        [TestCase(300, 47)] // Speed is equal to Maximal Speed (300)
        public void CalculateDemeritPoints_LimitIstGreaterThanSpeedLimit_ReturnDemiritPoints(int speed, int expectedResult)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}