using DemoSeleniumNUnitProject.Pages;
using DemoSeleniumNUnitProject.Utilities;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumNUnitProject.Tests
{
    public class LoginTests: BaseTest
    {
        [Test]       
        public void Valid_Login_Should_Succeed()
        {           
            var loginPage = new LoginPage(_Driver);
           WelcomePage wp = loginPage.EnterUsername("#99")
                     .EnterPassword("99")
                     .ClickLogin();

            ClassicAssert.IsTrue(wp.GetCurrentURL());
            ClassicAssert.IsTrue(wp.GetCurrentTitle());  
        }
        
    }
}
