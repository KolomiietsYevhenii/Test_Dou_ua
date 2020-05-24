using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ReadOnlyCollection<IWebElement> HeaderLiElements => _driver.FindElements(By.CssSelector(".sub li"));
        public IWebElement JobsTabElement => _driver.FindElements(By.CssSelector(".sub li")).FirstOrDefault();
        public IWebElement TrendsTabElement => _driver.FindElements(By.CssSelector(".sub li")).FirstOrDefault();

        public string UsersCount => _driver.FindElement(By.CssSelector("\\span.regcount")).Text;

        public void ClickSearchFooterLink()
        {
            _driver.FindElement(By.PartialLinkText("Джинне")).Click();
        }

        //public void SelectCategory() => Driver.FindElement(By.CssSelector("select"));

        public void FillJobSearchField(string inputValue)
        {
            _driver.FindElement(By.CssSelector("input.job")).SendKeys(inputValue);
        }

        public void ClickJobSearchButton()
        {
            _driver.FindElement(By.CssSelector("input.btn-search")).Click();
        }

        public void ClickMoreVacancyButton()
        {
            _driver.FindElement(By.ClassName("more-btn")).Click();
        }


        //TODO move to driver extensions
        public void ClickFilterCityLink(string city)
        {
            var allCities = _driver.FindElements(By.CssSelector("div.b-region-filter a"));

            var lookUpCityLink = allCities.First(x => x.Text.Contains(city));

            lookUpCityLink.Click();
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(PageUrl);
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
                throw new Exception($"Failed to load page. Page URL = '{_driver.Url}' Page Source: \r\n {_driver.PageSource}");
            }
        }

        public void SelectJobCategory(string value)
        {
            var selectJobElement = _driver.FindElement(By.CssSelector("select"));
            //create select element object 
            SelectElement selectElement = new SelectElement(selectJobElement);
            selectElement.SelectByValue(value);
        }
    }
}