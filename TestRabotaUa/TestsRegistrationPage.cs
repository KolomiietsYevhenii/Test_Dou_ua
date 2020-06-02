using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestRabotaUa.PageObjectModels;
using System.Threading;

namespace TestRabotaUa
{
    [TestFixture]
    class TestsRegistrationPage : IDisposable

    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly RegistrationPage _registrationPage;

        public TestsRegistrationPage()

        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _registrationPage = new RegistrationPage(_driver);
        }

        [Test]
        public void Registration()
        {
            _homePage.NavigateTo();
            _driver.WaitUntilElementToBeClickable(By.ClassName("f-header-menu-list-link-with-border"), TimeSpan.FromSeconds(3000));
            _homePage.ClickLoginButtonOnHomePage();
            _homePage.ClickLoginButtonOnLoginSideBar();
            _homePage.ClickLoginRegistrationButtonOnLoginSideBar();

            Thread.Sleep(1000);

            _registrationPage.InputNameField("Test");
            _registrationPage.InputSecondNameField("Test");
            _registrationPage.InputEmailField("test.email.qa20@gmail.com");
            _registrationPage.InputPasswordField("95359535");
            _registrationPage.ClickRegisterButton();

            Thread.Sleep(1000);

            _driver.TakeScreenshot("RegistrationPage");
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
