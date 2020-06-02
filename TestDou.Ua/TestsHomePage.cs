using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestDou.Ua.PageObjectModels;
using NUnit.Framework;
using System.Threading;

namespace TestDou.Ua
{
    [TestFixture]
    public class TestsHomePage : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public TestsHomePage()

        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
        }

        [Test]

        // For this test you need sign in to Google Account. 
        public void Login()
        {
            _homePage.NavigateTo();
            _homePage.ClickLoginLink();
            _homePage.ClickLoginByGoogle();

            _driver.SwitchToLastWindow();

            _homePage.InputEmail("aloha.ki990@gmail.com");
            _homePage.ClickNextButton();

            _driver.SwitchToLastWindow();

            _homePage.InputPassword("Password");
            _homePage.ClickNextButton();

            Thread.Sleep(2000);
            _driver.TakeScreenshot("Login");
        }

        [Test]
        public void CheckingMainHeaderTab()
        {
            _homePage.NavigateTo();
            _driver.MaximizeWindow();

            _homePage.CheckSwitchingByHeaderTabs();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
