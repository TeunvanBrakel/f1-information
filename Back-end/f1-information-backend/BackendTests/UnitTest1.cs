using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = "test";
            Assert.AreEqual(test, "test");
        }
    }
}
