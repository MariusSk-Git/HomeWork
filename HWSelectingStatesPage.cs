using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Page
{
    class HWSelectingStatesPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private SelectElement _multiStateList => new SelectElement(driver.FindElement(By.Id("multi-select")));
        private IReadOnlyCollection<IWebElement> _multiStates => driver.FindElements(By.Id("multi-select"));
        private IWebElement _multiSelectResult => driver.FindElement(By.ClassName("getall-selected"));
        private IWebElement _firstSelectedButton => driver.FindElement(By.Id("printMe"));
        private IWebElement _getAllSelectedButton => driver.FindElement(By.Id("printAll"));

        public HWSelectingStatesPage(IWebDriver webdriver) : base(webdriver)
        {
            driver.Url = PageAddress;
        }

        public void SelectFromMultiStatesByText(string text)
        {
            _multiStateList.SelectByText(text);
        }

        public void SelectFromMultiStatesByTextWithCtrl(string text)
        {
            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            _multiStateList.SelectByText(text);
            builder.Click();
            builder.KeyUp(Keys.Control);
        }

        public void ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
        }

        public void ClickGetAllSelectedButton()
        {
            _getAllSelectedButton.Click();
        }

        public void UnselectStates()
        {
            foreach (IWebElement state in _multiStates)
            {
                if (state.Selected)
                {
                    state.Click();
                }
            }
        }

        public void MultiSelectResultByValue(string state)
        {
            string fullText = "First selected option is : " + state;
            Assert.AreEqual(fullText, _multiSelectResult.Text, $"Tekstas nesutampa, nerodo {state}");
        }

        public void MultiSelectResultByValue(string state1, string state2, string state3, string state4)
        {
            string fullText = "Options selected are : " + state1 + "," + state2 + "," + state3 + "," + state4;
            Assert.AreEqual(fullText, _multiSelectResult.Text, "Tekstas nesutampa");
        }

    }
}
