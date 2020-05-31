using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace TestDou.Ua.PageObjectModels
{
    class CalendarPage
    {
        private readonly IWebDriver _driver;

        private static readonly By PaginationLink = By.CssSelector("div.b-paging .page a");

        public CalendarPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(ConfigurationAccessor.CalendarPageUrl);
            _driver.MaximizeWindow();
        }

        public List<string> ClickOnEveryElementsInPagination()
        {
            var eventsUrls = new List<string>();

            var pagesCount = int.Parse(_driver.FindElements(PaginationLink).Last().Text);

            eventsUrls.AddRange(GetEventUrls());

            for (int i = 2; i <= pagesCount; i++)
            {
                var currentPageLink = _driver.FindElements(PaginationLink)
                    .First(x => x.Text == i.ToString());

                currentPageLink.Click();

                eventsUrls.AddRange(GetEventUrls());
            }

            return eventsUrls;
        }

        public List<string> GetEventUrls()
        {
            return _driver.FindElements(By.CssSelector(".b-postcard h2 a"))
                .Select(x => x.GetAttribute("href"))
                .ToList();
        }
    }
}
