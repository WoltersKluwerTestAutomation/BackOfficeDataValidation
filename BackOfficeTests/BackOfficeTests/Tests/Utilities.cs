using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WkBackOfficeTests.Support;

namespace WkBackOfficeTests.Test
{
    public class Utilities : Pages
    {

        public void True(bool condition, string errorText = null)
        {
            Assert.IsTrue(condition, errorText);
        }
        public void False(bool condition, string errorText = null)
        {
            Assert.IsFalse(condition, errorText);
        }
        public void AreEqual(object expected, object actual, string errorText = null)
        {
            Assert.AreEqual(expected, actual, errorText);
        }
        public void AreNotEqual(object expected, object actual, string errorText = null)
        {
            Assert.AreNotEqual(expected, actual, errorText);
        }





    }



}