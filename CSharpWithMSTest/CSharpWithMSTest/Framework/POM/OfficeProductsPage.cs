using OpenQA.Selenium;

namespace Framework
{
    public class OfficeProductsPage : BasePage
    {
        // constructor invoking base constructor and setting up the name
        public OfficeProductsPage(Driver driver) : base (driver)
        {
            URL = "https://products.office.com/bg-bg";
        }

        // elements
        private IWebElement _validatorElement => _driver.FindElement(By.Id("pmg-hv2-content"));

        // methods
        public bool HasLanded()
        {
            return (_validatorElement != null);
        }
    }
}
