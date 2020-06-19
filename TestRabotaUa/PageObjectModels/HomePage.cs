using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestRabotaUa.PageObjectModels
{
    class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(ConfigurationAccessor.HomePageUrl);
            _driver.MaximizeWindow();
        }

        public void ClickLoginButtonOnHomePage()
        {
            _driver.FindElement(By.ClassName("f-header-menu-list-link-with-border")).Click();
        }

        public void InputEmailField(string email)
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_txbLogin")).SendKeys(email);
        }

        public void InputPasswordField(string password)
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_txbPassword")).SendKeys(password);
        }

        public void ClickLoginButtonOnLoginSideBar()
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_lnkLogin")).Click();
        }

        public void ClickLoginRegistrationButtonOnLoginSideBar()
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_hlinkRegister")).Click();
        }

        public void HowerOnFindJobLink()
        {
            var findJobLink = _driver.WaitUntilElementIsVisible(By.LinkText("Знайти роботу"), TimeSpan.FromSeconds(3000));

            Actions action = new Actions(_driver);
            action.MoveToElement(findJobLink).Perform();
        }

        public string FindElementFromHiddenMenuList()
        {
            return _driver.FindElement(By.LinkText("За рубриками")).Text;
        }

        public void InputInSearchField(string keywords)
        {
            _driver.FindElement(By.CssSelector("input.ui-autocomplete-input")).SendKeys(keywords);
        }

        public void InputCitiy(string city)
        {
            var cityField = _driver.FindElement(By.CssSelector("input#ctl00_content_vacSearch_CityPickerWork_inpCity.ui-autocomplete-input"));
            cityField.Clear();
            cityField.SendKeys(city);

            Thread.Sleep(2000);

            _driver.FindElement(By.Id("ctl00_content_vacSearch_lnkSearch")).Click();
        }

        public List<string> FindAllNamesFromVacancysOnPage()
        {
            List<string> vacancyElementsList = _driver.FindElements(By.CssSelector("a.ga_listing"))
                .Select(x => x.Text)
                .ToList();
            return vacancyElementsList;
        }

        public List<string> FindAllCitiesFromVacancysOnPage()
        {
            List<string> citiesElementsList = _driver.FindElements(By.CssSelector("span.location"))
                .Select(x => x.Text)
                .ToList();
            return citiesElementsList;
        }
    }
}
