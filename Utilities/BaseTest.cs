using DemoSeleniumNUnitProject.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumNUnitProject.Utilities
{
    public class BaseTest
    {
        protected IWebDriver _Driver;

        [SetUp]
        public void SetUp()
        {
            DriverFactory Driver = new DriverFactory();
            _Driver = Driver.CreateDriver();            
        }

        [TearDown]
        public void TearDown()
        {
            _Driver.Dispose();
        }
    }
}
