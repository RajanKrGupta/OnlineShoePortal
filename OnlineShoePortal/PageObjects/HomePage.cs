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
        private static IWebElement menu_input => PropertiesCollections.driver.FindElement(By.XPath("//input[@type='checkbox']"));
        private static IWebElement lnkSign => PropertiesCollections.driver.FindElement(By.LinkText("Sign In Portal"));
        public static void click_SignInPortal()
        {
            menu_input.Click();
            PropertiesCollections.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1); //Thread.Sleep(1000);
            // click on signin button
            lnkSign.Click();

        }
    }
}
