using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TestRabotaUa
{
    public static class WebDriverExtensions
    {
        public static void MaximizeWindow(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void SwitchToLastWindow(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void WaitUntilElementDisappear(this IWebDriver driver, By findBy, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            bool element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(findBy));
        }

        public static IWebElement WaitUntilElementToBeClickable(this IWebDriver driver, By findBy, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(findBy));
            return element;
        }

        public static void IsElementPresent(this IWebDriver driver, By by)
        {
            {
                driver.FindElement(by);
            }
        }

        //public static void ExplicitWait(this IWebDriver driver)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
        //    wait.Until(WaitUntilElementToBeClickable.)

        //}

        public static void TakeScreenshot(this IWebDriver driver, string filename)
        {
            ITakesScreenshot screenShotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenShotDriver.GetScreenshot();

            screenshot.SaveAsFile(AppDomain.CurrentDomain.BaseDirectory + $"{filename}.png", ScreenshotImageFormat.Png);
        }
    }
}

