using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestDou.Ua.PageObjectModels;
using NUnit.Framework;


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
            _page.NavigateTo();

            //ReadOnlyCollection<IWebElement> informationsElemnents = _page.HeaderLiElements;

            Assert.True("Вакансии".Contains("Вак"));
            Assert.True(_page.HeaderLiElements().Contains("Вакансии"));
            //Assert.True("Тренды".Contains(_page.HeaderLiElements()));
            //Assert.True("Компании".Contains(_page.HeaderLiElements()));
            //Assert.True("Рейтинг".Contains(_page.HeaderLiElements()));
            //Assert.True("Топ-50".Contains(_page.HeaderLiElements()));
            //Assert.True("Отзывы".Contains(_page.HeaderLiElements()));
        }

        [Test]
        public void OpenDjinniFooterLinkInNewTab()
        {
            _page.NavigateTo();
            _page.NavigateToTab(_page.JobsTabElement);
            _page.NavigateToTab(_page.TrendsTabElement);

            _page.ClickSearchFooterLink();

            _driver.SwitchToLastWindow();
            Assert.True(_driver.Url.Contains("https://djinni.co/"), "Redirect to djinny failed");
        }

        [Test]
        public void CheckJobSearchField()
        {
            _page.NavigateTo();

            _page.SelectJobCategory("QA");
            _page.FillJobSearchField("Luxoft");
            _page.ClickJobSearchButton();

            Assert.True("QA".Contains(_page.FindHeaderWithVacancyCountAndName.Text));
            Assert.True("Luxoft".Contains(_page.FindHeaderWithVacancyCountAndName.Text));
        }

        [Test]
        public void CheckLoadingVacancy()
        {
            _page.NavigateTo();
            _page.SelectJobCategory("QA");
            _page.ClickFilterCityLink("Киев");

            _page.ClickMoreVacancyButton();
        }

        [Test]
        public void CheckCityFilterCountVacancy()
        {
            _page.NavigateTo();

            _page.SelectJobCategory("QA");
            _page.ClickFilterCityLink("Киев");

            var countInFilterCityLink = _page.FindVacancyCountInFilterCityLink();
            var headerText = _page.GetHeaderVacancyText();

            Assert.True(headerText.Contains(countInFilterCityLink), "Count in filter not equal count in header");
        }

        [Test]
        public void CheckCityOfVacancyVSCityOfFilter()
        {
            _page.NavigateTo();
            _page.SelectJobCategory("QA");
            _page.ClickFilterCityLink("Киев");

            var cityInFilterCityLink = _page.FindCityInCityFilterLink();
            var cityVacancy = _page.FindCityInVacancyList();

            foreach (var x in cityVacancy)
            {
               Assert.True(cityVacancy.Contains(cityInFilterCityLink), "City in filter not equal City in vacancy");
            }

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}