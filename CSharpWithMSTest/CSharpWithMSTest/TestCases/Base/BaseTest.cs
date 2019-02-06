using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

// assembly for parallel execution in mstest MethodLevel for workers per test, ClassLevel for workers per class
[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        // test context for getting test data / status
        public TestContext TestContext { get; set; }

        // driver that can be initialized during Initialize phase or used in each test case
        public Driver driver;

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

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
