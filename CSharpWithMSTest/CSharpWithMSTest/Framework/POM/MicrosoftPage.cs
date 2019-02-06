using OpenQA.Selenium;

namespace Framework
{
    public class MicrosoftPage : BasePage
    {
        // constructor invoking base constructor and setting up the name
        public MicrosoftPage(Driver driver) : base (driver)
        {
            URL = "https://www.microsoft.com/bg-bg/";
        }

        // elements
        private IWebElement _officeLink => _driver.FindElement(By.Id("shellmenu_0"));
        private IWebElement _windowsLink => _driver.FindElement(By.Id("shellmenu_1"));
        private IWebElement _validatorElement => _driver.FindElement(By.Id("coreui-hero-q4ifivk-item-1"));

        // methods
        public OfficeProductsPage OpenOfficeLink()
        {
            _officeLink.Click();
            return new OfficeProductsPage(_driver);
        }

        public WindowsPage OpenWindowsLink() 
        {
            _windowsLink.Click();
            return new WindowsPage(_driver);
        }

        public bool HasLanded()
        {
            return (_validatorElement != null);
        }
    }
}
