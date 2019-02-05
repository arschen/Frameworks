using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        public TestContext TestContext { get; set; }
        public IWebDriver driver;

        [TestInitialize]
        public void Init()
        {
            /*
            var dict = new Dictionary<string, string>
            {
                { "browserName", "iPhone" },
                { "device", "iPhone 8 Plus" },
                { "realMobile", "true" },
                { "os_version", "11" }
            };
            driver = Driver.GetBrowserstackDriver("Plamen", "Daskalov", dict);
            */
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
