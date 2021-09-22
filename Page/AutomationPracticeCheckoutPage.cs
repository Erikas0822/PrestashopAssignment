using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace FinalAutomationProject.Page
{
    public class AutomationPracticeCheckoutPage : BasePage
    {
        private IWebElement firstNameInputWindow => Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(2) > div.col-md-6 > input"));
        private IWebElement lastNameInputWindow => Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(3) > div.col-md-6 > input"));
        private IWebElement emailInputWindow => Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(4) > div.col-md-6 > input"));
        private IWebElement customerDataPrivacyCheckBox => Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(9) > div.col-md-6 > span > label > input[type=checkbox]"));
        private IWebElement agreeTermsCheckBox => Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(11) > div.col-md-6 > span > label > input[type=checkbox]"));
        private IWebElement continuePersonalInformationButton => Driver.FindElement(By.CssSelector("#customer-form > footer > button"));
        private IWebElement adressinputWindow => Driver.FindElement(By.CssSelector("#delivery-address > div > section > div:nth-child(7) > div.col-md-6 > input"));
        private IWebElement postalCodeInputWindow => Driver.FindElement(By.CssSelector("#delivery-address > div > section > div:nth-child(9) > div.col-md-6 > input"));
        private IWebElement cityInputWindow => Driver.FindElement(By.CssSelector("#delivery-address > div > section > div:nth-child(10) > div.col-md-6 > input"));
        private IWebElement continueAdressesButton => Driver.FindElement(By.CssSelector("#delivery-address > div > footer > button"));
        private IWebElement continueShippingMethodButton => Driver.FindElement(By.CssSelector("#js-delivery > button"));
        private IWebElement payByCheckRadioButton => Driver.FindElement(By.Id("payment-option-1"));
        private IWebElement additionalPayByCheckInfo => Driver.FindElement(By.CssSelector("#payment-option-1-additional-information > section > p:nth-child(1)"));
        private IWebElement payByBankWireRadioButton => Driver.FindElement(By.Id("payment-option-2"));
        private IWebElement additionalByBankWireInfo => Driver.FindElement(By.Id("payment-option-2-additional-information"));
        private IWebElement agreeTermsAndServices => Driver.FindElement(By.Id("conditions_to_approve[terms-and-conditions]"));
        private IWebElement placeOrderButton => Driver.FindElement(By.CssSelector("#payment-confirmation > div.ps-shown-by-js > button"));
        private IWebElement orderIsConfirmedElement => Driver.FindElement(By.CssSelector("#content-hook_order_confirmation > div > div > div > h3"));
        public AutomationPracticeCheckoutPage(IWebDriver webdriver) : base(webdriver) { }

        public void FillPersonalInformation(string name, string lastName, string email)
        {
            firstNameInputWindow.Clear();
            firstNameInputWindow.SendKeys(name);
            lastNameInputWindow.Clear();
            lastNameInputWindow.SendKeys(lastName);
            emailInputWindow.Clear();
            emailInputWindow.SendKeys(email);
        }
        public void AgreeTermsAndDataPrivacySelect()
        {
            customerDataPrivacyCheckBox.Click();
            agreeTermsCheckBox.Click();
            continuePersonalInformationButton.Click();
        }
        public void FillAdress(string adress, string zip, string city)
        {
            adressinputWindow.Clear();
            adressinputWindow.SendKeys(adress);
            postalCodeInputWindow.Clear();
            postalCodeInputWindow.SendKeys(zip);
            cityInputWindow.Clear();
            cityInputWindow.SendKeys(city);
            continueAdressesButton.Click();
        }
        public void ShippingMethodContinue()
        {
            continueShippingMethodButton.Click();
        }
        public void VerifyPaymentOptions()
        {
            payByCheckRadioButton.Click();
            Assert.AreEqual("Please send us your check including the following details:", additionalPayByCheckInfo.Text, "Selected payment by Check selected correctly");
            payByBankWireRadioButton.Click();
            Assert.IsTrue(additionalByBankWireInfo.Text.Contains("Please transfer the invoice amount to our bank account."), "Selected payment is not by Bank Wire");
        }
        public void VerifyPayByCheckPaymentOption(string payByCheckText)
        {
            payByCheckRadioButton.Click();
            Assert.AreEqual(payByCheckText, additionalPayByCheckInfo.Text, "Selected payment by Check selected correctly");
        }
        public void VerifyPayByBankWirePaymentOption(string payByBankWireText)
        {
            payByBankWireRadioButton.Click();
            Assert.IsTrue(additionalByBankWireInfo.Text.Contains(payByBankWireText), "Selected payment is not by Bank Wire");
        }
        public void SelectPayByCheckButton()
        {
            payByCheckRadioButton.Click();
        }
        public void SelectAgreeTermsCheckBox()
        {
            agreeTermsAndServices.Click();
        }
        public void SelectPlaceOrderButton()
        {
            placeOrderButton.Click();
        }
        public void VerifyOrderIsConfirmed(string confirmedOrderText)
        {
            Assert.IsTrue(orderIsConfirmedElement.Text.Contains(confirmedOrderText), "Order not confirmed");
        }       
    }
}
