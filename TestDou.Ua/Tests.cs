using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestDou.Ua.PageObjectModels;
using NUnit.Framework;

namespace TestDou.Ua
{
    [TestFixture]
    public class Tests
    {
        private readonly IWebDriver _driver;

        public Tests()
        
            {
                _driver = new ChromeDriver();
            }

            [Test]
            public void CheckingSomeElements()
            {
                {
                    var jobPage = new JobPage(_driver);
                    jobPage.NavigateTo();

                    ReadOnlyCollection<IWebElement> informationsElemnents = jobPage.HeaderLiElements;

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
                    var jobPage = new JobPage(_driver);
                    jobPage.NavigateTo();
                    jobPage.NavigateToTab(jobPage.JobsTabElement);
                    jobPage.NavigateToTab(jobPage.TrendsTabElement);

                    jobPage.ClickSearchFooterLink();

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
                    var jobPage = new JobPage(_driver);
                    var homepage = new HomePage(_driver);

                    _driver.MaximizeWindow();
                    jobPage.NavigateTo();
                    string initialUsersCount = jobPage.UsersCount;

                    homepage.NavigateTo();
                    _driver.Navigate().Back();

                    string reloadedUsers = jobPage.UsersCount;
                    Assert.Equals(initialUsersCount, reloadedUsers);
                }
            }

            [Test]
            public void СheckJobSearchField()
            {
                {
                    var jobPage = new JobPage(_driver);
                    jobPage.NavigateTo();

                    jobPage.SelectJobCategory("QA");
                    jobPage.FillJobSearchField("Luxoft");
                    jobPage.ClickJobSearchButton();

                    //Assert.("QA", _driver.FindElement(By.ClassName("b-inner-page-header")).Text);
                    //Assert.Contains("Luxoft", _driver.FindElement(By.CssSelector("a.company")).Text);
                }
            }

            [Test]
            public void СheckLazyLoading()
            {
                {
                    var jobPage = new JobPage(_driver);
                    jobPage.NavigateTo();

                    jobPage.SelectJobCategory("Все категории");
                    jobPage.ClickMoreVacancyButton();
                }
            }

            [Test]
            public void СheckCityFilterCountVacancy()
            {
                {
                    var jobPage = new JobPage(_driver);
                    jobPage.NavigateTo();

                    jobPage.SelectJobCategory("QA");
                    jobPage.ClickFilterCityLink("Киев");
                }
            }
    }
}