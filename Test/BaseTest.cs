using FinalAutomationProject.Drivers;
using FinalAutomationProject.Page;
using FinalAutomationProject.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FinalAutomationProject.Test
{
    class BaseTest
    {
        public static IWebDriver driver;
        public static AutomationPracticeCheckoutPage _automationPracticePage;
        public static AutomationPracticeHomePage _automationPracticeHomePage;
        public static AutomationPracticeSearchResultPage _automationPracticeSearchResultPage;
        public static AutomationPracticeCartPage _automationPracticeCartPage;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDrivers.GetChromeDriver();

            _automationPracticePage = new AutomationPracticeCheckoutPage(driver);
            _automationPracticeHomePage = new AutomationPracticeHomePage(driver);
            _automationPracticeSearchResultPage = new AutomationPracticeSearchResultPage(driver);
            _automationPracticeCartPage = new AutomationPracticeCartPage(driver);
        }
        [TearDown]
        public static void TakeScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenShot(driver);
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}

