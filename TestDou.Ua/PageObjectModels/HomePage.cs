using OpenQA.Selenium;

namespace TestDou.Ua.PageObjectModels
{
    class HomePage
    {
        private const string HomeUrl = "https://dou.ua/";
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(HomeUrl);
        }
    }
}
