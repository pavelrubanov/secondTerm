
namespace Bor.Tests
{
    public class Tests
    {
        [Test]
        public void AddUncontainedStringShouldAddAndReturnTrue()
        {
            Bor bor = new Bor();
            Assert.IsTrue(bor.Add("NewString"));
            Assert.IsTrue(bor.Add("NewStr"));
            Assert.That(bor.Size, Is.EqualTo(2));
        }
        [Test]
        public void AddContainedStringShouldReturnFalse()
        {
            Bor bor = new Bor();
            Assert.IsTrue(bor.Add("NewString"));
            Assert.IsFalse(bor.Add("NewString"));
            Assert.That(bor.Size, Is.EqualTo(1));
        }
        [Test]
        public void AddEmptyString()
        {
            var bor = new Bor();
            Assert.IsTrue(bor.Add(""));
            Assert.IsFalse(bor.Add(""));
            Assert.That(bor.Size, Is.EqualTo(1));
        }
        [Test]
        public void AddNullStringShouldThrowException()
        {
            Bor bor = new();
            Assert.Catch<ArgumentNullException>(() => bor.Add(null));
        }
        [Test]
        public void RemoveContainedStringShouldRemoveAndReturnTrue()
        {
            Bor bor = new Bor();
            bor.Add("Element");
            Assert.IsTrue(bor.Remove("Element"));
            Assert.That(bor.Size, Is.EqualTo(0));
        }
        [Test]
        public void RemoveUncontainedStringShouldReturnFalse()
        {
            var bor = new Bor();
            bor.Add("NewElement");
            Assert.IsFalse(bor.Remove("Element"));
        }
        [Test]
        public void RemoveNullStringShouldThrowException()
        {
            Bor bor = new();
            Assert.Catch<ArgumentNullException>(() => bor.Remove(null));
        }
        [Test]
        public void Contains()
        {
            var bor = new Bor();
            bor.Add("Str101");
            Assert.IsTrue(bor.Contains("Str101"));
            Assert.IsFalse(bor.Contains("Str"));
        }
        [Test]
        public void ContainsNullShouldThrowException()
        {
            var bor = new Bor();
            Assert.Catch<ArgumentNullException>(() => bor.Contains(null));
        }
        [Test]
        public void HowManyStartsWithPrefix()
        {
            var bor = new Bor();
            bor.Add("1");
            bor.Add("12");
            bor.Add("1234");
            bor.Add("12345");
            Assert.That(bor.HowManyStartsWithPrefix("1"), Is.EqualTo(4));
            Assert.That(bor.HowManyStartsWithPrefix("12"), Is.EqualTo(3));
            Assert.That(bor.HowManyStartsWithPrefix("123"), Is.EqualTo(2));
            Assert.That(bor.HowManyStartsWithPrefix("12345"), Is.EqualTo(1));
            Assert.That(bor.HowManyStartsWithPrefix("00"), Is.EqualTo(0));
        }

    }
}