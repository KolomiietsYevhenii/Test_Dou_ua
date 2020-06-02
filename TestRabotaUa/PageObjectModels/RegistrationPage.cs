using OpenQA.Selenium;

namespace TestRabotaUa.PageObjectModels
{
    class RegistrationPage
    {
        private readonly IWebDriver _driver;

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void InputNameField(string name)
        {
            _driver.FindElement(By.Id("ctl00_centerZone_jobsearcherRegister_txtName")).SendKeys(name);
        }

        public void InputSecondNameField(string name)
        {
            _driver.FindElement(By.Id("ctl00_centerZone_jobsearcherRegister_txtSurName")).SendKeys(name);
        }

        public void InputEmailField(string name)
        {
            _driver.FindElement(By.Id("ctl00_centerZone_jobsearcherRegister_txtEmail")).SendKeys(name);
        }

        public void InputPasswordField(string name)
        {
            _driver.FindElement(By.Id("ctl00_centerZone_jobsearcherRegister_txtPassword")).SendKeys(name);
        }

        public void ClickReCaptchaCheckbox()
        {
            _driver.FindElement(By.CssSelector("recaptcha-checkbox-border")).Click();
        }

        public void ClickRegisterButton()
        {
            _driver.FindElement(By.Id("ctl00_centerZone_jobsearcherRegister_imgRegisterJobsearcher")).Click();
        }

    }
}
