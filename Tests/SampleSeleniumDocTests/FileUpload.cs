using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumNUnitProject.Tests.SampleSeleniumDocTests
{
    public class FileUpload
    {
        [Test]  // Test steps:
                // 1. Open an app,
                // 2. Click on the "Choose File" button,
                // 3. Select a file from the system,
                // 4. Click on the "Upload" button,
                // 5. Verify that the file is uploaded successfully.
        public void fileUpload()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver driver = new ChromeDriver(options);

            // 1. Open an app,
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");

            // 2. Click on the "Choose File" button,
            // 3. Select a file from the system,
            IWebElement ChooseFileBtn = driver.FindElement(By.XPath("//input[@id='file-upload' and @type='file']"));
            ChooseFileBtn.SendKeys(@"D:\\MyWorkspace\\Taro Videos\\INDEX.txt");       

        }
    }
}
