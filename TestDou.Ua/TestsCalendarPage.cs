using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
            await _page.WebRequestGet();

            var carentStatusCode = await _page.WebRequestGet();
            
            Assert.AreEqual((HttpStatusCode.OK), carentStatusCode);

            //_page.ClickOnEveryElementsInPagination();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
