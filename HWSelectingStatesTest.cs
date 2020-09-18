using AutoTestLeson1.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Test
{
    class HWSelectingStatesTest
    {
        private static HWSelectingStatesPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _page = new HWSelectingStatesPage(driver);
        }

        [TestCase("California", "Ohio", "Pennsylvania", TestName = "Selecting 3 states with First Button")]
        public void Test3StateSelect(string state, string state2, string state3) // kodel selectina nuo paskutinio?
        {
            _page.SelectFromMultiStatesByText(state);
            _page.SelectFromMultiStatesByTextWithCtrl(state2);
            _page.SelectFromMultiStatesByTextWithCtrl(state3);
            _page.ClickFirstSelectedButton();

            _page.MultiSelectResultByValue(state3);
            _page.UnselectStates();

        }

        [TestCase("Florida", "Texas", "Pennsylvania", "California", TestName = "Selecting 4 states with GetAll Button")]
        public void Test4StateSelect(string state1, string state2, string state3, string state4)
        {
            _page.SelectFromMultiStatesByText(state1);

            _page.SelectFromMultiStatesByTextWithCtrl(state2);
            _page.SelectFromMultiStatesByTextWithCtrl(state3);
            _page.SelectFromMultiStatesByTextWithCtrl(state4);

            _page.ClickGetAllSelectedButton();
            _page.MultiSelectResultByValue(state1, state2, state3, state4);

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

    }
}
