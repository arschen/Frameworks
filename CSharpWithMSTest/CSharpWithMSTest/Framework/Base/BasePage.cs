using OpenQA.Selenium;

namespace Framework
{
    public class BasePage
    {
        // driver
        public readonly IWebDriver _driver;

        // url
        public string URL = @"page_URL";

        // constructor that accepts already initialized driver
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // methods
        public void Navigate() => _driver.Navigate().GoToUrl(URL);

        public string GetTitle() { return _driver.Title; }
    }
}
