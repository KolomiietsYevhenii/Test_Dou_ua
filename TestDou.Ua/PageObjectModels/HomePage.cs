using System.Linq;
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
            _driver.MaximizeWindow();
        }

        public void ClickLoginLink()
        {
            _driver.FindElement(By.Id("login-link")).Click();
        }

        public void ClickLoginByGoogle()
        {
            _driver.FindElement(By.CssSelector("div.login-button.btnGoogle")).Click();
        }

        public void InputEmail(string email)
        {
            _driver.FindElement(By.Name("identifier")).SendKeys(email);
        }

        public void ClickNextButton()
        {
            _driver.FindElement(By.CssSelector("span.RveJvd.snByac")).Click();
        }

        public void InputPassword(string password)
        {
            _driver.FindElement(By.CssSelector("input.whsOnd.zHQkBf")).SendKeys(password);
        }
    }
}
