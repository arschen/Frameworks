using OpenQA.Selenium;

namespace CSharpWithMSTest
{
    public class BasePage
    {
        // driver
        private readonly IWebDriver _driver;

        // url
        private readonly string _url = @"page_URL";

        // elements
        public IWebElement SearchBox => _driver.FindElement(By.Id("element_id"));

        // constructor that accepts already initialized driver
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // methods
        public void Navigate() => _driver.Navigate().GoToUrl(_url);
    }
}
