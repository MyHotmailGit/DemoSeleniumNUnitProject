using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;
using Microsoft.Testing.Platform.Configurations;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using DemoSeleniumNUnitProject.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.Helpers;

namespace InterPrep_NUnitFramework.Driver
{
    public class DriverFactory
    {
        public void CreateDriver()
        {
            string BrowserName = ConfigurationManager.AppSettings["BrowserName"];
            string AppURL = ConfigurationManager.AppSettings["AppURL"];

            IWebDriver Driver = null;           

            switch (BrowserName)
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
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

                    var options = new ChromeOptions();

                    if (ConfigReader.Headless)
                        options.AddArgument("--headless=new");

                    options.AddArgument("--start-maximized");

                    Driver = new ChromeDriver(options);
                    Driver.Manage().Timeouts().ImplicitWait =
                        TimeSpan.FromSeconds(ConfigReader.ImplicitWait);
                    break;
                default:
                    throw new NotSupportedException($"Browser '{BrowserName}' is not supported.");
            }

            Driver.Navigate().GoToUrl(AppURL);
        }
    }
}
