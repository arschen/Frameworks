using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace Framework
{
    public static class Driver
    {
        private static IWebDriver _driver;

        // Chrome , Firefox , IE
        public static IWebDriver GetDriver(string browserName)
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

            return _driver;
        }

        public static IWebDriver GetBrowserstackDriver(string username, string access_key, Dictionary<string, string> arguments)
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

            return _driver;
        }
    }
}
