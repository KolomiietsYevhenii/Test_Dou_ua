using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestDou.Ua.PageObjectModels;

namespace TestDou.Ua
{
    [TestFixture]
    class TestsCalendarPage : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly CalendarPage _page;

        public TestsCalendarPage()

        {
            _driver = new ChromeDriver();
            _page = new CalendarPage(_driver);
        }

        [Test]
        public async Task CheckPagination()
        {
            _page.NavigateTo();
            var httpRequestSender = new HttpRequestSender();

            var eventUrls = _page.ClickOnEveryElementsInPagination();

            foreach (var eventUrl in eventUrls)
            {
                var response = await httpRequestSender.SendGet(eventUrl);

                Assert.AreEqual((HttpStatusCode.OK), response.StatusCode);

                Thread.Sleep(2000);
            }
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
