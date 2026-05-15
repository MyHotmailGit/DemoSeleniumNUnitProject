using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using DemoSeleniumNUnitProject.Utilities;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Firefox;

namespace DemoSeleniumNUnitProject.Driver
{
    public  class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
            string BrowserN = "Chrome"; //ConfigurationManager.AppSettings["BrowserName"];
            string AppURL = "http://localhost:90/theD-IMS-Demo/Login.aspx"; //ConfigurationManager.AppSettings["AppURL"];

            IWebDriver Driver = null;

            switch (BrowserN)
            {
                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    var firefoxoptions = new FirefoxOptions();

                    if (ConfigReader.Headless)
                        firefoxoptions.AddArgument("--headless=new");

                    firefoxoptions.AddArgument("--start-maximized");

                    Driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

                    var options = new ChromeOptions();

                    if (ConfigReader.Headless)
                        options.AddArgument("--headless=new");

                    options.AddArgument("--start-maximized");

                    // options.ImplicitWaitTimeout = TimeSpan.FromSeconds(5);
                    //options.PageLoadTimeout = TimeSpan.FromSeconds(5);
                    //options.ScriptTimeout = TimeSpan.FromSeconds(5);

                     Driver = new ChromeDriver(options);
                    Driver.Manage().Timeouts().ImplicitWait =
                        TimeSpan.FromSeconds(ConfigReader.ImplicitWait);
                    break;
                default:
                    throw new NotSupportedException($"Browser '{BrowserN}' is not supported.");
            }

            Driver.Navigate().GoToUrl(AppURL);

            return Driver;
        }
    }
}
