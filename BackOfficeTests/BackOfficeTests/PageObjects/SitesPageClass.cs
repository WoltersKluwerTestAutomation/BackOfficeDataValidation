using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WkBackOfficeTests.PageObjects
{
    public class SitesPageClass : Utilities
    {

        public SitesPageClass()
        {
            PageFactory.InitElements(Driver, this);

        }
    }
}