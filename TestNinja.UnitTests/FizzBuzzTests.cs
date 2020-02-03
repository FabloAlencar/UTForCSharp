using TestNinja.Fundamentals;
using NUnit.Framework;
using System.Linq;

/*
 *
 * 39. 19- Exercise- FizzBuzz
 */

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            // Act
            var result = FizzBuzz.GetOutput(15);

            //Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            // Act
            var result = FizzBuzz.GetOutput(3);

            //Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            // Act
            var result = FizzBuzz.GetOutput(5);

            //Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy3Ord5_ReturnTheSameNumber()
        {
            // Act
            var result = FizzBuzz.GetOutput(1);

            //Assert
            Assert.That(result, Is.EqualTo("1"));
        }
    }
}

//[TestFixture]
//public class FizzBuzzTests
//{
//    [Test]
//    [TestCase(15, "FizzBuzz")]  // Return FizzBuzz
//    [TestCase(3, "Fizz")]       // Return Fizz
//    [TestCase(5, "Buzz")]       // Return Buzz
//    [TestCase(1, "1")]          // Return number provided
//    public void GetOutput_CheckDivisibilityBy3And5_ReturnFizzOrBuzzOrFizzBuzz(int number, string expectedResult)
//    {
//        // Act
//        var result = FizzBuzz.GetOutput(number);

//        //Assert
//        Assert.That(result, Is.EqualTo(expectedResult));
//    }
//}