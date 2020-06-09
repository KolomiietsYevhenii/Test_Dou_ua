using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

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

        public void HowerOnFindJobLink()
        {
            var findJobLink = _driver.WaitUntilElementIsVisible(By.LinkText("Знайти роботу"), TimeSpan.FromSeconds(3000)); 

            Actions action = new Actions(_driver);
            action.MoveToElement(findJobLink).Perform();
        }        
        
        public string FindElementFromHiddenMenuList()
        {
            return _driver.FindElement(By.LinkText("За рубриками")).Text;
        }    
    }
}
