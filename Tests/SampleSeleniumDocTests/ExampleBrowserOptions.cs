using DemoSeleniumNUnitProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumNUnitProject.Tests.SampleSeleniumDocTests
{
    public class ExampleBrowserOptions
    {
        [Test]
        public void Example_BrowserName()
        {
            ChromeOptions browserOptions = new ChromeOptions();
            String name = browserOptions.BrowserName;

            TestContext.WriteLine(name);
        }
        [Test]
        public void Example_BrowserVersion()
        {
            ChromeOptions browserOptions = new ChromeOptions();
            browserOptions.BrowserVersion = "113.0.5672.63";

            String BVersion = browserOptions.BrowserVersion;
            TestContext.WriteLine(BVersion);

            IWebDriver driver = new ChromeDriver(browserOptions);
            driver.Dispose();
        }
        [Test]
        public void Example_pageLoadStrategyNormal()
        {
            ChromeOptions browserOptions = new ChromeOptions();

            browserOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            
            TestContext.WriteLine(browserOptions.BrowserVersion);

            IWebDriver driver = new ChromeDriver(browserOptions);

            // 1. Initialize and start the stopwatch before the first action
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            driver.Navigate().GoToUrl("https://www.amazon.in/");

            // 2. Stop the stopwatch after the second action is completed
            stopwatch.Stop();

            // 3. Record and output the elapsed time
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            TestContext.WriteLine($"Time taken between navigation and login button click: {elapsedMs} ms");
            TestContext.WriteLine($"Time taken in seconds: {elapsedSeconds} s");

            driver.Dispose();
        }
    }
}
