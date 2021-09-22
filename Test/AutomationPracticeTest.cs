using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationProject.Test
{
    class AutomationPracticeTest : BaseTest
    {
        [Test]
        public static void TestNavigateToPage()
        {
            _automationPracticeHomePage.NavigateToPage();
        }
        [Test]
        public static void TestItemSearch()
        {
            _automationPracticeHomePage.NavigateToPage();
            _automationPracticeHomePage.EnterItemAndClickSearch("Mug The best is yet to come");
            _automationPracticeSearchResultPage.VerifyResult("Mug The Best Is Yet To Come");
        }
        [Test]
        public static void TestItemInShoppingCart()
        {
            _automationPracticeHomePage.NavigateToPage();
            _automationPracticeHomePage.EnterItemAndClickSearch("Mug The best is yet to come");
            _automationPracticeSearchResultPage.AddToCart();
            _automationPracticeSearchResultPage.ProceedToShoppingCart();
            _automationPracticeCartPage.VerifyItemInShoppingCart("Mug The best is yet to come");
        }
        [TestCase("Mug The best is yet to come", "Erikas", "Jarmala", "abra@kadabra.com", "Merkurijaus str. 15", "11111", "Kosmosas", TestName = "Continue to checkout and fill required information")]
        public static void TestCheckoutRequiredFields(string searhText, string firstName, string lastName, string email, string adress, string zip, string city)
        {
            _automationPracticeHomePage.NavigateToPage();
            _automationPracticeHomePage.EnterItemAndClickSearch(searhText);
            _automationPracticeSearchResultPage.AddToCart();
            _automationPracticeSearchResultPage.ProceedToShoppingCart();
            _automationPracticeCartPage.ProceedToCheckOut();
            _automationPracticePage.FillPersonalInformation(firstName, lastName, email);
            _automationPracticePage.AgreeTermsAndDataPrivacySelect();
            _automationPracticePage.FillAdress(adress, zip, city);
        }
        [TestCase("Mug The best is yet to come", "Erikas", "Jarmala", "abra@kadabra.com", "Merkurijaus str. 15", "11111", "Kosmosas", TestName = "Continue to payments page and verify payment options")]
        public static void TestPaymentOptions(string searhText, string firstName, string lastName, string email, string adress, string zip, string city)
        {
            _automationPracticeHomePage.NavigateToPage();
            _automationPracticeHomePage.EnterItemAndClickSearch(searhText);
            _automationPracticeSearchResultPage.AddToCart();
            _automationPracticeSearchResultPage.ProceedToShoppingCart();
            _automationPracticeCartPage.ProceedToCheckOut();
            _automationPracticePage.FillPersonalInformation(firstName, lastName, email);
            _automationPracticePage.AgreeTermsAndDataPrivacySelect();
            _automationPracticePage.FillAdress(adress, zip, city);
            _automationPracticePage.ShippingMethodContinue();
            _automationPracticePage.VerifyPaymentOptions();
        }
        [TestCase("Mug The best is yet to come", "Erikas", "Jarmala", "abra@kadabra.com", "Merkurijaus str. 15", "11111", "Kosmosas", TestName = "Continue to payments page and verify payment by check option")]
        public static void TestPaymentByCheckOption(string searhText, string firstName, string lastName, string email, string adress, string zip, string city)
        {
            _automationPracticeHomePage.NavigateToPage();
            _automationPracticeHomePage.EnterItemAndClickSearch(searhText);
            _automationPracticeSearchResultPage.AddToCart();
            _automationPracticeSearchResultPage.ProceedToShoppingCart();
            _automationPracticeCartPage.ProceedToCheckOut();
            _automationPracticePage.FillPersonalInformation(firstName, lastName, email);
            _automationPracticePage.AgreeTermsAndDataPrivacySelect();
            _automationPracticePage.FillAdress(adress, zip, city);
            _automationPracticePage.ShippingMethodContinue();
            _automationPracticePage.VerifyPayByCheckPaymentOption("Please send us your check including the following details:");
        }
        [TestCase("Mug The best is yet to come", "Erikas", "Jarmala", "abra@kadabra.com", "Merkurijaus str. 15", "11111", "Kosmosas", TestName = "Continue to payments page and verify payment by bank wire option")]
        public static void TestPaymentByBankWireOption(string searhText, string firstName, string lastName, string email, string adress, string zip, string city)
        {
            _automationPracticeHomePage.NavigateToPage();
            _automationPracticeHomePage.EnterItemAndClickSearch(searhText);
            _automationPracticeSearchResultPage.AddToCart();
            _automationPracticeSearchResultPage.ProceedToShoppingCart();
            _automationPracticeCartPage.ProceedToCheckOut();
            _automationPracticePage.FillPersonalInformation(firstName, lastName, email);
            _automationPracticePage.AgreeTermsAndDataPrivacySelect();
            _automationPracticePage.FillAdress(adress, zip, city);
            _automationPracticePage.ShippingMethodContinue();
            _automationPracticePage.VerifyPayByBankWirePaymentOption("Please transfer the invoice amount to our bank account.");
        }
        [TestCase("Mug The best is yet to come", "Erikas", "Jarmala", "abra@kadabra.com", "Merkurijaus str. 15", "11111", "Kosmosas", TestName = "Continue to purchase the product and check that order is confirmed")]
        public static void TestPurchaseTheProduct(string searhText, string firstName, string lastName, string email, string adress, string zip, string city)
        {
            _automationPracticeHomePage.NavigateToPage();
            _automationPracticeHomePage.EnterItemAndClickSearch(searhText);
            _automationPracticeSearchResultPage.AddToCart();
            _automationPracticeSearchResultPage.ProceedToShoppingCart();
            _automationPracticeCartPage.ProceedToCheckOut();
            _automationPracticePage.FillPersonalInformation(firstName, lastName, email);
            _automationPracticePage.AgreeTermsAndDataPrivacySelect();
            _automationPracticePage.FillAdress(adress, zip, city);
            _automationPracticePage.ShippingMethodContinue();
            _automationPracticePage.SelectPayByCheckButton();
            _automationPracticePage.SelectAgreeTermsCheckBox();
            _automationPracticePage.SelectPlaceOrderButton();
            _automationPracticePage.VerifyOrderIsConfirmed("YOUR ORDER IS CONFIRMED");
        }
    }
}
