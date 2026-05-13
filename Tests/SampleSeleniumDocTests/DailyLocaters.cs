using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoSeleniumNUnitProject.Tests.SampleSeleniumDocTests
{
    public class DailyLocaters
    {
        public IWebDriver driver = new ChromeDriver();

        private AventStack.ExtentReports.ExtentReports extent; // Fixed the issue by fully qualifying the type name
        AventStack.ExtentReports.ExtentTest test;

        [OneTimeSetUp]
        public void setup()
        {
            string WorkingDir = Environment.CurrentDirectory;
            string ProjectDir = Directory.GetParent(WorkingDir).Parent.Parent.FullName;
            String ReportPath = ProjectDir + "\\index.html";
            var htmlReporter = new ExtentHtmlReporter(ReportPath);
            extent = new AventStack.ExtentReports.ExtentReports(); // Fully qualified name used here as well
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("QA Name", "Pankaj");
            extent.AddSystemInfo("Env","Test");
        }

        [SetUp]
        public void BeforeTest()
        {
           test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void DailyLocaters_Example()
        {   
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://thed.odoo.com/odoo");

            //LoginPage loginPage = new LoginPage(driver);
        IWebElement LoginID = driver.FindElement(By.CssSelector("input#login"));
        IWebElement Password = driver.FindElement(By.CssSelector("input#password"));
        IWebElement SubmitBtn = driver.FindElement(By.XPath("//button[text()='Log in']"));
        

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        wait.Until(d => LoginID.Displayed);

            // Login Application  
            LoginID.SendKeys("thedinfotechuser@gmail.com");
            Password.SendKeys("MyOdoo!theD2026");
            SubmitBtn.Click();
            TestContext.WriteLine("These are the daily locators used in Selenium WebDriver.");
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)
        {
             ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenShort = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShort, screenShotName).Build();
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_"+ test + time.ToString("h-mm-ss") + ".png";

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            { 
                test.Fail("Test Failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "Test failed with log." + stackTrace);
            }            
           extent.Flush();            
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            //driver.Dispose();
            //driver.Quit();
        }
    }
}
