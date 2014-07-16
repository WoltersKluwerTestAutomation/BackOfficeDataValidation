using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace WkBackOfficeTests.PageObjects
{
    public class SubscriptionsPageClass : Utilities
    {

        public SubscriptionsPageClass()
        {
            PageFactory.InitElements(Driver, this);
        }




        [FindsBy(How = How.XPath, Using = "//*[@id='navbar-collapse-1']/ul[1]/li[2]/a")]
        public IWebElement SubscriptionItems { set; get; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        public IWebElement ApplyFilters { set; get; }

        [FindsBy(How = How.CssSelector, Using = ".row.expanded .col-md-4 .row")]
        public IList<IWebElement> allElementsOnSubscriptions { set; get; }

        [FindsBy(How = How.Id, Using = "subs_no")]
        public IWebElement Subsno { get; set; }




        public void ApplyFiltersOnSubscriptions(string subsno)
        {

            SubscriptionItems.Click();
            WaitForPageToLoad();
            Subsno.Clear();
            Subsno.SendKeys(subsno);
            ApplyFilters.Click();

            Thread.Sleep(2000);
        }


        public string GetValuofTheSubscriptions(string field1)
        {

            var allSubFields = new List<IWebElement>();
            allSubFields.AddRange(allElementsOnSubscriptions);

            var requiredFields = allSubFields.First(ee => ee.FindElement(By.CssSelector(".heading")).Text.Contains(field1));
            return requiredFields.FindElement(By.CssSelector(".col-md-7")).Text;


        }



    }
}