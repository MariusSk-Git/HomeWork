using AutoTestLeson1.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Test
{
    class HomwWork3UsinPageObjectTest
    {
        private static IWebDriver _driver;
        private static HomwWork3UsinPageObjectPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            _driver.Manage().Window.Maximize();
            _page = new HomwWork3UsinPageObjectPage(_driver);
        }

        [Test]
        public void TestSeleniumCheckBox()
        {
            _page.ClickCheckBox();
            _page.CheckBoxResult("Success - Check box is checked");
            _page.UnclickCheckBox();
        }

        [Test]
        [Obsolete]
        public void TestSeleniumMultiCheckBox()
        {
            _page.ClickMultiCheckBox();
            _page.MultiCheckButtonName("Uncheck All");
        }

        [Test]
        public void TestUnchekedMultiCheckBox()
        {
            _page.ClickMultiCheckBox();
            _page.ClickUnchekAll();
            _page.AssertMultiCheckBoxUncheked();
        }


        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
    }
}
