using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class DataTestsMethods : BaseTest
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
            driver = new Driver(browserName);
            AutomationPracticePage automationPracticePage = new AutomationPracticePage(driver);
            automationPracticePage.Navigate();
            automationPracticePage.EnterFirstName("Plamen");
            automationPracticePage.EnterLastName("Daskalov");
        }

        // second test with data rows instead of dynamic data
        [DataTestMethod]
        [DataRow("Chrome")]
        [DataRow("Firefox")]
        public void DataRowTestMethod(string browserName)
        {
            driver = new Driver(browserName)
            {
                Url = "https://stackoverflow.com"
            };
        }

        [TestMethod]
        public void MicrosoftPage()
        {
            driver = new Driver("Chrome");
            driver.Manage().Window.Maximize();

            MicrosoftPage microsoftPage = new MicrosoftPage(driver);
            microsoftPage.Navigate();
            Assert.IsTrue(microsoftPage.HasLanded());

            OfficeProductsPage officeProductsPage= microsoftPage.OpenOfficeLink();
            Assert.IsTrue(officeProductsPage.HasLanded());

            microsoftPage.Navigate();
            Assert.IsTrue(microsoftPage.HasLanded());

            WindowsPage windowsPage = microsoftPage.OpenWindowsLink();
            Assert.IsTrue(windowsPage.HasLanded());
        }
    }
}
