using DemoSeleniumNUnitProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumNUnitProject.Pages
{
    public class LoginPage 
    {
        private IWebDriver _driver;
        // 1. Private Locators (Encapsulation - Tests shouldn't see these)
        private readonly By _usernameField = By.Id("txtUserID");
        private readonly By _passwordField = By.Id("txtPassword");
        private readonly By _loginButton = By.Name("btnLogin");
        private readonly By _errorMessage = By.Id("txtUserIDRequiredValidator");

        // 2. Constructor passing driver to BasePage
        public LoginPage(IWebDriver driver)
        { this._driver = driver; }

        // 3. Action Methods (Fluent Interface)
        public LoginPage EnterUsername(string username)
        {
            _driver.FindElement(_usernameField).Clear();
            _driver.FindElement(_usernameField).SendKeys(username);
            return this; // Allows chaining
        }

        public LoginPage EnterPassword(string password)
        {
            _driver.FindElement(_passwordField).Clear();
            _driver.FindElement(_passwordField).SendKeys(password);
            return this; // Allows chaining
        }

        /// <summary>
        /// Performs login and transitions to the WelcomePage
        /// </summary>
        
        public WelcomePage ClickLogin()
        {
            _driver.FindElement(_loginButton).Click();
            return new WelcomePage(_driver);
        }

        // 4. Helper Method for common "Happy Path"
        public WelcomePage Login(string username, string password)
        {
            return EnterUsername(username)
                  .EnterPassword(password)
                  .ClickLogin();
        }
        

        public string GetErrorMessage()
        {
            return _driver.FindElement(_errorMessage).Text;
        }
    }
}
