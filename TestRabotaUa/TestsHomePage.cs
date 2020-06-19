using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestRabotaUa.PageObjectModels;
using System.Threading;

namespace TestRabotaUa
{
    [TestFixture]
    public class TestsHomePage : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public TestsHomePage()

        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
        }

        [Test]
        public void Login()
        {
            //var htmlReporter = new ExtentHtmlReporter("C:/Users/Asus/Documents/Visual Studio 2015/Projects/TestDou.Ua/TestRabotaUa/ExtentReport.html");
            //var extent = new ExtentReports();
            //extent.AttachReporter(htmlReporter);

            //var feature = extent.CreateTest<Feature>("Login");

            //var scenario = feature.CreateNode<Scenario>("Login user as simple user");

            //scenario.CreateNode<Given>("Navigate to application");

            //extent.Flush();
            
            _homePage.NavigateTo();

            _driver.WaitUntilElementToBeClickable(By.ClassName("f-header-menu-list-link-with-border"), TimeSpan.FromSeconds(3000));
            _homePage.ClickLoginButtonOnHomePage();
            _homePage.InputEmailField("test.email.qa20@gmail.com");
            _homePage.InputPasswordField("95359535");
            _homePage.ClickLoginButtonOnLoginSideBar();

            Thread.Sleep(1000);
            _driver.TakeScreenshot("LoginPage");

            Assert.True(_driver.Url.Contains("profile"));
        }

        [Test]
        public void CheckHowerOnFindJobLink()
        {
            _homePage.NavigateTo();

            _homePage.HowerOnFindJobLink();
          
            var elementFromHiddenMenuList = _homePage.FindElementFromHiddenMenuList();

            Assert.True(elementFromHiddenMenuList.Equals("За рубриками"), "Actual link text of element from hidden list doesn't equals expected");
        }

        [Test]
        public void CheckSearchField()
        {
            _homePage.NavigateTo();
            _homePage.InputInSearchField("QA Engineer");

            _homePage.InputCitiy("Київ");

            var allVacancysName = _homePage.FindAllNamesFromVacancysOnPage();
            var allCitiesName = _homePage.FindAllCitiesFromVacancysOnPage();

            Assert.True(allCitiesName.Contains("Київ"));
            Assert.True(allVacancysName.Contains("QA Engineer"));    
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}