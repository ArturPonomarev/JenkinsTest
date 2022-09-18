using NUnit.Framework;

namespace JenkinsTest
{
    [TestFixture]
    class SimpleTest
    {
        [Test]
        public void TestMethod()
        {
            Assert.IsTrue(3 == 3, "3 is not 3");
        }
    }
}
