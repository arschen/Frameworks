using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

// assembly for parallel execution in mstest
[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace Tests
{
    [TestClass]
    public class Tests : BaseTest
    {

        // used for DynamicData for DataTestMethod
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] {  "Chrome" };
            yield return new object[] { "Firefox" };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void TestMethod1(string browserName)
        {
            driver = Driver.GetDriver(browserName);
            driver.Url = "https://google.com";
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void TestMethod2(string value)
        {
            driver = Driver.GetDriver(value);
            driver.Url = "https://facebook.com";
        }

        [DataTestMethod]
        [DataRow("Chrome")]
        [DataRow("Firefox")]
        public void TestMethod3(string value)
        {
            driver = Driver.GetDriver(value);
            driver.Url = "https://stackoverflow.com";
        }

        [DataTestMethod]
        [DataRow("Chrome")]
        [DataRow("Firefox")]
        public void TestMethod4(string value)
        {
            driver = Driver.GetDriver(value);
            driver.Url = "https://github.com";
        }
    }
}
