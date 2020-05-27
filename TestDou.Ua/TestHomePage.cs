﻿using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestDou.Ua.PageObjectModels;
using NUnit.Framework;

namespace TestDou.Ua
{
    [TestFixture]
    public class TestHomePage : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public TestHomePage()

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

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}