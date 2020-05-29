using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestDou.Ua.PageObjectModels
{
    class CalendarPage
    {
        private const string PageUrl = "https://dou.ua/calendar/";
        private const string PageTitle = "Календарь ИТ-событий | DOU";
        private readonly IWebDriver _driver;

        public CalendarPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(PageUrl);
            _driver.MaximizeWindow();
        }

        public List<string> ClickOnEveryElementsInPagination()
        {
            var eventsUrls = new List<string>();

            var pagesCount = int.Parse(_driver.FindElements(By.CssSelector("div.b-paging .page a")).Last().Text);

            eventsUrls.AddRange(GetEventUrls());

            for (int i = 2; i <= pagesCount; i++)
            {
                var currentPageLink = _driver.FindElements(By.CssSelector("div.b-paging .page a"))
                    .First(x => x.Text == i.ToString());

                currentPageLink.Click();

                eventsUrls.AddRange(GetEventUrls());
            }

            return eventsUrls;
        }

        public List<string> GetEventUrls()
        {
            return _driver.FindElements(By.CssSelector(".b-postcard h2 a"))
                .Select(x => x.Text)
                .ToList();
        }


        public async Task<HttpStatusCode> WebRequestGet()
        {
            var client = new HttpClient();

            var result = await client.GetAsync("https://dou.ua/calendar/");
            return result.StatusCode;
        }

    }
}
