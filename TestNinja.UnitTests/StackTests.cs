using TestNinja.Fundamentals;
using NUnit.Framework;
using System.Linq;

/*
 *
 * 43. Exercise- Stack
 */

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            // Action and Assert
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            // Action
            _stack.Push("a");

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Push_EmptyStack_ReturnZero()
        {
            // No Action

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            // Action and Assert
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
        {
            // .. continuing Arrange
            _stack.Push("e");
            _stack.Push("a");
            _stack.Push("s");

            // Action
            var result = _stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo("s"));
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
        {
            // .. continuing Arrange
            _stack.Push("e");
            _stack.Push("a");
            _stack.Push("s");

            // Action
            _stack.Pop();

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            // Action and Assert
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTheTopOfTheStack()
        {
            // .. continuing Arrange
            _stack.Push("e");
            _stack.Push("a");
            _stack.Push("s");

            // Action
            var result = _stack.Peek();

            // Assert
            Assert.That(result, Is.EqualTo("s"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTheTopOfTheStack()
        {
            // .. continuing Arrange
            _stack.Push("e");
            _stack.Push("a");
            _stack.Push("s");

            // Action
            _stack.Peek();

            // Assert
            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}