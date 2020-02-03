using TestNinja.Fundamentals;
using NUnit.Framework;
using System.Linq;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _math = new Math();
        }

        /*
         *
         * 20. Writing a Simple Unit Test
         */

        [Test]
        //[Ignore("Because I wanted to")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            // Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)] // First is greater
        [TestCase(1, 2, 2)] // Second is greater
        [TestCase(1, 1, 1)] // They are equal
        public void Add_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            // Act
            var result = _math.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /*
         *
         * 30. Testing Arrays and Collections
         */

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            // Act
            var result = _math.GetOddNumbers(5);

            //Assert
            Assert.That(result, Is.Not.Empty);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(3));

            //Assert
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            //Assert
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            // Assert
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}