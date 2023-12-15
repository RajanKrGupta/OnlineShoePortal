using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineShoePortal.PageObjects
{
    class HomePage
    {

        public void Click_SignInPortal()
        {
            driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            //Thread.Sleep(1000);
            // click on signin button
            driver.FindElement(By.LinkText("Sign In Portal")).Click();

        }
    }
}
