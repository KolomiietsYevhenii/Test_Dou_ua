using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestDou.Ua.PageObjectModels;
using NUnit.Framework;

namespace TestDou.Ua
{
    [TestFixture]
    public class TestsJobPage
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

                    Assert.AreEqual("Вакансии", informationsElemnents[0].Text);
                    Assert.AreEqual("Тренды", informationsElemnents[1].Text);
                    Assert.AreEqual("Компании", informationsElemnents[2].Text);
                    Assert.AreEqual("Рейтинг", informationsElemnents[3].Text);
                    Assert.AreEqual("Топ-50", informationsElemnents[4].Text);
                    Assert.AreEqual("Отзывы", informationsElemnents[5].Text);
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
                    string jobPageTab = allTabs[0];
                    string searchDjinniTab = allTabs[1];
                    _driver.SwitchTo().Window(searchDjinniTab);
                    Assert.AreSame("https://djinni.co/", _driver.Url);
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
                    Assert.Equals(initialUsersCount, reloadedUsers);
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

                    //Assert.("QA", _driver.FindElement(By.ClassName("b-inner-page-header")).Text);
                    //Assert.Contains("Luxoft", _driver.FindElement(By.CssSelector("a.company")).Text);
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
                }
            }
    }
}