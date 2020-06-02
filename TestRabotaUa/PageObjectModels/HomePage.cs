using OpenQA.Selenium;

namespace TestRabotaUa.PageObjectModels
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

        public void ClickLoginButtonOnHomePage()
        {
            _driver.FindElement(By.ClassName("f-header-menu-list-link-with-border")).Click();
        }

        public void InputEmailField(string email)
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_txbLogin")).SendKeys(email);
        }

        public void InputPasswordField(string password)
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_txbPassword")).SendKeys(password);
        }

        public void ClickLoginButtonOnLoginSideBar()
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_lnkLogin")).Click();
        }

        public void ClickLoginRegistrationButtonOnLoginSideBar()
        {
            _driver.FindElement(By.Id("ctl00_Sidebar_login_hlinkRegister")).Click();
        }
    }
}
