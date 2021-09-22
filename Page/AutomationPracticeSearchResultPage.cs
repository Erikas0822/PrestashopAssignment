using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace FinalAutomationProject.Page
{
    class AutomationPracticeSearchResultPage : BasePage
    {
        private IWebElement itemSearchResult => Driver.FindElement(By.CssSelector("#js-product-list > div.products.row > div > article > div > div.product-description > h2 > a"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector("#js-product-list > div.products.row"));
        public AutomationPracticeSearchResultPage(IWebDriver webdriver) : base(webdriver) { }
        public void VerifyResult(string result)
        {
            Assert.AreEqual(result, itemSearchResult.Text, "Selected item is not correct");
        }
        public void AddToCart()
        {
            IWebElement firstResultElement = results.ElementAt(0);
            Actions action = new Actions(Driver);
            IWebElement imageElement = firstResultElement.FindElement(By.CssSelector("#js-product-list > div.products.row > div"));
            action.MoveToElement(imageElement);
            action.Build().Perform();
            firstResultElement.FindElement(By.CssSelector("#js-product-list > div.products.row > div > article > div > div.highlighted-informations.no-variants.hidden-sm-down > a")).Click();
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#add-to-cart-or-refresh > div.product-add-to-cart > div > div.add > button"))).Click();
        }
        public void ProceedToShoppingCart()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#blockcart-modal > div > div > div.modal-body > div > div.col-md-7 > div > div > a"))).Click();
        }
    }

}
