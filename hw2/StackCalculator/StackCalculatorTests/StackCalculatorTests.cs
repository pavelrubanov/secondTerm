using StackCalculator;

namespace StackCalculator.StackCalculatorTests
{
    public class Tests
    {
        private IStack stack;
        [SetUp]
        public void Setup()
        {
            stack = new StackOnLinkedList();
            //stack = new StackOnList();
        }

        [Test]
        public void NullExpressionShouldThrowArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() => StackCalculator.Calculate(null, stack));
        }

        [Test]
        public void EmptyExpressionShouldThrowArgumentException()
        {
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("", stack));
        }

        [Test]
        public void NotEmptyStackShouldThrowArgumentException()
        {
            stack.Push(1);
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("2 2 +", stack));
        }

        [Test]
        public void DivideByZeroShouldThrowDivideByZeroException()
        {
            Assert.Catch<DivideByZeroException>(() => StackCalculator.Calculate("2 0 /", stack));
        }

        [Test]
        public void ExtraNumberInExpressionShouldThrowArgumentException()
        {
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("2 2 0 0 0 +", stack));
        }

        [Test]
        public void ExtraOperationsInExpressionShouldThrowArgumentException()
        {
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("2 2 + +", stack));
        }

        [Test]
        public void StandartExpessionShouldGiveRightAnswer()
        {
            Assert.That(StackCalculator.Calculate("1 2 3 + *", stack),Is.EqualTo(5));
        }
    }
} 