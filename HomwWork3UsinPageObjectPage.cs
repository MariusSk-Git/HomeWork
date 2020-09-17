using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestLeson1.Page
{
    class HomwWork3UsinPageObjectPage
    {
        private static IWebDriver _driver;
        private IWebElement _checkBox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _checkBoxResult => _driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> _multiCheckBoxes => _driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement _multiCheckBoxResult => _driver.FindElement(By.Id("check1"));

        public HomwWork3UsinPageObjectPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void ClickCheckBox() 
        {
            if (!_checkBox.Selected)
            {
                _checkBox.Click();
            }
            
        }
        public void UnclickCheckBox()
        {
            if (_checkBox.Selected)
            {
                _checkBox.Click();
            }
        }

        public void CheckBoxResult(string result)
        {
            Assert.AreEqual(result, _checkBoxResult.Text, "Nesutampa Check Box Pranesimas");
        }

        public void ClickMultiCheckBox()
        {
            foreach (IWebElement singleCheckBox in _multiCheckBoxes)
            {
                if (!singleCheckBox.Selected)
                {
                    singleCheckBox.Click();
                }
            }
        }

        [Obsolete]
        public void MultiCheckButtonName(string multiButtonText)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(_multiCheckBoxResult, multiButtonText));
            Assert.AreEqual(multiButtonText, _multiCheckBoxResult.GetAttribute("value"), "MultiBox mygtuko textas nesutampa");
        }

        public void ClickUnchekAll()
        {
            _multiCheckBoxResult.Click();
        }
        
        public void AssertMultiCheckBoxUncheked()
        {
            foreach (IWebElement singleCheckBox in _multiCheckBoxes)
            {
                Assert.False(singleCheckBox.Selected, "Vis dar yra pazymetu verneliu");
            }
        }
    }
}
