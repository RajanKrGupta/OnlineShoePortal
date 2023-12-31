﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OnlineShoePortal.PageObjects;

namespace OnlineShoePortal
{
    [TestClass]
    public class TS01_UserRegistration
    {
       
         [TestMethod]
        public void TC01_UserReg_ErrorValidation()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            PropertiesCollections.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            PropertiesCollections.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);

            HomePage.click_SignInPortal();

            Assert.AreEqual(1, SignInPage.txtuserlength);            
            Assert.AreEqual(1, SignInPage.txtpwdlength);
            Assert.AreEqual(1, SignInPage.btnLogin);
            Assert.AreEqual(1, SignInPage.btnRegistration);

            SignInPage.clickNewRegistration();


            RegistrationPage.select_Salutation();
            RegistrationPage.click_Submit();
            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_FirstName();
            RegistrationPage.click_Submit();
            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);


            RegistrationPage.enter_LastName();
            RegistrationPage.click_Submit();
            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            // Invalid Email ID 
            RegistrationPage.enter_InvalidEmail();
            RegistrationPage.click_Submit();
            Assert.AreEqual("Enter a valid email", RegistrationPage.txtErrorMsg);

            // Valid Email ID 
            RegistrationPage.enter_ValidEmail();
            RegistrationPage.click_Submit();
            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_UsrName();
            RegistrationPage.click_Submit();
            Assert.AreEqual("This field is required", RegistrationPage.txtErrorMsg);

            RegistrationPage.enter_Password();
            RegistrationPage.click_Submit();

            PropertiesCollections.driver.Close();
            PropertiesCollections.driver.Quit();



        }
    }
}
