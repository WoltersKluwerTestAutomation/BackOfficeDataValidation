using System;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WkBackOfficeTests.Tests;
using WkBackOfficeTests.Support;
using System.Linq;
using log4net;
using System.IO;

namespace WkBackOfficeTests.Tests
{
    public class WkTests : WkBackOfficeTests.Test.Utilities
    {


        [SetUp]
        public void OpenBrowser()
        {
            InitializeDriver();

        }


        // Verifying the data imports on Back Office 
        [Test]
        public void CsvTest()
        {
            WkLoginPage.Login("testautomation@mailinator.com", "Test1234");
            WaitForPageToLoad();

            var allCustomerRows = CsvReaderClass.ReadCustomerCsv("C:\\Users\\Madhu.Shashank\\Desktop\\CSV\\Customers\\Cust.csv");
            var allSubscriptionRows = CsvReaderClass.ReadSubscriptionCsv("C:\\Users\\Madhu.Shashank\\Desktop\\CSV\\Subscriptions\\Sub.csv");

            foreach (var customerRow in allCustomerRows)
            {

                if (customerRow.CR_BP_TYPE != "EOF")
                {
                    try
                    {

                        UsersPage.ApplySelectedFilters(customerRow.EMAIL);
                        AreEqual(UsersPage.GetValueOfTheField("First name"), customerRow.FIRSTNAME);
                        AreEqual(UsersPage.GetValueOfTheField("Last name"), customerRow.LASTNAME);
                        AreEqual(UsersPage.GetValueOfTheField("Email"), customerRow.EMAIL);
                        AreEqual(UsersPage.GetValueOfTheField("Title"), customerRow.CR_TITLE);
                        AreEqual(UsersPage.GetValueOfTheField("Job title"), customerRow.JOB_TITLE);
                        AreEqual(UsersPage.GetValueOfTheField("Company"), customerRow.COMPANY_NAME);
                        True(UsersPage.GetValueOfTheField("Address").Contains(customerRow.AD_CARE_OF));
                        True(UsersPage.GetValueOfTheField("Address").Contains(customerRow.ADDRESS));
                        True(UsersPage.GetValueOfTheField("Address").Contains(customerRow.ADDRESS_2));
                        True(UsersPage.GetValueOfTheField("Address").Contains(customerRow.ADDRESS_3));
                        True(UsersPage.GetValueOfTheField("Address").Contains(customerRow.CITY));
                        True(UsersPage.GetValueOfTheField("Address").Contains(customerRow.ZIP));


                        var subscriptionRows = allSubscriptionRows.Where(ee => ee.CR_SHIPTO_ID == customerRow.CR_SHIPTO_ID).ToList();

                        foreach (var subscriptionRow in subscriptionRows)
                        {
                            SubscriptionsPage.ApplyFiltersOnSubscriptions(subscriptionRow.SUBS_NO, subscriptionRow.ITEM_NUMBER);
                            True(subscriptionRow.CR_SHIPTO_ID.Contains(SubscriptionsPage.GetValuofTheSubscriptions("CR Ship to ID")));
                            True(subscriptionRow.CR_PAYER_ID.Contains(SubscriptionsPage.GetValuofTheSubscriptions("CR Payer ID")));
                            True(subscriptionRow.CR_BILLTO_ID.Contains(SubscriptionsPage.GetValuofTheSubscriptions("CR Bill to ID")));
                            True(subscriptionRow.CR_SOLDTO_ID.Contains(SubscriptionsPage.GetValuofTheSubscriptions("CR Sold to ID")));
                            True(subscriptionRow.SUBS_NO.Contains(SubscriptionsPage.GetValuofTheSubscriptions("Subs number")));
                            True(subscriptionRow.ITEM_NUMBER.Contains(SubscriptionsPage.GetValuofTheSubscriptions("Item number")));
                            True(subscriptionRow.USER_COUNT.Contains(SubscriptionsPage.GetValuofTheSubscriptions("User count")));
                            True(subscriptionRow.CR_MEDIA_TYPE.Contains(SubscriptionsPage.GetValuofTheSubscriptions("CR Media type")));
                           // AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("Start date").Replace(" ", "-"), subscriptionRow.SUB_CRE_DATE);
                           // AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("End date").Replace(" ", "-"), subscriptionRow.END_DATE);
                           // AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("Invoice date").Replace(" ", "-"), subscriptionRow.INV_DATE);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("Package code"), subscriptionRow.PACKAGE_CODE);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("CR BOM code"), subscriptionRow.CR_BOM_CODE);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("CR BOM title"), subscriptionRow.CR_BOM_TITLE);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("Previous subs"), subscriptionRow.PREVIOUS_SUBS);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("Billing block"), subscriptionRow.BILLING_BLOCK);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("HDR delivery block"), subscriptionRow.HDR_DELIVERY_BLOCK);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("CR contract type"), subscriptionRow.CR_CONTRACT_TYPE);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("Rejection"), subscriptionRow.REJECTION);
                            AreEqual(SubscriptionsPage.GetValuofTheSubscriptions("Cancellation"), subscriptionRow.CANCELLATION);
                        }

                    }
                    catch (AssertionException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                    UsersPage.ClickOnUsers();

                }


            }

        }

        

        [TearDown]
        public void close()
        {
            DisposeDriver();
        }
    }
}