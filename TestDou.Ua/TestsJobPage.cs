using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestDou.Ua.PageObjectModels;
using NUnit.Framework;
using Assert = Xunit.Assert;

namespace TestDou.Ua
{
    [TestFixture]
    public class TestsJobPage : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly JobPage _page;

        public TestsJobPage()

        {
            _driver = new ChromeDriver();
            _page = new JobPage(_driver);
        }
        [Test]
        public void CheckingSomeElements()
        {
            {
                _page.NavigateTo();

                ReadOnlyCollection<IWebElement> informationsElemnents = _page.HeaderLiElements;

                Assert.Equal("Вакансии", informationsElemnents[0].Text);
                Assert.Equal("Тренды", informationsElemnents[1].Text);
                Assert.Equal("Компании", informationsElemnents[2].Text);
                Assert.Equal("Рейтинг", informationsElemnents[3].Text);
                Assert.Equal("Топ-50", informationsElemnents[4].Text);
                Assert.Equal("Отзывы", informationsElemnents[5].Text);
            }
        }
        [Test]
        public void OpenDjinniFooterLinkInNewTab()
        {
            {
                _page.NavigateTo();
                _page.NavigateToTab(_page.JobsTabElement);
                _page.NavigateToTab(_page.TrendsTabElement);

                _page.ClickSearchFooterLink();

                ReadOnlyCollection<string> allTabs = _driver.WindowHandles;
                //string jobPageTab = allTabs[0];
                string searchDjinniTab = allTabs[1];
                _driver.SwitchTo().Window(searchDjinniTab);
                Assert.StartsWith("https://djinni.co/", _driver.Url);
            }
        }
        [Test]
        public void ReloadJobPageOnBack()
        {
            {
                var homepage = new HomePage(_driver);

                _driver.MaximizeWindow();
                _page.NavigateTo();
                string initialUsersCount = _page.UsersCount;

                homepage.NavigateTo();
                _driver.Navigate().Back();

                string reloadedUsers = _page.UsersCount;
                Assert.Equal(initialUsersCount, reloadedUsers);
            }
        }
        [Test]
        public void СheckJobSearchField()
        {
            {
                _page.NavigateTo();

                _page.SelectJobCategory("QA");
                _page.FillJobSearchField("Luxoft");
                _page.ClickJobSearchButton();

                //Assert.Contains("QA", _driver.FindElement(By.CssSelector("div.b-inner-page-header h1")).Text);
                Assert.Contains("QA", _page.FindHeaderWithVacancyCountAndName.Text);
                Assert.Contains("Luxoft", _page.FindHeaderWithVacancyCountAndName.Text);
            }
        }
        [Test]
        public void СheckLazyLoading()
        {
            {
                _page.NavigateTo();

                _page.SelectJobCategory("Все категории");

                _page.ClickMoreVacancyButton();
            }
        }
        [Test]
        public void СheckCityFilterCountVacancy()
        {
            {
                _page.NavigateTo();

                _page.SelectJobCategory("QA");
                _page.ClickFilterCityLink("Киев");

                //Assert.;
            }
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}