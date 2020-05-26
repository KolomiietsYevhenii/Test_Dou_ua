using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestDou.Ua.PageObjectModels
{
    class JobPage
    {
        private const string PageUrl = "https://jobs.dou.ua/";
        private const string PageTitle = "Вакансии | DOU";
        private readonly IWebDriver _driver;

        public JobPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public List<string> HeaderLiElements()
        {
            List<string> allElements = _driver.FindElements(By.CssSelector(".sub li"))
                .Select(x => x.Text)
                .ToList();

            return allElements;
        }

        public IWebElement JobsTabElement => _driver.FindElements(By.CssSelector(".sub li")).FirstOrDefault();
        public IWebElement TrendsTabElement => _driver.FindElements(By.CssSelector(".sub li")).FirstOrDefault();

        public void ClickSearchFooterLink()
        {
            _driver.FindElement(By.PartialLinkText("Джинне")).Click();
        }

        public void FillJobSearchField(string inputValue)
        {
            _driver.FindElement(By.CssSelector("input.job")).SendKeys(inputValue);
        }

        public void ClickJobSearchButton()
        {
            _driver.FindElement(By.CssSelector("input.btn-search")).Click();
        }

        //TODO move to driver extensions
        public IWebElement FindHeaderWithVacancyCountAndName =>
            _driver.FindElement(By.CssSelector("div.b-inner-page-header h1"));

        public string CountVacancyListElements()
        {
            var allLiElements = _driver.FindElements(By.CssSelector("div#vacancyListId li"));
            var countElements = allLiElements.Count.ToString();
            return countElements;
        }

        public void ClickMoreVacancyButton()
        {
            var totalVacancyCount = FindVacancyCountInFilterCityLink();

            while (CountVacancyListElements() != totalVacancyCount)
            {
                var test = CountVacancyListElements();

                _driver.FindElement(By.CssSelector("div.more-btn a")).Click();

                WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(10));
                bool element =
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("__loading")));

                //wait.Until(_driver => !_driver.FindElement(By.ClassName("__loading")).Displayed);
            }
        }

        //TODO move to driver extensions
        public void ClickFilterCityLink(string city)
        {
            var allCities = _driver.FindElements(By.CssSelector("div.b-region-filter a"));

            var lookUpCityLink = allCities.First(x => x.Text.Contains(city));

            lookUpCityLink.Click();
        }

        public string GetHeaderVacancyText()
        {
            return _driver.FindElement(By.CssSelector("div.b-inner-page-header h1")).Text;
        }


        public string FindVacancyCountInFilterCityLink()
        {
            var selectedCity = _driver.FindElement(By.CssSelector("div.b-region-filter li.selected"));

            var vacancyCount = selectedCity.FindElement(By.TagName("em"));

            return vacancyCount.Text.Trim();
        }


        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(PageUrl);
            _driver.MaximizeWindow();
            EnsurePageLoaded();
        }

        public void NavigateToTab(IWebElement tab)
        {
            tab.Click();
        }

        public void EnsurePageLoaded()
        {
            bool pageHasLoaded = (_driver.Url == PageUrl) && (_driver.Title == PageTitle);
            if (!pageHasLoaded)
            {
                throw new Exception(
                    $"Failed to load page. Page URL = '{_driver.Url}' Page Source: \r\n {_driver.PageSource}");
            }
        }

        public void SelectJobCategory(string value)
        {
            var selectJobElement = _driver.FindElement(By.CssSelector("select"));
            //create select element object 
            SelectElement selectElement = new SelectElement(selectJobElement);
            selectElement.SelectByValue(value);
        }

        public List<string> FindCityInVacancyList()
        {
            List<string> allElements = _driver.FindElements(By.ClassName("cities"))
                .Select(x => x.Text)
                .ToList();
            return allElements;
        }

        public string FindCityInCityFilterLink()
        {
            var selectedCity = _driver.FindElement(By.CssSelector("div.b-region-filter li.selected"));

            var city = selectedCity.FindElement(By.TagName("a"));

            return city.Text.Trim();
        }
    }
}