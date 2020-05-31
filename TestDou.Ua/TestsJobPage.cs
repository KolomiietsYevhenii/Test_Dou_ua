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
        public void CheckingSecondLineHeaderElements()
        {
            _page.NavigateTo();

            Assert.True(_page.HeaderLiElements().Contains("Вакансии"));
            Assert.True(_page.HeaderLiElements().Contains("Тренды"));
            Assert.True(_page.HeaderLiElements().Contains("Компании"));
            Assert.True(_page.HeaderLiElements().Contains("Рейтинг"));
            Assert.True(_page.HeaderLiElements().Contains("Топ-50"));
            Assert.True(_page.HeaderLiElements().Contains("Отзывы"));
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

            Assert.True(_page.FindHeaderWithVacancyCountAndName.Text.Contains("QA"));
            Assert.True(_page.FindHeaderWithVacancyCountAndName.Text.Contains("Luxoft"));
        }

        [Test]
        public void CheckLoadingVacancy()
        {
            _page.NavigateTo();
            _page.SelectJobCategory("QA");
            _page.ClickFilterCityLink("Киев");

            var totalVacancyCount = _page.FindVacancyCountInFilterCityLink();
            var vacancyListElementCount = _page.GetTotaVacancyslElementsCount(totalVacancyCount);

            Assert.True(totalVacancyCount == vacancyListElementCount,
                $"Total count {totalVacancyCount} doesn't match with elements count {vacancyListElementCount}");
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
            var testCity = "Киев";

            _page.NavigateTo();
            _page.SelectJobCategory("QA");
            _page.ClickFilterCityLink(testCity);

            var cityInFilterCityLink = _page.FindCityInCityFilterLink();
            var cityVacancies = _page.FindCityInVacancyList();

            Assert.True(testCity.Equals(cityInFilterCityLink));

            foreach (var cityVacancy in cityVacancies)
            {
                Assert.True(cityVacancy.Contains(testCity), $"City in filter not equal City in vacancy ({cityVacancy}).");
            }
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}