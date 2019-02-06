using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestMethods : BaseTest
    {
        [TestMethod]
        public void TestMethod()
        {
            driver = new Driver("Chrome")
            {
                Url = "https://google.com"
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver = new Driver("Chrome")
            {
                Url = "https://abv.bg"
            };
        }
    }
}
