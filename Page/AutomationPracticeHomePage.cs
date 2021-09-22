using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationProject.Page
{
    class AutomationPracticeHomePage : BasePage
    {
        private const string AddressUrl = "https://demo.prestashop.com/#/en/front";
        private IWebElement searchWindowInput => Driver.FindElement(By.CssSelector("#search_widget > form > input.ui-autocomplete-input"));
        private IWebElement submitButton => Driver.FindElement(By.CssSelector("#search_widget > form > button > i"));

        public AutomationPracticeHomePage(IWebDriver webdriver) : base(webdriver) { }
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        public void EnterItemAndClickSearch(string text)
        {
            Driver.SwitchTo().Frame(0);
            searchWindowInput.Clear();
            searchWindowInput.SendKeys(text);
            submitButton.Click();
        }
    }
}
