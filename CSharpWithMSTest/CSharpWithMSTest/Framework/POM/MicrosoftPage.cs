using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

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
        public void OpenOfficeLink()
        {
            _officeLink.Click();
        }

        public void OpenWindowsLink() 
        {
            _windowsLink.Click();
        }

        public bool OfficeIsOpened()
        {
            var element = _driver.FindElementOnPage(By.Id("pmg-hv2-content"), 5000);
            return (element != null);
        }

        public bool WindowsIsOpened()
        {
            var element = _driver.FindElementOnPage(By.Id("home-hero-banner-1"), 5000);
            return (element != null);
        }

        public bool HasLanded()
        {
            return (_validatorElement != null);
        }
    }
}
