using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace OnlineShoePortal
{
    [TestClass]
    public class TS01_UserRegistration
    {
       
        public static IWebDriver driver { get; set; }
        [TestMethod]
        public void TC01_UserReg_ErrorValidation()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
  
            var userlength = driver.FindElements(By.Id("usr")).Count;
            Assert.AreEqual(1, userlength);

            var passlength = driver.FindElements(By.Id("pwd")).Count;
            Assert.AreEqual(1, passlength);


            //Click on new user Registration
            driver.FindElement(By.XPath("//button[@id='NewRegistration']")).Click();
            SelectElement drpSalutation = new SelectElement(driver.FindElement(By.Id("Salutation")));
            drpSalutation.SelectByText(ConfigurationManager.AppSettings["Salutation"]);

            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();

            var errormsg = driver.FindElement(By.XPath("//span[@class='error']")).Text;
            Assert.AreEqual("This field is required", errormsg);

            driver.FindElement(By.Id("firstname")).SendKeys(ConfigurationManager.AppSettings["FirstName"]);
            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();


            var errormsg1 = driver.FindElement(By.XPath("//span[@class='error']")).Text;
            Assert.AreEqual("This field is required", errormsg1);

            driver.FindElement(By.Id("lastname")).SendKeys(ConfigurationManager.AppSettings["LastName"]);
            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();

            // Invalid Email ID 
            driver.FindElement(By.Id("emailId")).SendKeys(ConfigurationManager.AppSettings["InvalidEmailAddress"]);
            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();
            var invalidemail = driver.FindElement(By.XPath("//span[@class='error']")).Text;
            Assert.AreEqual("Enter a valid email", invalidemail);

            // Valid Email ID 
            driver.FindElement(By.Id("emailId")).SendKeys(ConfigurationManager.AppSettings["ValidEmailAddress"]);
            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();

            Assert.AreEqual("This field is required", errormsg);

            driver.FindElement(By.Id("usr")).SendKeys(ConfigurationManager.AppSettings["Username"]);
            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();

            Assert.AreEqual("This field is required", errormsg);

            driver.FindElement(By.Id("pwd")).SendKeys(ConfigurationManager.AppSettings["Password"]);
            driver.FindElement(By.XPath("//input[@value='Submit']")).Click();


        }
    }
}
