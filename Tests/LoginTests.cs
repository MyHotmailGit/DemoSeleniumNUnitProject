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
    public class LoginTests //: BaseTest
    {
        [Test]
        public void InterviewPrep()
        {
            bool result = StringAnagram("hello", "lehol");
            TestContext.WriteLine("The provided strings are Anagram: " + result);
        }

        public Boolean StringAnagram(String str1, String str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            else
            {
                char[] charArray1 = str1.ToCharArray();
                char[] charArray2 = str2.ToCharArray();
               var Counter = new Dictionary<char, int>();
                int i = 0;
                foreach (char c in charArray1)
                {
                    if (Counter.ContainsKey(c))
                        Counter[c]++;
                    else
                    {
                        Counter[c] = 1;
                        
                    }
                }

                foreach (char c in charArray2)
                {
                    if (!Counter.ContainsKey(c))
                    {
                        return false;
                    }

                    Counter[c]--;

                    if (Counter[c] > 0)
                        return false;
                }
                return true;
            }
        }

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
