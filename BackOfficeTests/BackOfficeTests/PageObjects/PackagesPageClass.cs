using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WkBackOfficeTests.PageObjects
{
    public class PackagesPageClass : Utilities
    {

        public PackagesPageClass()
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}