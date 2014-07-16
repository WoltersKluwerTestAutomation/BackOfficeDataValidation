using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WkBackOfficeTests.PageObjects
{
    public class WkLoginPageClass : Utilities
    {

        public WkLoginPageClass()
        {
            PageFactory.InitElements(Driver, this);
        }

        //**********************Elements*******************************************//
        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div/form/div[1]/input")]
        public IWebElement LoginEmail { set; get; }

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div/form/div[2]/input")]
        public IWebElement LoginPassword { set; get; }

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div/form/div[3]/input")]
        public IWebElement LoginButton { set; get; }

        [FindsBy(How = How.XPath, Using = "//*[@id='navbar-collapse-1']/ul[1]/li[1]/a")]
        public IWebElement UsersButton { set; get; }


        public void Login(string username, string password)
        {
            LoginEmail.SendKeys(username);
            LoginPassword.SendKeys(password);
            LoginButton.Click();
            WaitForPageToLoad();
            UsersButton.Click();
        }
    }
}