using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WkBackOfficeTests.PageObjects
{
    public class HomePageClass : Utilities
    {

        public HomePageClass()
        {
            PageFactory.InitElements(Driver, this);
        }

    }
}