namespace UniqueList.UniqueListTests
{
    public class Tests
    {
        private UniqueList<int> uniqueList;

        [SetUp]
        public void Setup()
        {
            uniqueList = new();
            for (int value = 0; value < 5; value++)
            {
                uniqueList.Add(value);
            }
        }
        [Test]
        public void AddAlreadyExistingShouldException()
        {
            Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Add(0));
            Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Add(4));
        }

        [Test]
        public void ChangeValueToAlreadyExistingShouldException()
        {
            Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Change(0, 3));
        }

        [Test]
        public void ChangeValueToTheSameShouldNothingChange()
        {
            uniqueList.Change(1, 1);
            Assert.That(uniqueList[1], Is.EqualTo(1));
        }
    }
}