using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WkBackOfficeTests.PageObjects
{
    public class UsersPageClass : Utilities
    {
        public UsersPageClass()
        {

            PageFactory.InitElements(Driver, this);
        }


        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email { set; get; }

        [FindsBy(How = How.XPath, Using = "//*[@id='navbar-collapse-1']/ul[1]/li[1]/a")]
        public IWebElement UsersLink { set; get; }


        [FindsBy(How = How.CssSelector, Using = ".row .btn.btn-primary")]
        public IWebElement ApplyFilters { set; get; }

        [FindsBy(How = How.CssSelector, Using = ".row.expanded .col-md-3 .row")]
        public IList<IWebElement> LeftElementsOnResults { set; get; }

        [FindsBy(How = How.CssSelector, Using = ".row.expanded .col-md-4 .row")]
        public IList<IWebElement> RightElementsOnResults { set; get; }


        public string GetValueOfTheField(string field)
        {
            var allFields = new List<IWebElement>();
            allFields.AddRange(LeftElementsOnResults);
            allFields.AddRange(RightElementsOnResults);

            var requiredField = allFields.First(ee => ee.FindElement(By.CssSelector(".heading")).Text.Contains(field));

            return requiredField.FindElement(By.CssSelector(".col-md-8")).Text;

        }


        public void ApplySelectedFilters(string email)
        {
            Email.Clear();
            Email.SendKeys(email);
            ApplyFilters.Click();
            Thread.Sleep(2000);

        }


        public void ClickOnUsers()
        {

            UsersLink.Click();

        }



    }
}