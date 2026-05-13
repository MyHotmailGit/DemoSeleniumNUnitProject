using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumNUnitProject.Pages
{
    public class WelcomePage
    {
        private IWebDriver _driver;
        private readonly string _expectedUrl = "http://localhost:90/theD-IMS-Demo/Admin/WellcomePage.aspx"; // Example expected URL
        private readonly string _expectedTitle = "Welcom To GBS"; // Example expected title

        // 1. Private Locators (Encapsulation - Tests shouldn't see these)
        private readonly By _welcomeMessage = By.XPath("//div[@id='main']//div/h1[text()=' Welcome Page ! ']"); // Example locator

        // 2. Constructor passing driver to BasePage
        public WelcomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool GetCurrentTitle()
        {
            if(_driver.Title == _expectedTitle)
                return true;
            return false;
        }

        public bool GetCurrentURL()
        {
            if (_driver.Url == _expectedUrl)
                return true;
            return false;
        }

    }
}
