using OpenQA.Selenium;

namespace Framework
{
    public class AutomationPracticePage : BasePage
    {
        // constructor invoking base constructor and setting up the name
        public AutomationPracticePage(Driver driver) : base (driver)
        {
            URL = "https://www.toolsqa.com/automation-practice-form/";
        }

        // elements
        private IWebElement _firstName => _driver.FindElement(By.Name("firstname"));
        private IWebElement _lastName => _driver.FindElement(By.Name("lastname"));

        // methods
        public void EnterFirstName(string firstName)
        {
            _firstName.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _lastName.SendKeys(lastName);
        }
    }
}
