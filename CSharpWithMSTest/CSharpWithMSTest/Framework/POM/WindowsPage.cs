using OpenQA.Selenium;

namespace Framework
{
    public class WindowsPage : BasePage
    {
        // constructor invoking base constructor and setting up the name
        public WindowsPage(Driver driver) : base (driver)
        {
            URL = "https://www.microsoft.com/bg-bg/windows";
        }

        // elements
        private IWebElement _validatorElement => _driver.FindElement(By.Id("home-hero-banner-1"));

        // methods
        public bool HasLanded()
        {
            return (_validatorElement != null);
        }
    }
}
