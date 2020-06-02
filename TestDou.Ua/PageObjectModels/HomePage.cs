using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace TestDou.Ua.PageObjectModels
{
    class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(ConfigurationAccessor.HomePageUrl);
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

        public void CheckSwitchingByHeaderTabs()
        {
            _driver.IsElementPresent(By.CssSelector(".b-index-links a"));
            _driver.TakeScreenshot("ГЛАВНАЯ");

            var secondElement = _driver.FindElement(By.LinkText("ФОРУМ"));
            secondElement.Click();
            _driver.IsElementPresent(By.CssSelector("a.text.wrap"));
            _driver.TakeScreenshot("ФОРУМ");

            var thirdElement = _driver.FindElement(By.LinkText("ЛЕНТА"));
            thirdElement.Click();
            _driver.IsElementPresent(By.CssSelector(".page-head h1"));
            _driver.TakeScreenshot("ЛЕНТА");

            var fourthElement = _driver.FindElement(By.LinkText("ЗАРПЛАТЫ"));
            fourthElement.Click();
            _driver.IsElementPresent(By.CssSelector(".wrap a"));
            _driver.TakeScreenshot("ЗАРПЛАТЫ");

            var fifthElement = _driver.FindElement(By.LinkText("РАБОТА"));
            fifthElement.Click();
            _driver.IsElementPresent(By.CssSelector(".sub li"));
            _driver.TakeScreenshot("РАБОТА");

            var sixthElement = _driver.FindElement(By.LinkText("КАЛЕНДАРЬ"));
            sixthElement.Click();
            _driver.IsElementPresent(By.CssSelector(".b-content-menu a"));
            _driver.TakeScreenshot("КАЛЕНДАРЬ");
        }
    }
}