using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Framework
{
    public class Driver : IWebDriver
    {
        private IWebDriver _driver;

        // Chrome , Firefox , IE
        public Driver(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;

                case "IE":
                    _driver = new InternetExplorerDriver();
                    break;

                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
            }
        }

        public Driver(string username, string access_key, Dictionary<string, string> arguments)
        {
            ChromeOptions capability = new ChromeOptions();
            foreach (var key in arguments.Keys){
                capability.AddArguments(key, arguments[key]);
            }
            /* capability.AddArguments("browserName", "iPhone");
            capability.AddArguments("device", "iPhone 8 Plus");
            capability.AddArguments("realMobile", "true");
            capability.AddArguments("os_version", "11"); */
            capability.AddArguments("browserstack.user", username);
            capability.AddArguments("browserstack.key", access_key);

            _driver = new RemoteWebDriver(
                new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
        }

        public IWebElement FindElementOnPage(By by, int ms)
        {
            IWebElement element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 0, 0, ms));
                element = wait.Until(_driver => _driver.FindElement(by));
            }
            catch (Exception e)
            {
                Console.WriteLine("Element not found! " + e.Message);
            }
            return element;
        }

        public ReadOnlyCollection<IWebElement> FindElementsOnPage(By by, int ms)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 0, 0, ms));
                elements = wait.Until(_driver => _driver.FindElements(by));
            }
            catch (Exception e)
            {
                Console.WriteLine("Elements not found! " + e.Message);
            }
            return elements;
        }

        public string Url { get => _driver.Url; set => _driver.Url = value; }

        public string Title => _driver.Title;

        public string PageSource => _driver.PageSource;

        public string CurrentWindowHandle => _driver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public void Close()
        {
            _driver.Close();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return _driver.Manage();
        }

        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }
    }
}
