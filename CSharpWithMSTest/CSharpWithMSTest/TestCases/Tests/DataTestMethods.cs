using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

// assembly for parallel execution in mstest
[assembly: Parallelize(Workers = 1, Scope = ExecutionScope.MethodLevel)]
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

        // test with dynamic data taken from GetData()
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void DynamicDataTestMethod(string browserName)
        {
            driver = Driver.GetDriver(browserName);
            AutomationPracticePage automationPracticePage = new AutomationPracticePage(driver);
            automationPracticePage.Navigate();
            automationPracticePage.EnterFirstName("Plamen");
            automationPracticePage.EnterLastName("Daskalov");
        }

        // second test with data rows instead of dynamic data
        [DataTestMethod]
        [DataRow("Chrome")]
        [DataRow("Firefox")]
        public void DataRowTestMethod(string value)
        {
            driver = Driver.GetDriver(value);
            driver.Url = "https://stackoverflow.com";
        }
    }
}
