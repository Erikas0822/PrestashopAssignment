using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationProject.Page
{
    class AutomationPracticeCartPage : BasePage
    {
        private IWebElement itemInShoppingCart => Driver.FindElement(By.CssSelector("#main > div > div.cart-grid-body.col-xs-12.col-lg-8 > div > div.cart-overview.js-cart > ul > li > div > div.product-line-grid-body.col-md-4.col-xs-8 > div:nth-child(1) > a"));
        private IWebElement proceedToCheckOutButton => Driver.FindElement(By.CssSelector("#main > div > div.cart-grid-right.col-xs-12.col-lg-4 > div.card.cart-summary > div.checkout.cart-detailed-actions.card-block > div > a"));

        public AutomationPracticeCartPage(IWebDriver webdriver) : base(webdriver) { }
        public void VerifyItemInShoppingCart(string text)
        {
            Assert.AreEqual(itemInShoppingCart.Text, text, "Wrong or no item is in shopping cart");
        }
        public void ProceedToCheckOut()
        {
            proceedToCheckOutButton.Click();
        }
    }
}
