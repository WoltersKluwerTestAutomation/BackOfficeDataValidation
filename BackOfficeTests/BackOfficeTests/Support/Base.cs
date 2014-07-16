using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using log4net;
using System.IO;



namespace WkBackOfficeTests.Support
{


    [TestFixture]
    public class Base
    {

        public static IWebDriver Driver = null;



        // Initialize the Selenium Driver
        public void InitializeDriver()
        {

            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://wkbackoffice.fullfatthings.com/admin/login");
            WaitForPageToLoad();
        }

        public void DisposeDriver()
        {
            Driver.Close();
            Driver.Quit();
        }


        public void WaitForPageToLoad()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString().Equals("complete"));

        }

    }

}