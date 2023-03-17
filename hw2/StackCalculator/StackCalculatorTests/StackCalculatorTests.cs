using StackCalculator;

namespace StackCalculator.StackCalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        private static IEnumerable<TestCaseData> Stacks
            => new TestCaseData[]
                {
                    new TestCaseData(new StackOnLinkedList()),
                    new TestCaseData(new StackOnList()),
                };

        [TestCaseSource(nameof(Stacks))]
        public void NullExpressionShouldThrowArgumentNullException(IStack stack)
        {
            Assert.Catch<ArgumentNullException>(() => StackCalculator.Calculate(null, stack));
        }

        [TestCaseSource(nameof(Stacks))]
        public void EmptyExpressionShouldThrowArgumentException(IStack stack)
        {
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("", stack));
        }

        [TestCaseSource(nameof(Stacks))]
        public void NotEmptyStackShouldThrowArgumentException(IStack stack)
        {
            stack.Push(1);
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("2 2 +", stack));
        }

        [TestCaseSource(nameof(Stacks))]
        public void DivideByZeroShouldThrowDivideByZeroException(IStack stack)
        {
            Assert.Catch<DivideByZeroException>(() => StackCalculator.Calculate("2 0 /", stack));
        }

        [TestCaseSource(nameof(Stacks))]
        public void ExtraNumberInExpressionShouldThrowArgumentException(IStack stack)
        {
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("2 2 0 0 0 +", stack));
        }

        [TestCaseSource(nameof(Stacks))]
        public void ExtraOperationsInExpressionShouldThrowArgumentException(IStack stack)
        {
            Assert.Catch<ArgumentException>(() => StackCalculator.Calculate("2 2 + +", stack));
        }

        [TestCaseSource(nameof(Stacks))]
        public void StandartExpessionShouldGiveRightAnswer(IStack stack)
        {
            Assert.That(StackCalculator.Calculate("1 2 3 + *", stack),Is.EqualTo(5));
        }
    }
} 